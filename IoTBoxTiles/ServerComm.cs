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

        public ServerComm() {
            client = new HttpClient();
        }

        public string urlBuilder(string req)
        {
            string result = @"https://iot.duality.co.nz/api/1/device/"+req+@"/info";

            if (req.Equals("heartbeat", StringComparison.OrdinalIgnoreCase))
            {
                result = @"https://iot.duality.co.nz/api/1/heartbeat";
            }
            if (req.Equals("login", StringComparison.OrdinalIgnoreCase))
            {
                result = @"https://iot.duality.co.nz/api/1/user/devices";
            }
            return result;
        }

        public async Task<Tuple<int, HttpResponseMessage>> GetAsync(string url, string email, string passwd)
        {
            int result = 0;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("email", email);
            client.DefaultRequestHeaders.Add("password", passwd);
            HttpResponseMessage getResponse = await client.GetAsync(url);
            try
            {
                result = getResponse.IsSuccessStatusCode ? 1 : 2;
            }
            catch
            {
                result = 0;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, getResponse);
        }

        public async Task<Tuple<int, HttpResponseMessage>> GetAsync(string url)
        {
            int result = 0;
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage getResponse = await client.GetAsync(url);
            try
            {
                result = getResponse.IsSuccessStatusCode ? 1 : 2;
            }
            catch
            {
                result = 0;
            }
            return Tuple.Create(result, getResponse);
        }
        
    }
}
