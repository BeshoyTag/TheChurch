using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace MegaTalentService
{
    public partial class PeopleSearch : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
        public PeopleSearch()
        {

            InitializeComponent();

            dataGridView1.Hide();

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox3.DisplayRectangle);
            pictureBox3.Region = new Region(gp);
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        void ColumnsSize()
        {
            dataGridView1.Columns[0].Width = 220;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 280;
            dataGridView1.Columns[8].Width = 300;
            dataGridView1.Columns[9].Width = 220;
            dataGridView1.Columns[10].Width = 220;
            dataGridView1.Columns[11].Width = 200;
            dataGridView1.Columns[12].Width = 120;
            dataGridView1.Columns[13].Width = 200;
            dataGridView1.Columns[14].Width = 300;
            dataGridView1.Columns[15].Width = 700;
            dataGridView1.Columns[16].Width = 200;
            dataGridView1.Columns[17].Width = 300;
            dataGridView1.Columns[18].Width = 300;
            dataGridView1.Columns[19].Width = 300;
            dataGridView1.Columns[20].Width = 380;
            dataGridView1.Columns[21].Width = 800;


        }

        private void AddServiceCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =

                ($@"[الأسم] LIKE'%{(textBox1.Text)}%'   
                    OR [رقم التليفون]lIKE '%{textBox1.Text}%'
                       OR[رقم التليفون الارضي]lIKE '%{textBox1.Text}%'
                            OR [الكنيسة]lIKE '%{textBox1.Text}%'
                                OR[رقم البحث]lIKE '%{textBox1.Text}%'
                                  OR [المرحلة التعليميه]lIKE '%{textBox1.Text}%'
                                     OR [المؤهل الدراسي]lIKE '%{textBox1.Text}%'
                                        OR [الخادم المسؤال]lIKE '%{textBox1.Text}%'
                                            OR[الايميل]lIKE '%{textBox1.Text}%'
                                               OR [الاب الكاهن]lIKE '%{textBox1.Text}%'
                                                  OR [الاجتماع التابع له] LIke '%{textBox1.Text}%'
                                                    OR [المحافظة]lIKE '%{textBox1.Text}%'
                                                         OR [الكنيسة]lIKE '%{textBox1.Text}%'
        ");
        }

        private void PeopleSearch_Load(object sender, EventArgs e)
        {

            timer1.Start();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cboDevice.Items.Add(Device.Name);

            cboDevice.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();

            this.dataGridView1.RightToLeft = RightToLeft.Yes;
            DataTable dtt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
          cmd.CommandText = "select * from dbo.Personview";
            con.Open();

            
            dtt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dtt;
            con.Close();
            dataGridView1.DataSource = dtt;
        }

        private void OpenCamBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            textBox1.Text = "";
            pictureBox3.Visible = true;
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += CaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            //pictureBox3.Image = (Bitmap)eventArgs.Frame.Clone();
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "إبحث عن مخدوم ما بإستخدام بياناته")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Aqua;
                dataGridView1.Visible = true;
                ColumnsSize();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "إبحث عن مخدوم ما بإستخدام بياناته";
                textBox1.ForeColor = Color.Gray;
                dataGridView1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                BarcodeReader Reader = new BarcodeReader();
                Result result = Reader.Decode((Bitmap)pictureBox3.Image);
                if (result != null)
                {
                    textBox1.Text = result.ToString();
                    //timer1.Stop();
                    if (videoCaptureDevice.IsRunning == true)
                    {
                        videoCaptureDevice.Stop();
                        pictureBox3.Image = null;
                        pictureBox3.Hide();
                        textBox1.ForeColor = Color.Aqua;
                        dataGridView1.Visible = true;
                        ColumnsSize();

                    }

                }
            }
        }



        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox3.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void PeopleSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (videoCaptureDevice.IsRunning == true)
                //videoCaptureDevice.Stop();

        }
    }
}
