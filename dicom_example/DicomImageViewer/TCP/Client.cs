using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;

namespace DicomImageViewer
{
    class Client
    {
        public static string MessageCurrent = "Waitting server and files...";
        public static void Sendfile(string fname)
        {
            try
            {
                //IPAddress ip = IPAddress.Parse("192.168.0.106");//171.224.92.215
                // IPAddress ip = IPAddress.Parse("171.224.92.215");
                IPAddress ip = IPAddress.Parse("192.168.1.12");
                IPEndPoint iEndPoint = new IPEndPoint(ip, 8888);
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                string path = "";
                fname = fname.Replace("\\", "/");
                while (fname.IndexOf("/") > -1)
                {
                    path += fname.Substring(0, fname.IndexOf("/") + 1);
                    fname = fname.Substring(fname.IndexOf("/") + 1);
                }
                byte[] fnameByte = Encoding.ASCII.GetBytes(fname);
                MessageCurrent = "Buffering...";
                byte[] fileData = File.ReadAllBytes(path + fname);
                byte[] clientData = new byte[4 + fnameByte.Length + fileData.Length];
                byte[] fnameLen = BitConverter.GetBytes(fnameByte.Length);
                fnameLen.CopyTo(clientData, 0);
                fnameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fnameByte.Length);
                MessageCurrent = "Connect to Server...";
                soc.Connect(iEndPoint);
                MessageCurrent = "Transferring...";
                soc.Send(clientData);
                soc.Close();
                MessageCurrent = "Sent file.";
            }
            catch (Exception ex)
            {

            }
        }
    }
}
