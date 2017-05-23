using System;
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

namespace IoTBoxTiles
{
    class USBdriver
    {
        private Point _cursor = new Point(0, 0);
        private string _keys;
        private TcpClient _TcpClient;
        private NetworkStream _netStream;
        private SslStream _ssl;
        private bool running;

        public USBdriver(string server, int port)
        {
            Console.WriteLine("USB Driver Started.");
            _TcpClient = new TcpClient(server, port);
            _netStream = _TcpClient.GetStream();
            _ssl = new SslStream(_TcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateCert));
            _ssl.AuthenticateAsClient("iot.duality.co.nz");
            running = true;
        }

        public static bool ValidateCert(object sender, X509Certificate certificate,
              X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true; // Allow untrusted certificates.
        }

        public void listen()
        {
            try
            {
                while (running)
                {
                    //Listening for data
                    if (_ssl.CanRead)
                    {
                        //get data
                        byte[] buffer = new byte[2];
                        _ssl.Read(buffer, 0, 2);
                        Console.WriteLine("buffer size: " + buffer.Length);
                        foreach (var data in buffer)
                        {
                            Console.WriteLine(data.ToString());
                        }
                    }
                    //update cursor from data
                    //update key from data
                    //Cursor.Position = _cursor;
                    //SendKeys.Send(_keys); // or //SendKeys.SendWait(_keys);

                    //Maybe send back feedback, such as CAPSLOCK, NUMLOCK, etc
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                running = false;
            }
            finally
            {
                _ssl.Close();
                _netStream.Close();
                _TcpClient.Close();
                Console.WriteLine("Closed Socket");
            }
        }
        
    }
}
