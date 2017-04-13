using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Newtonsoft.Json;

namespace IoTBoxTiles
{
    class ServerComm
    {
        private HttpClient client;
        private HttpResponseMessage heartbeatResponse, loginResponse;
        public string heartbeatURL { get; set; }
        public string heartbeat { get; set; }

        public ServerComm() {
            client = new HttpClient();
            heartbeatURL = @"https://iot.duality.co.nz/api/1/heartbeat";
        }

        public async Task GetHeartbeatAsync()
        {
            heartbeatResponse = await client.GetAsync(heartbeatURL);
            try
            {
                if (heartbeatResponse.IsSuccessStatusCode)
                {
                    //Console.WriteLine(c + ": Connected");
                    heartbeat = "Connected";
                }
                else
                {
                    //Console.WriteLine(c + ": Server Failure");
                    heartbeat = "Server Failure";
                }
            }
            catch
            {
                //Console.WriteLine(c + ": Not Connected");
                heartbeat = "Not Connected";
            }
        }
    }
}
