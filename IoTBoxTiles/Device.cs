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
    }

    public class IndDevice
    {
        //Global Properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public int device_id { get; set; }
        public DateTime first_connected { get; set; }
        public string friendly_name { get; set; }
        public string ip_address { get; set; } //convert to IP datatype be better?
        public DateTime last_checked { get; set; }
        public int module_type { get; set; }
        public int? port { get; set; }
        public int user_id { get; set; }
        public bool plug_status { get; set; } //nullable int
        public float? current_consumption { get; set; } //nullable float
    }

    public class SmartPlug : IndDevice
    {
        //unique properties

        public SmartPlug()
        {

        }
    }

    public class Bluetooth : IndDevice
    {
        //unique properties
        public bool conn { get; set; }

        public Bluetooth()
        {

        }
    }

    public class USB : IndDevice
    {
        //unique properties
        public bool conn { get; set; }

        public USB()
        {

        }
    }

    public class Infrared : IndDevice
    {
        //unique properties
        //public List<Tuple> buttons(string_name, string_code, bool_quick) { get; set; }
        public bool repeater { get; set; }
        public bool feedback { get; set; }
        
        public Infrared()
        {

        }
    }

    public class Industrial : IndDevice
    {
        //unique properties
        public bool conn { get; set; }
        public int com_port { get; set; }
        public string com_settings { get; set; }
        public List<string> ser_mon { get; set; }

        public Industrial()
        {

        }
    }

    public class Multiboard : IndDevice
    {
        //unique properties
        //public List<Tuple> buttons(string_name, bool_power, float_curr) { get; set; }
        public bool repeater { get; set; }
        public bool feedback { get; set; }

        public Multiboard()
        {

        }
    }

    public class Audio : IndDevice
    {
        //unique properties
        public bool connect_speaker { get; set; }
        public bool connect_mic { get; set; }
        public float[] audioVUChannel { get; set; }
        public string IoTBoxAudio { get; set; }
        public string SIPServer { get; set; }

        public Audio()
        {

        }
    }

    public class Err
    {
        public string error { get; set; }
    }
}
