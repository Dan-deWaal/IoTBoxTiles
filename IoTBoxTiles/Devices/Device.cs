using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Drawing;
using IoTBoxTiles.Devices.Controls.Parts;
using Newtonsoft.Json;

namespace IoTBoxTiles.Devices
{
    public enum DisplayStates {None, Small, Large};
    public class Device : DeviceBase
    {
        private ServerComm _serverComm = ServerComm.Instance;
        private System.Windows.Forms.Timer _timer;
        private int pollCounter;

        public bool SameDevice(object o)
        {
            JObject dev = o as JObject;
            if (dev == null)
                throw new ArgumentException("device is not castable to JObject");

            if ((int)dev["device_id"] == device_id
                && (int)dev["module_type"] == module_type)
                return true;
            return false;
        }

        //Global Properties
        public DateTime first_connected { get; set; }
        public DateTime last_checked { get; set; }
        public bool plug_status { get; set; }
        public int? current_consumption { get; set; } // nullable float

        //UI Elements
        public Control UI_small { get; set; }
        public Control UI_large { get; set; }
        public DisplayStates DisplayState;

        // constructors
        public Device()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 2000;
            _timer.Tick += ServerPolling;
        }

        public Device(DeviceBase old_device) : this()
        {
            device_id = old_device.device_id;
            friendly_name = old_device.friendly_name;
            module_type = old_device.module_type;
            online = old_device.online;
            url = old_device.url;

            CreateDevice();
        }

        // convert from JSON.net 'JObject'
        // gross but necessary unless we restructure the JSON response
        public Device(JObject device) : this()
        {
            UpdateDevice(device);
            CreateDevice();
        }

        public Device(Device old_device) : this()
        {
            // from device base
            device_id = old_device.device_id;
            friendly_name = old_device.friendly_name;
            module_type = old_device.module_type;
            online = old_device.online;
            url = old_device.url;

            // from full device object
            first_connected = old_device.first_connected;
            last_checked = old_device.last_checked;
            plug_status = old_device.plug_status;
            current_consumption = old_device.current_consumption;

            CreateDevice();
        }

        public async Task<Tuple<ServerResponse, HttpResponseMessage>> ServerRequest()
        {
            var pollresult = new Tuple<ServerResponse, HttpResponseMessage>(ServerResponse.ServerFailure, null);

            //Send a request to the server for Device Info
            string request = JsonConvert.SerializeObject(new RequestInfo
            {
                localIP = _serverComm.GetLocalIPAddress(),
                hostname = _serverComm.GetNETBIOSName()
            });
            StringBuilder deviceUri = new StringBuilder(_serverComm.Root);
            deviceUri.Append("/device/");
            deviceUri.Append(device_id);
            deviceUri.Append("/connect");
            var result = await _serverComm.PostAsync(deviceUri.ToString(),
                new StringContent(request), contentType: "application/json");
            if (result.Item1 != ServerResponse.Connected)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
            }
            else
            {
                //successful request
                _timer.Start();
                pollCounter = 0;
                int prevPollCounter = -1;
                deviceUri.Append("/status");
                do
                {
                    if (pollCounter != prevPollCounter)
                    {
                        prevPollCounter = pollCounter;
                        pollresult = await _serverComm.GetAsync(deviceUri.ToString(), true);
                        Console.WriteLine("Server Poll #{0} result: {1}", pollCounter, pollresult.Item1);
                    }
                } while (pollCounter < 10 && pollresult.Item1 != ServerResponse.Connected);
            }

            return pollresult;
        }

        public void ServerPolling(object sender, EventArgs e)
        {
            pollCounter++;
        }

        public class RequestInfo
        {
            public string localIP;
            public string hostname;
        }

        public class ConnectionDetail
        {
            public string status;
            public Details details;
            public class Details
            {
                public string ip_address;
                public int port;
                public string error_message;
            }
            //NAT traversal will add more properties
        }

        public virtual void UpdateDevice(JObject device)
        {
            device_id = (int)device["device_id"];
            friendly_name = (string)device["friendly_name"];
            module_type = (int)device["module_type"];
            online = (bool)device["online"];
            url = (string)device["url"];

            first_connected = (DateTime)device["first_connected"];
            last_checked = (DateTime)device["last_checked"];
            plug_status = (bool)device["plug_status"];
            current_consumption = (int?)device["current_consumption"];
        }

        public virtual void CreateDevice()
        {
        }

        public void UpdateUI()
        {
            UpdateLargeUI();
            UpdateSmallUI();
        }

        public virtual void UpdateLargeUI() { }
        public virtual void UpdateSmallUI() { }

        public void AddSmallUI(UserControl newSmall)
        {
            UI_small = new Panel()
            {
                Name = "UISmallPanel",
                Width = 270,
                Height = 200,
                MinimumSize = new Size(270, 200),
                BorderStyle = BorderStyle.None,
                BackColor = System.Drawing.SystemColors.Control
            };
            newSmall.BorderStyle = BorderStyle.None;
            newSmall.BackColor = Color.FromArgb(235, 235, 235);
            newSmall.Dock = DockStyle.Fill;
            newSmall.Padding = new Padding(3);
            UI_small.Controls.Add(newSmall);
        }

        public void AddLargeUI(UserControl newLarge)
        {
            newLarge.Name = "UILarge";
            newLarge.BorderStyle = BorderStyle.None;
            newLarge.BackColor = Color.FromArgb(235, 235, 235);
            newLarge.Margin = new Padding(1);
            newLarge.Padding = new Padding(3);
            newLarge.AutoScroll = true;

            UI_large = newLarge;
        }
        
        public async void ChangePowerAsync(PlugTitle pt)
        {
            if (pt.Refreshing)
                return;

            pt.Refreshing = true;

            StringBuilder deviceUri = new StringBuilder(_serverComm.Root);
            deviceUri.Append("/device/");
            deviceUri.Append(device_id);
            deviceUri.Append("/power");
            if (pt.PowerChecked)
                deviceUri.Append("/on");
            else
                deviceUri.Append("/off");

            var response = await _serverComm.PostAsync(deviceUri.ToString());

            pt.Refreshing = false;

            if (response.Item1 != ServerResponse.Connected)
            {
                pt.PowerChecked = !pt.PowerChecked;
                MessageBox.Show("Problem switching plug " + (!pt.PowerChecked ? "on." : "off."));
            }
        }
    }
}
