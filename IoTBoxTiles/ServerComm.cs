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
        public string heartbeat { get; set; }
        public string login { get; set; }
        public string details { get; set; }

        public ServerComm() {
            client = new HttpClient();
            heartbeat = @"https://iot.duality.co.nz/api/1/heartbeat";
            login = @"https://iot.duality.co.nz/api/1/user/devices/list";
            details = @"https://iot.duality.co.nz/api/1/user/devices/details";
        }
        
        public async Task<Tuple<int, HttpResponseMessage>> GetAsync(string url, string email, string passwd)
        {
            int result = 0;
            HttpResponseMessage getResponse = null;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("email", email);
            client.DefaultRequestHeaders.Add("password", passwd);
            try
            {
                getResponse = await client.GetAsync(url);
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
            HttpResponseMessage getResponse = null;
            client.DefaultRequestHeaders.Clear();
            try
            {
                getResponse = await client.GetAsync(url);
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
