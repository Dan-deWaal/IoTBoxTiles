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
        public HttpResponseMessage heartbeatResponse, loginResponse;
        public string heartbeatURL { get; set; }
        public string loginURL { get; set; }

        public ServerComm() {
            client = new HttpClient();
            heartbeatURL = @"https://iot.duality.co.nz/api/1/heartbeat";
            loginURL     = @"https://iot.duality.co.nz/api/1/user/devices";
        }

        public async Task<int> GetHeartbeatAsync()
        {
            int result = 0;
            heartbeatResponse = await client.GetAsync(heartbeatURL);
            try
            {
                if (heartbeatResponse.IsSuccessStatusCode)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }
            }
            catch
            {
                result = 0;
            }
            return result; //0 = Not Connected,  1 = Connected,  2 = Server Failure.
        }

        public async Task<int> LoginAsync(string email, string pass)
        {
            int result = 0;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("email", email);
            client.DefaultRequestHeaders.Add("password", pass);
            loginResponse = await client.GetAsync(loginURL);
            try
            {
                if (loginResponse.IsSuccessStatusCode)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }
            }
            catch
            {
                result = 0;
            }
            return result; //0 = Not Connected,  1 = Connected,  2 = Server Failure.
        }
    }
}
