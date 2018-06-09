using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicomImageViewer
{
    public partial class ServerFrm : Form
    {
        public ServerFrm()
        {
            InitializeComponent();
            Server.path = "";
        }
        public static string path;
        public static string messageCurrent = "Stopped";
        private void ServerFrm_Load(object sender, EventArgs e)
        {
            //Application.StartupPath
            Server.path = "C:\\Users\\hp\\Desktop";
            if (Server.path.Length > 0)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Cannot received!");
            }
        }
        Server sv = new Server();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            sv.StartServer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblContent.Text = Server.MessageCurrent + Environment.NewLine + Server.path;
        }
    }
}
