﻿using System;
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
        private static readonly Lazy<ServerComm> lazy =
            new Lazy<ServerComm>(() => new ServerComm());
        public static ServerComm Instance { get { return lazy.Value; } }

        private HttpClient client;
        public string Root { get; set; }
        public string Heartbeat { get; set; }
        public string Login { get; set; }
        public string Details { get; set; }
        public string Email { private get;  set; }
        public string Password { private get; set; }

        private ServerComm() {
            client = new HttpClient();
            Root = @"https://iot.duality.co.nz/api/1";
            Heartbeat = Root + @"/heartbeat";
            Login = Root + @"/user/devices/list";
            Details = Root + @"/user/devices/details";
        }
        
        public async Task<Tuple<int, HttpResponseMessage>> GetAsync(
            string url, bool need_credentials = true)
        {
            int result = 0;
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
                result = getResponse.IsSuccessStatusCode ? 1 : 2;
            }
            catch
            {
                result = 0;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, getResponse);
        }
        
        public async Task<Tuple<int, HttpResponseMessage>> PostAsync(string url, 
            HttpContent body = null, bool need_credentials = true)
        {
            int result = 0;
            HttpResponseMessage postResponse = null;
            client.DefaultRequestHeaders.Clear();
            if (need_credentials)
            {
                client.DefaultRequestHeaders.Add("email", Email);
                client.DefaultRequestHeaders.Add("password", Password);
            }
            try
            {
                postResponse = await client.PostAsync(url, body);
                result = postResponse.IsSuccessStatusCode ? 1 : 2;
            }
            catch
            {
                result = 0;
            }
            //result:  0 = Not Connected,  1 = Connected,  2 = Server Failure.
            return Tuple.Create(result, postResponse);
        }
    }
}
