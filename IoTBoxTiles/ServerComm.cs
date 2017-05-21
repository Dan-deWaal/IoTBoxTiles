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
    public enum ServerResponse { NotConnected, Connected, ServerFailure };
    class ServerComm
    {
        private static readonly Lazy<ServerComm> lazy =
            new Lazy<ServerComm>(() => new ServerComm());
        public static ServerComm Instance { get { return lazy.Value; } }
        private HttpClient client;

        public string Root = @"https://iot.duality.co.nz/api/1";

        public string Email { private get;  set; }
        public string Password { private get; set; }

        private ServerComm()
        {
            client = new HttpClient();
        }
        
        public async Task<Tuple<ServerResponse, HttpResponseMessage>> GetAsync(
            string url, bool need_credentials = true)
        {
            ServerResponse result = ServerResponse.NotConnected;
            HttpResponseMessage getResponse = null;
            client.DefaultRequestHeaders.Clear();
            if (need_credentials)
            {
                client.DefaultRequestHeaders.Add("email", Email);
                client.DefaultRequestHeaders.Add("password", Password);
            }
            try
            {
                getResponse = await client.GetAsync(url);
                result = getResponse.IsSuccessStatusCode ? ServerResponse.Connected : ServerResponse.ServerFailure;
            }
            catch
            {
                result = 0;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, getResponse);
        }
        
        public async Task<Tuple<ServerResponse, HttpResponseMessage>> PostAsync(string url, 
            HttpContent body = null, bool need_credentials = true)
        {
            ServerResponse result = ServerResponse.NotConnected;
            HttpResponseMessage postResp = null;
            client.DefaultRequestHeaders.Clear();
            if (need_credentials)
            {
                client.DefaultRequestHeaders.Add("email", Email);
                client.DefaultRequestHeaders.Add("password", Password);
            }
            try
            {
                postResp = await client.PostAsync(url, body);
                result = postResp.IsSuccessStatusCode ? ServerResponse.Connected : ServerResponse.ServerFailure;
            }
            catch
            {
                result = ServerResponse.NotConnected;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, postResp);
        }

        public async Task<Tuple<ServerResponse, HttpResponseMessage>> PutAsync(string url,
            HttpContent body = null, bool need_credentials = true)
        {
            ServerResponse result = ServerResponse.NotConnected;
            HttpResponseMessage putResp = null;
            client.DefaultRequestHeaders.Clear();
            if (need_credentials)
            {
                client.DefaultRequestHeaders.Add("email", Email);
                client.DefaultRequestHeaders.Add("password", Password);
            }
            try
            {
                putResp = await client.PutAsync(url, body);
                result = putResp.IsSuccessStatusCode ? ServerResponse.Connected : ServerResponse.ServerFailure;
            }
            catch
            {
                result = ServerResponse.NotConnected;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, putResp);
        }
    }
}
