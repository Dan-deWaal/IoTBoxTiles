using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles
{
    public class Device
    {
        //Initial Data
        public bool connected { get; set; }
        public int device_id { get; set; }
        public string friendly_name { get; set; }
        public int module_type { get; set; }
        public bool online { get; set; }
        public string url { get; set; }

        //local IP
        //local Port


        //Unconnected (non-realtime) Data
        public bool power { get; set; }
        public bool spkrconn { get; set; }
        public bool micconn { get; set; }
        public string IoTBoxAudio { get; set; }
        public string SIPServer { get; set; }
        public bool[] multipower { get; set; }
        public string[] multiname { get; set; }
        public int comPort { get; set; }
        public string monitorSettings { get; set; }
        
        //Connected (realtime) Data
        public float current { get; set; }
        public float[] multicurrent { get; set; }
        public float[] audioVUChannel { get; set; }
        public string[] serialMonitor { get; set; }

    }

    public class Err
    {
        public string error { get; set; }
    }
}
