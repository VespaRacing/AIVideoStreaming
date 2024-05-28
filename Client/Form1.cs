using System.IO;
using System.Threading.Tasks;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Net;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using MjpegProcessor;
using VideCall;
using System.Collections.Generic;
using DirectShowLib;
using Accord.Video.FFMPEG;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VideoCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form1.CheckForIllegalCrossThreadCalls = false;

            combo_cameras.Items.Clear();

            var videoInputDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            // Print out the list of camera devices
            foreach (var device in videoInputDevices)
            {
                combo_cameras.Items.Add(device.Name);
            }
            if (combo_cameras.Items.Count > 0)
            {
                combo_cameras.SelectedIndex = 0;
            }
        }


        public List<ModifiedFrame> framesList = new List<ModifiedFrame>();

        public List<Frame> stockFramesList = new List<Frame>();

        bool connected = false;

        public string ip;

        public object locker = new object();

        bool cameraEnabled = false;

        WebSocket ws;

        public int num = 0;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                ws.Close();
                closeProcess("MJPEGServer");
                if (cameraEnabled)
                {
                    mjpeg.FrameReady -= mjpeg_FrameReady;
                    mjpeg.Error -= mjpeg_Error;
                    mjpeg.StopStream();
                }
                pictureBox1.Image = null;
                connected = false;
                (sender as System.Windows.Forms.Button).Text = "JOIN";

                await Task.Delay(1000);
                if (check_saveVideo.Checked)
                {
                    exportVideo();
                }
            }
            else
            {
                framesList.Clear();
                num = 0;
                closeProcess("MJPEGServer");
                //var serverUri = "ws://192.168.1.16:3000";
                string serverUri = $"ws://{txt_serverIp.Text}:3000";
                ws = new WebSocket(serverUri);
                ws.Connect();
                connected = true;
                cameraEnabled = false;
                if (check_cameraEnabled.Checked)
                {
                    cameraEnabled = true;
                    StartMJPEGserverProcess(); // avvia lo streaming da ffmpeg
                    mjpeg = new MjpegDecoder();
                    mjpeg.FrameReady += mjpeg_FrameReady;
                    mjpeg.Error += mjpeg_Error;
                    mjpeg.ParseStream(new Uri("http://127.0.0.1:9000")); // start stream
                }

                (sender as System.Windows.Forms.Button).Text = "LEAVE";


                ////Immagini

                // ws.OnMessage += (sender2, e2) =>
                // { // Ricevi lo screenshot dal server
                //     Console.WriteLine("ricevuto");
                //     string response = e2.Data;
                //     JObject outerObject = JObject.Parse(response);
                //     JObject innerObject = JObject.Parse((string)outerObject["message"]);
                //     byte[] message = (byte[])innerObject["bytes"];

                //     pictureBox1.Image = Image.FromStream(new MemoryStream(message));

                //     //// Deserializza la risposta JSON
                //     //byte[] bytes = e2.RawData;
                //     //// Salva l'immagine su disco
                //     //pictureBox1.Image = Image.FromStream(new MemoryStream(bytes));

                // };

                // byte[] bytes2 = File.ReadAllBytes("R1M.jpeg");
                // ws.Send(JsonConvert.SerializeObject(new { bytes = bytes2 }));




                ////VIDEO

                //ws.OnMessage += (sender2, e2) =>
                //{
                //    if (File.Exists("output.mp4"))
                //    {
                //        File.Delete("output.mp4");
                //    }
                //    Stream videoStream = new FileStream("output.mp4", FileMode.Create);
                //    BinaryWriter videoStreamWriter = new BinaryWriter(videoStream);
                //    Console.WriteLine("ricevuto");
                //    string response = e2.Data;
                //    JObject outerObject = JObject.Parse(response);
                //    JObject innerObject = JObject.Parse((string)outerObject["message"]);
                //    byte[] message = (byte[])innerObject["bytes"];

                //    videoStreamWriter.Write(message, 0, message.Length);
                //    videoStreamWriter.Close();
                //};

                //OpenFileDialog dialog = new OpenFileDialog();
                //dialog.InitialDirectory = "C:\\";

                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    var path = dialog.FileName; 
                //    byte[] bytes2 = File.ReadAllBytes(path);
                //    ws.Send(JsonConvert.SerializeObject(new { bytes = bytes2 }));
                //}


                //Video Call

                ws.OnMessage += (sender2, e2) =>
                { // Ricevi lo screenshot dal server
                    ThreadStart start = new ThreadStart(async delegate
                    {
                        txt_messageReceived.Text = "Received";
                        await Task.Delay(200);
                        txt_messageReceived.Text = "";
                    });
                    new Thread(start).Start();
                    Console.WriteLine("Ricevuto");
                    string response = e2.Data;
                    JObject outerObject = JObject.Parse(response);
                    JObject innerObject = JObject.Parse((string)outerObject["message"]);
                    byte[] message = (byte[])innerObject["bytes"];

                    ConsumeAI(message);
                    //pictureBox1.Image = Image.FromStream(new MemoryStream(message));

                    //// Deserializza la risposta JSON
                    //byte[] bytes = e2.RawData;
                    //// Salva l'immagine su disco
                    //pictureBox1.Image = Image.FromStream(new MemoryStream(bytes));

                };
            }

        }





        private MjpegDecoder mjpeg;


        void mjpeg_FrameReady(object sender2, FrameReadyEventArgs e2)
        {
            //USB2.0 VGA UVC WebCam
            ws.Send(JsonConvert.SerializeObject(new { bytes = e2.FrameBuffer, AIhost = txt_insIpAI.Text }));
        }


        private void mjpeg_Error(object sender, MjpegProcessor.ErrorEventArgs e)
        {
            MessageBox.Show(e.Message);
        }


        public static int step = 0;


        async void ConsumeAI(byte[] jpeg)
        {
            try
            {
                using (var httpClient = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    var imageContent = new ByteArrayContent(jpeg);
                    imageContent.Headers.Add("Content-Disposition", "form-data; name=\"image\"; filename=\"gatto.jpeg\"");
                    formData.Add(imageContent);

                    var response = await httpClient.PostAsync($"http://{txt_insIpAI.Text}:5000/v1/object-detection/yolov5", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        dynamic json = JsonConvert.DeserializeObject(responseData);
                        showSmartImage(json, jpeg);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ConsumeAI: {ex.Message}");
            }
        }


        public response data;
        void showSmartImage(dynamic json, byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            Bitmap bmp = new Bitmap(stream);
            Frame frame = new Frame(bmp, bytes, DateTime.Now);
            stockFramesList.Add(frame);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            
            foreach (var item in json)
            {
                decimal xmin = item["xmin"];
                decimal xmax = item["xmax"];
                decimal ymin = item["ymin"];
                decimal ymax = item["ymax"];
                decimal confidence = item["confidence"];
                int class2 = item["class"];
                string name = item["name"];
                data = new response(xmin, xmax, ymin, ymax, confidence, class2, name);
                gr.DrawString(name, new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Red), (float)xmin, (float)ymin);
                Rectangle rect = new Rectangle(int.Parse(data.xmin.ToString()), int.Parse(data.ymin.ToString()), int.Parse((data.xmax - data.xmin).ToString()), int.Parse((data.ymax - data.ymin).ToString()));
                gr.DrawRectangle(new Pen(Color.Red), rect);
            }
            pictureBox1.Image = bmp;
            num++;
            framesList.Add(new ModifiedFrame(bmp, bytes, frame.Date, data));
            gr.Dispose();
        }



        protected void StartMJPEGserverProcess()
        {

            // ffmpeg -list_devices true -f dshow -i dummy
            // ffmpeg - f dshow - list_options true - i
            // video = "Logi C310 HD WebCam"
            // AUKEY PC-W1
            // USB2.0 VGA UVC WebCam





            var camera = "USB2.0 VGA UVC WebCam";
            string arguments = $@"-- ffmpeg  -f dshow -i video=""{combo_cameras.SelectedItem}"" -video_size 840x680  -threads 6 -f mpjpeg -r {txt_insFPS.Text} -q 2 -";
            //string arguments = $@"-- ffmpeg -i http://192.168.112.57:81/videostream.cgi?loginuse=admin&loginpas=  -video_size 640x480 -vcodec mjpeg -rtbufsize 1000M -f mpjpeg -r 10 -q 3 -";
            //string arguments = $@"-- ffmpeg -i http://83.56.31.69/mjpg/video.mjpg  -video_size 640x480 -vcodec mjpeg -rtbufsize 1000M -f mpjpeg -r 10 -q 3 -";
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = "MJPEGServer.exe",
                Arguments = arguments,
                UseShellExecute = true, // window
                LoadUserProfile = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                //RedirectStandardOutput = true,
            };

            Process.Start(info);
        }



        async private void exportVideo()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                int width = stockFramesList[0].Bmp.Width;
                int height = stockFramesList[0].Bmp.Height;
                int frameCount = stockFramesList.Count;

                VideoFileWriter writer = new VideoFileWriter();
                string name = DateTime.Now.ToString();
                writer.Open($"{folder.SelectedPath}/{name}.mp4", width, height, int.Parse(txt_insFPS.Text), VideoCodec.MPEG4);

                StreamWriter writer2 = new StreamWriter($"{folder.SelectedPath}/{name}.txt");

                // Write bitmap frames to the video file
                foreach (ModifiedFrame frame in framesList)
                {
                    writer2.WriteLine(frame.Info.name);
                    writer.WriteVideoFrame(frame.Bmp);
                }

                // Close the writer
                writer.Close();
                writer2.Close();
                
            }
            MessageBox.Show("Salvato");
        }

        public void closeProcess(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            Array.ForEach(processes, (process) =>
            {
                process.Kill();
            });
        }

        private void parrotGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}