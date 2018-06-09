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
    public partial class ClientFrm : Form
    {
        public ClientFrm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Client.Sendfile(fd.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblContent.Text = Client.MessageCurrent;
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            serverRun();
        }
        bool isrunning = false;
        private void serverRun()
        {
            ServerFrm sf = new ServerFrm();
            isrunning = !isrunning;
            if (isrunning)
            {
                btnOpenServer.Text = "Stop";
                sf.Show();
                btnOpenServer.Enabled = false;
            }
            else
            {
                btnOpenServer.Text = "Open";
                sf.Close();
            }
        }
    }
}
