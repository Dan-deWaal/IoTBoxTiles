using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
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
        private SslStream _SslStream;
        private bool nodata;

        public USBdriver(string server, int port)
        {
            Console.WriteLine("USB Driver Started.");
            Console.WriteLine("Socket created: {0} : {1}", server, port);
            _TcpClient = new TcpClient(server, port);
            //_SslStream = new SslStream(_TcpClient.GetStream());
            //_SslStream.AuthenticateAsClient("iot.duality.co.nz");
        }
        
        public void listen()
        {
            try
            {
                while (true)
                {
                    //Console.WriteLine("Listening for data");
                    //update cursor from data
                    if (_TcpClient.GetStream().DataAvailable)
                    {
                        byte[] buffer = new byte[2];
                        _TcpClient.GetStream().Read(buffer, 0, 2);
                        Console.WriteLine(buffer);
                        nodata = false;
                    } else
                    {
                        if (!nodata)
                        {
                            Console.WriteLine("no data");
                        }
                        nodata = true;
                    }
                    
                    //update key from data
                    //Cursor.Position = _cursor;
                    //SendKeys.Send(_keys); // or //SendKeys.SendWait(_keys);

                    //Maybe send back feedback, such as CAPSLOCK, NUMLOCK, etc
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine("Close Socket");
            }
        }
        
    }
}
