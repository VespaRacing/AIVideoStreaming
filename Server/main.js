const http = require('http');
const { json } = require('stream/consumers');
const WebSocket = require('ws');

// Create an HTTP server
const server = http.createServer();

// Create a WebSocket server associated with the HTTP server
const wss = new WebSocket.Server({ server });

let clients = [];

// When a client connects
wss.on('connection', (ws) => {
  console.log('Client connected');
  clients.push(ws);
  
  var bool = true;
  // When the server receives a message from the client
  ws.on('message', async (received) => {

    console.log("ricevuto");
    let message = received.toString();

    const json = JSON.parse(message);

    const AIhost = json.AIhost;


    //AI
   /* try {
      const formData = new FormData();
      if(bool){
        console.log(json.bytes);
        bool = false;
      }
      formData.append('image', new Blob([json.bytes], { type: 'image/jpg' }));

      const response = await fetch(`http://${AIhost}:5000/v1/object-detection/yolov5`, {
        method: 'POST',
        body: formData
      });

      if (response.ok) {
        const responseData = await response.text();
        const jsonResponse = JSON.parse(responseData);
        

        //send
        clients.forEach(client => {
          console.log("inviato");
          //if(client!=ws){
          ws.send(JSON.stringify({jsonResponse})), (error) => {
            if (error) {
              console.log("errore");
            }
          };
          //}
        });

      } else {
        console.error(`Error: ${response.status} - ${response.statusText}`);
      }
    } catch (error) {
      console.error(`Error in consumeAI: ${error.message}`);
    }*/

    //send
    let num = 0;
    clients.forEach(client => {
      //if(client!=ws){
        num+=1;
      client.send(JSON.stringify({ message })), (error) => {
        if (error) {
          console.log("errore");
        }
      };
      //}
    });
  });

  ws.on("close", () => {
    clients = clients.filter(client => client != ws);
    console.log("Disconnected")
  })
});

// Start the HTTP server on the desired port
const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});