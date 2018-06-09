using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DicomImageViewer
{
    class Server
    {
        IPEndPoint iEndPoint;
        Socket soc;
        public Server()
        {
            //IPAddress ip = IPAddress.Parse("169.254.136.119");
            iEndPoint = new IPEndPoint(IPAddress.Any, 8888);
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            soc.Bind(iEndPoint);
        }
        public static string path;
        public static string MessageCurrent = "Stopped";
        public void StartServer()
        {
            try
            {
                MessageCurrent = "Starting server...";
                soc.Listen(50);
                MessageCurrent = "Looking for files";
                Socket clientSocket = soc.Accept();
                byte[] clientData = new byte[1024 * 9000];
                int receiveByteLen = clientSocket.Receive(clientData);
                MessageCurrent = "Receiving...";
                int fnameLen = BitConverter.ToInt32(clientData, 0);
                string fname = Encoding.ASCII.GetString(clientData, 4, fnameLen);
                BinaryWriter write = new BinaryWriter(File.Open(path + "/" + fname, FileMode.Append));
                write.Write(clientData, 4 + fnameLen, receiveByteLen - 4 - fnameLen);
                MessageCurrent = "Saving..";
                write.Close();
                clientSocket.Close();
                MessageCurrent = "Received file";
            }
            catch (Exception)
            {
                MessageCurrent = "Error!. Cannot received!";
                throw;
            }
        }
    }
}
