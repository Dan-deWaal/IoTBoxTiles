﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles
{
    public class DeviceBase
    {
        // initial data
        public int device_id { get; set; }
        public string friendly_name { get; set; }
        public int module_type { get; set; }
        public bool online { get; set; }
        public string url { get; set; }
    }

    public class Err
    {
        public string error { get; set; }
    }
}
