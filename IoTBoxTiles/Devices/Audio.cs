﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    class Audio : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public bool speaker_status { get; set; }
        public bool mic_status { get; set; }
        public float speaker_VU { get; set; }
        public float mic_VU { get; set; }

        public Audio()
        {
            TableLayoutPanel tableSmall = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            tableSmall.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 2);
            tableSmall.Controls.Add(new CheckBox() { Name = "Speaker", Text = "Speaker" }, 0, 3);
            tableSmall.Controls.Add(new CheckBox() { Name = "Mic", Text = "Mic" }, 1, 3);
            tableSmall.Controls.Add(new Label() { Name = "SpkrVU", Text = "Speaker VU: " }, 0, 4);
            tableSmall.Controls.Add(new Label() { Name = "MicVU", Text = "Mic VU: " }, 1, 4);
            TableLayoutPanel tableLarge = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            tableLarge.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 5);
            tableLarge.Controls.Add(new Label() { Name = "Client", Text = "client_id: " }, 0, 6);
            tableLarge.Controls.Add(new Label() { Name = "IP", Text = "IP: " }, 0, 7);
            tableLarge.Controls.Add(new Label() { Name = "Port", Text = "port: " }, 1, 7);
            tableLarge.Controls.Add(new CheckBox() { Name = "Speaker", Text = "Speaker" }, 0, 8);
            tableLarge.Controls.Add(new CheckBox() { Name = "Mic", Text = "Mic" }, 1, 8);
            tableLarge.Controls.Add(new Label() { Name = "SpkrVU", Text = "Speaker VU: " }, 0, 9);
            tableLarge.Controls.Add(new Label() { Name = "MicVU", Text = "Mic VU: " }, 1, 9);
        }

        public void updateLargeUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            updateLargeCommonUI(table);
            updateLargeConnectUI(table, client_id, ip_address, port);
            CheckBox spkr_cb = (CheckBox)table.Controls.Find("Speaker", true).First();
            spkr_cb.Checked = speaker_status;
            CheckBox mic_cb = (CheckBox)table.Controls.Find("Mic", true).First();
            mic_cb.Checked = mic_status;
            Label svu_lbl = (Label)table.Controls.Find("SpkrVU", true).First();
            svu_lbl.Text = "Speaker VU: " + speaker_VU.ToString();
            Label mvu_lbl = (Label)table.Controls.Find("MicVU", true).First();
            mvu_lbl.Text = "Mic VU: " + speaker_VU.ToString();
        }

        public void updateSmallUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            updateSmallCommonUI(table);
            updateSmallConnectUI(table);
            CheckBox spkr_cb = (CheckBox)table.Controls.Find("Speaker", true).First();
            spkr_cb.Checked = speaker_status;
            CheckBox mic_cb = (CheckBox)table.Controls.Find("Mic", true).First();
            mic_cb.Checked = mic_status;
            Label svu_lbl = (Label)table.Controls.Find("SpkrVU", true).First();
            svu_lbl.Text = "Speaker VU: " + speaker_VU.ToString();
            Label mvu_lbl = (Label)table.Controls.Find("MicVU", true).First();
            mvu_lbl.Text = "Mic VU: " + speaker_VU.ToString();
        }
    }
}