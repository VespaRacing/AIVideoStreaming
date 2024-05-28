using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideCall;

namespace VideoCall
{
    public class Frame
    {
        private Bitmap bmp;
        public Bitmap Bmp
        {
            get { return bmp; }
            set { bmp = value; }
        }

        public byte[] bytes;

        public Byte[] Bytes
        {
            get { return bytes; }
            set { this.bytes = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Frame(Bitmap bmp, byte[] bytes, DateTime date)
        {
            Bytes = bytes;
            Date = date;
            Bmp = bmp;
        }
    }


    public class ModifiedFrame : Frame
    {

        private Bitmap bmp;

        public Bitmap Bmp
        {
            get { return bmp; }
            set { bmp = value; }
        }

        private response info;

        public response Info
        {
            get { return info; }
            set { info = value; }
        }
        public ModifiedFrame(Bitmap bmp, byte[] bytes, DateTime date, response info) : base(bmp, bytes, date)
        {
            Bytes = bytes;
            Date = date;
            Info = info;
            Bmp = bmp;
        }
    }
}
