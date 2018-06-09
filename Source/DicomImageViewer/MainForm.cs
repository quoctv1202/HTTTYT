using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace DicomImageViewer
{
    public enum ImageBitsPerPixel { Eight, Sixteen, TwentyFour };
    public enum ViewSettings { Zoom1_1, ZoomToFit };
    public partial class MainForm : Form
    {
        DicomDecoder dd;
        List<byte> pixels8;
        List<ushort> pixels16;
        List<byte> pixels24;
        int imageWidth;
        int imageHeight;
        int bitDepth;
        int samplesPerPixel;
        bool imageOpened;
        double winCentre;
        double winWidth;
        bool signedImage;
        int maxPixelValue; 
        int minPixelValue;

        public MainForm()
        {
            InitializeComponent();
            dd = new DicomDecoder();
            pixels8 = new List<byte>();
            pixels16 = new List<ushort>();
            pixels24 = new List<byte>();
            imageOpened = false;
            signedImage = false;
            maxPixelValue = 0;
            minPixelValue = 65535;
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All DICOM Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    ReadAndDisplayDicomFile(ofd.FileName, ofd.SafeFileName);
                    imageOpened = true;
                    Cursor = Cursors.Default;
                }
                ofd.Dispose();
            }
        }

        private void ReadAndDisplayDicomFile(string fileName, string fileNameOnly)
        {
            dd.DicomFileName = fileName;

            TypeOfDicomFile typeOfDicomFile = dd.typeofDicomFile;

            if (typeOfDicomFile == TypeOfDicomFile.Dicom3File ||
                typeOfDicomFile == TypeOfDicomFile.DicomOldTypeFile)
            {
                imageWidth = dd.width;
                imageHeight = dd.height;
                bitDepth = dd.bitsAllocated;
                winCentre = dd.windowCentre;
                winWidth = dd.windowWidth;
                samplesPerPixel = dd.samplesPerPixel;
                signedImage = dd.signedImage;
                bnTags.Enabled = true;
                imagePanelControl.NewImage = true;
                Text = "DICOM Image Viewer: " + fileNameOnly;

                if (samplesPerPixel == 1 && bitDepth == 8)
                {
                    pixels8.Clear();
                    pixels16.Clear();
                    pixels24.Clear();
                    dd.GetPixels8(ref pixels8);
                    minPixelValue = pixels8.Min();
                    maxPixelValue = pixels8.Max();
                    if (dd.signedImage)
                    {
                        winCentre -= char.MinValue;
                    }

                    if (Math.Abs(winWidth) < 0.001)
                    {
                        winWidth = maxPixelValue - minPixelValue;
                    }

                    if ((winCentre == 0) ||
                        (minPixelValue > winCentre) || (maxPixelValue < winCentre))
                    {
                        winCentre = (maxPixelValue + minPixelValue) / 2;
                    }

                    imagePanelControl.SetParameters(ref pixels8, imageWidth, imageHeight,
                        winWidth, winCentre, samplesPerPixel, true, this);
                }

                if (samplesPerPixel == 1 && bitDepth == 16)
                {
                    pixels16.Clear();
                    pixels8.Clear();
                    pixels24.Clear();
                    dd.GetPixels16(ref pixels16);
                    minPixelValue = pixels16.Min();
                    maxPixelValue = pixels16.Max();
                    if (dd.signedImage)
                    {
                        winCentre -= short.MinValue;
                    }

                    if (Math.Abs(winWidth) < 0.001)
                    {
                        winWidth = maxPixelValue - minPixelValue;
                    }

                    if ((winCentre == 0) ||
                        (minPixelValue > winCentre) || (maxPixelValue < winCentre))
                    {
                        winCentre = (maxPixelValue + minPixelValue) / 2;
                    }

                    imagePanelControl.Signed16Image = dd.signedImage;

                    imagePanelControl.SetParameters(ref pixels16, imageWidth, imageHeight,
                        winWidth, winCentre, true, this);
                }

                if (samplesPerPixel == 3 && bitDepth == 8)
                {
                    // This is an RGB colour image
                    pixels8.Clear();
                    pixels16.Clear();
                    pixels24.Clear();
                    dd.GetPixels24(ref pixels24);
                    imagePanelControl.SetParameters(ref pixels24, imageWidth, imageHeight,
                        winWidth, winCentre, samplesPerPixel, true, this);
                }
            }
            else 
            {
                if (typeOfDicomFile == TypeOfDicomFile.DicomUnknownTransferSyntax)
                {
                    MessageBox.Show("Xin lỗi, File DiCOM này không thể mở!",
                        "Chú Ý !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Xin lỗi, File này không tồn tại ảnh",
                        "Chú Ý !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Text = "DICOM Image Viewer: ";
                // Show a plain grayscale image instead
                pixels8.Clear();
                pixels16.Clear();
                pixels24.Clear();
                samplesPerPixel = 1;

                imageWidth = imagePanelControl.Width - 25;   // 25 is a magic number
                imageHeight = imagePanelControl.Height - 25; // Same magic number
                int iNoPix = imageWidth * imageHeight;

                for (int i = 0; i < iNoPix; ++i)
                {
                    pixels8.Add(240);// 240 is the grayvalue corresponding to the Control colour
                }
                winWidth = 256;
                winCentre = 127;
                imagePanelControl.SetParameters(ref pixels8, imageWidth, imageHeight,
                    winWidth, winCentre, samplesPerPixel, true, this);
                imagePanelControl.Invalidate();
                //bnSave.Enabled = false;
                bnTags.Enabled = false;
            }

            List<string> lstString = dd.dicomInfo;
            SetString(ref lstString);
        }

        private void bnTags_Click(object sender, EventArgs e)
        {
            if (imageOpened == true)
            {
                List<string> str = dd.dicomInfo;

                DicomTagsForm dtg = new DicomTagsForm();
                dtg.SetString(ref str);
                dtg.ShowDialog();
                imagePanelControl.Invalidate();
            }
            else
                MessageBox.Show("Vui lòng mở file DICOM trước khi xem Tags!", "Chú Ý !!!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        List<string> lstStr;
        public void SetString(ref List<string> strg)
        {
            

            lstStr = strg;
            string id, name, dob, sex, add, phone, bodypart;
            string s4, s5, s11, s12;

            id = lstStr[26];
            ExtractStrings(id, out s4, out s5, out s11, out s12);
            txtID.Text = s5;

            name = lstStr[25];
            ExtractStrings(name, out s4, out s5, out s11, out s12);
            txtName.Text = s5;

            dob = lstStr[27];
            ExtractStrings(dob, out s4, out s5, out s11, out s12);
            txtDOB.Text = s5;

            sex = lstStr[28];
            ExtractStrings(sex, out s4, out s5, out s11, out s12);
            txtSex.Text = s5;

            add = lstStr[29];
            ExtractStrings(add, out s4, out s5, out s11, out s12);
            txtAddr.Text = s5;

            phone = lstStr[30];
            ExtractStrings(phone, out s4, out s5, out s11, out s12);
            txtPhone.Text = s5;

            bodypart = lstStr[32];
            ExtractStrings(bodypart, out s4, out s5, out s11, out s12);
            txtBodyPart.Text = s5;

            //txtName.Text = lstStr[25];
            //txtDOB.Text = lstStr[27];
            //txtSex.Text = lstStr[28];
            //txtAddr.Text = lstStr[29];
            //txtPhone.Text = lstStr[20];
            //txtBodyPart.Text = lstStr[32];
            ////// Add items to the List View Control
            ////for (int i = 0; i < lstStr.Count; ++i)
            ////{
            ////    s1 = lstStr[i];
            ////    ExtractStrings(s1, out s4, out s5, out s11, out s12);

            ////    ListViewItem lvi = new ListViewItem(s11);
            ////    lvi.SubItems.Add(s12);
            ////    lvi.SubItems.Add(s4);
            ////    lvi.SubItems.Add(s5);
            ////    //listView.Items.Add(lvi);
            ////}
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtDOB.Enabled = false;
            txtSex.Enabled = false;
            txtPhone.Enabled = false;
            txtBodyPart.Enabled = false;
            txtAddr.Enabled = false;
        }


        void ExtractStrings(string s1, out string s4, out string s5, out string s11, out string s12)
        {
            int ind;
            string s2, s3;
            ind = s1.IndexOf("//");
            s2 = s1.Substring(0, ind);
            s11 = s1.Substring(0, 4);
            s12 = s1.Substring(4, 4);
            s3 = s1.Substring(ind + 2);
            ind = s3.IndexOf(":");
            s4 = s3.Substring(0, ind);
            s5 = s3.Substring(ind + 1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pixels8.Clear();
            pixels16.Clear();
            if (imagePanelControl != null) imagePanelControl.Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ClientFrm cf = new ClientFrm();
            cf.Show();
        }

        private void imagePanelControl_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddr.Enabled = true;
            txtID.Enabled = true;
            txtName.Enabled = true;
            txtSex.Enabled = true;
            txtPhone.Enabled = true;
            txtBodyPart.Enabled = true;
            txtDOB.Enabled = true;
         
        }
    }
}