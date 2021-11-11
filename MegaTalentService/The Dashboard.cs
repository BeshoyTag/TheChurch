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
    public partial class The_Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public The_Dashboard()
        {
            InitializeComponent();

            dataGridView1.Hide();
            label6.Hide();
            comboBox1.Hide();
            label5.Hide();
            dateTimePicker1.Hide();
            SaveBtn.Hide();
            pictureBox3.Hide();
            label7.Hide();
            textBox1.Hide();
          
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox3.DisplayRectangle);
            pictureBox3.Region = new Region(gp);
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void The_Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cboDevice.Items.Add(Device.Name);

            //  pictureBox3.Items.Add(Device.Name);
            cboDevice.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();


          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();

            //

            if (pictureBox3.Image != null)
            {
                BarcodeReader Reader = new BarcodeReader();
                Result result = Reader.Decode((Bitmap)pictureBox3.Image);
                if (result != null)
                {   
                    textBox2.Text = result.ToString();
                    //timer1.Stop();
                        if (videoCaptureDevice.IsRunning == true)
                        { 
                          videoCaptureDevice.Stop();
                          pictureBox3.Image = null;
                          pictureBox3.Hide();
                        textBox2.ForeColor = Color.Aqua;


                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void DashboardCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {

        }

        private void OpenCamBtn_Click(object sender, EventArgs e)
        {
            // textBox2.Clear();
            textBox2.Text = "";
            pictureBox3.Visible = true;

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += CaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {     
               pictureBox3.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            DataTable dtKhadma = new DataTable();
            SqlDataAdapter daKhadma = new SqlDataAdapter("select ServiceID as ID,Name from ProfileServices inner join service on service.ID = ProfileServices.ServiceID where BarCode ='" + textBox2.Text + "' ", con);
            daKhadma.Fill(dtKhadma);
            comboBox1.DataSource = dtKhadma;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            con.Open();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string query =
            "Select * from Person WHERE BarCode='" + textBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);

            //dataGridView1.DataSource = dt;

            object obj = cmd.ExecuteScalar();

            if (Convert.ToInt32(obj) > 0 && !String.IsNullOrEmpty(textBox2.Text))
            {
                
                dataGridView1.Visible = true;
                label6.Visible = true;
                comboBox1.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = true;
                SaveBtn.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                pictureBox3.Visible = false;
            }
            else
            {
                dataGridView1.Hide();
                label6.Hide();
                comboBox1.Hide();
                label5.Hide();
                dateTimePicker1.Hide();
                SaveBtn.Hide();
                label7.Hide();
                textBox1.Hide();
            }
            con.Close();

    

            dt.Clear();
            da = new SqlDataAdapter("Select(SELECT TOP 1 p.Name PersonName FROM dbo.Person p WHERE p.BarCode=Person.BarCode ORDER BY p.PersonType) , Person.BarCode,dbo.service.Name ServiceName ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note FROM dbo.Person LEFT JOIN dbo.ServiceToken ON ServiceToken.BarCode = Person.BarCode LEFT JOIN dbo.service ON service.ID = ServiceToken.ServiceID WHERE Person.BarCode Like '%" + textBox2.Text + "%' GROUP by Person.BarCode,dbo.service.Name ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note  order by dbo.ServiceToken.DateTime desc", con);
           // da = new SqlDataAdapter("select * from Person where BarCode Like '%" + textBox2.Text + "%'", con);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;

            this.dataGridView1.RightToLeft = RightToLeft.Yes;

 
            dataGridView1.Columns[0].HeaderText = "الاسم";            
            dataGridView1.Columns[1].HeaderText = "رقم البحث"; 
            dataGridView1.Columns[2].HeaderText = "الخدمة"; 
            dataGridView1.Columns[3].HeaderText = " تاريخ اخذ الخدمة"; 
            dataGridView1.Columns[4].HeaderText = "الملاحظات";
            //
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 400;

        }

        private void The_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (videoCaptureDevice.IsRunning == true)
            //    videoCaptureDevice.Stop();
        }

        private void The_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (videoCaptureDevice.IsRunning == true)
            //    videoCaptureDevice.Stop();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
                if (comboBox1.Visible == true && comboBox1.SelectedItem != null)
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand
                    ("insert into ServiceToken (BarCode,ServiceID,DateTime,Note)values" +
                    "(N'" + textBox2.Text+"','" + comboBox1.SelectedValue + "','"
                    + dateTimePicker1.Text+ "',N'" + textBox1.Text + "')", con);
             
                    MessageBox.Show("تم حفظ الخدمة");

                    textBox1.Text = "";

                cmd.ExecuteNonQuery();
                    con.Close();
              
                dt.Clear();
                //  da = new SqlDataAdapter("Select(SELECT TOP 1 p.Name PersonName FROM dbo.Person p WHERE p.BarCode=Person.BarCode ORDER BY p.PersonType) , " +"Person.BarCode,dbo.service.Name ServiceName ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note FROM dbo.Person LEFT JOIN dbo.ServiceToken ON ServiceToken.BarCode = Person.BarCode LEFT JOIN dbo.service ON service.ID = ServiceToken.ServiceID WHERE Person.BarCode Like '%" + textBox2.Text + "%' GROUP by Person.BarCode,dbo.service.Name ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note ", con);
                da = new SqlDataAdapter("Select(SELECT TOP 1 p.Name PersonName FROM dbo.Person p WHERE p.BarCode=Person.BarCode ORDER BY p.PersonType) , Person.BarCode,dbo.service.Name ServiceName ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note FROM dbo.Person LEFT JOIN dbo.ServiceToken ON ServiceToken.BarCode = Person.BarCode LEFT JOIN dbo.service ON service.ID = ServiceToken.ServiceID WHERE Person.BarCode Like '%" + textBox2.Text + "%' GROUP by Person.BarCode,dbo.service.Name ,dbo.ServiceToken.DateTime, dbo.ServiceToken.Note order by dbo.ServiceToken.DateTime desc", con);

                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                this.dataGridView1.RightToLeft = RightToLeft.Yes;


                dataGridView1.Columns[0].HeaderText = "الاسم";
                dataGridView1.Columns[1].HeaderText = "رقم البحث";
                dataGridView1.Columns[2].HeaderText = "الخدمة";
                dataGridView1.Columns[3].HeaderText = " تاريخ اخذ الخدمة";
                dataGridView1.Columns[4].HeaderText = "الملاحظات";
                //
            }
            else
            {
                MessageBox.Show("من فضلك قم بتحديد الخدمة التي اخذها المخدوم");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
  
}
