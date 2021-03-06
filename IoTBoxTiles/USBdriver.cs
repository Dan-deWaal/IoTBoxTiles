﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagePack;
using System.Runtime.InteropServices;

namespace IoTBoxTiles
{
    public class USBdriver
    {
        /*[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);*/

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;

        private TcpClient _TcpClient;
        private NetworkStream _netStream;
        private SslStream _ssl;
        private bool running;

        public USBdriver(string server, int port)
        {
            Console.WriteLine("USB Driver Thread Started.");
            _TcpClient = new TcpClient();
            var result = _TcpClient.BeginConnect(server, port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
            if (!success)
            {
                Console.WriteLine("Failed to connect to device");
                running = false;
            }
            else
            {
                Console.WriteLine("Connecting to device  {0}:{1}", server, port);
                _TcpClient.EndConnect(result);
                _netStream = _TcpClient.GetStream();
                _ssl = new SslStream(_TcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateCert));
                _ssl.AuthenticateAsClient("iot.duality.co.nz");
                running = true;
            }
        }

        public static bool ValidateCert(object sender, X509Certificate certificate,
              X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true; // Allow untrusted certificates.
        }

        [MessagePackObject]
        public class USBData
        {
            [Key(0)]
            public int x { get; set; }

            [Key(1)]
            public int y { get; set; }

            [Key(2)]
            public int mb { get; set; }
            //1 = lmb_down, 2 = lmb_up, 3 = rmb_down, 4 = rmb_up

            [Key(3)]
            public int scroll { get; set; }

            [Key(4)]
            public byte key { get; set; }

            [Key(5)]
            public bool down { get; set; }

            [Key(6)]
            public string eof { get; set; }
        }

        public void LMBDown()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        }

        public void LMBUp()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public void RMBDown()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
        }

        public void RMBUp()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        public void listen()
        {
            bool lmb_click_dwn = false, lmb_click_up = true, rmb_click_dwn = false, rmb_click_up = true;
            try
            {
                while (running)
                {
                    //Listening for data
                    int LMB_DWN = 128, RMB_DWN = 64; // SCROLL_DWN = 32;
                    int dataread = 0;
                    byte[] buffer = new byte[3];
                    List<byte> message = new List<byte>();
                    do
                    {
                        dataread += _ssl.Read(buffer, dataread, buffer.Length-dataread);
                    } while (dataread < 3);
                    
                    //update cursor from data
                    Cursor.Position = new Point(Cursor.Position.X+buffer[1],Cursor.Position.Y+buffer[2]);
                    
                    // LMB
                    if ((buffer[0] & LMB_DWN) != 0)
                    {
                        if (!lmb_click_dwn)
                        {
                            lmb_click_dwn = true;
                            lmb_click_up = false;
                            LMBDown();
                        }
                    }
                    else
                    {
                        if (!lmb_click_up)
                        {
                            lmb_click_dwn = false;
                            lmb_click_up = true;
                            LMBUp();
                        }
                    }

                    // RMB
                    if ((buffer[0] & RMB_DWN) != 0)
                    {
                        if (!rmb_click_dwn)
                        {
                            rmb_click_dwn = true;
                            rmb_click_up = false;
                            RMBDown();
                        }
                    }
                    else
                    {
                        if (!rmb_click_up)
                        {
                            rmb_click_dwn = false;
                            rmb_click_up = true;
                            RMBUp();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                running = false;
            }
            finally
            {
                if (_ssl != null)
                {
                    _ssl.Close();
                    _netStream.Close();
                    _TcpClient.Close();
                    Console.WriteLine("Closed Socket");
                }
                Console.WriteLine("USB Driver Thread Closed.");
            }
        }
        
    }
}
