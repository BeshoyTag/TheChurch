using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;

namespace MegaTalentService
{
    public partial class DesigenID : Form
    {
        public object MassageBox { get; private set; }
        SqlConnection conn1 = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True ");

        public DesigenID()
        {
            InitializeComponent();

            panel1.Visible = false;
            button1.Visible = false;
            textBox11.Text = InsertPerson.BarCode;

            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(pictureBox1.DisplayRectangle);
            //pictureBox1.Region = new Region(gp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var PNG = new Bitmap(panel1.Width, panel1.Height))
              
            {
                panel1.DrawToBitmap(PNG, new Rectangle(0, 0, PNG.Width, PNG.Height));
                PNG.Save(@"test1/" + label9.Text + ".png");
                MessageBox.Show("تم حفظ الصورة بنجاح");
            }
        }
            
        private void DesigenID_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void butgenerate_Click(object sender, EventArgs e)
        {
            //QRCodeGenerator qr = new QRCodeGenerator();
            //QRCodeData date = qr.CreateQrCode(textBox11.Text, QRCodeGenerator.ECCLevel.Q);

            //QRCode code = new QRCode(date);
            //pic.Image = code.GetGraphic(5);


        }

        private void textQRcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //conn1.Open();
            //SqlCommand cmd1 = new SqlCommand("select Name,Name,aa Mobile where ID=@ID", conn1);
            //cmd1.Parameters.AddWithValue("ID", textBox6.Text);
            //SqlDataReader reader1;
            //reader1 = cmd1.ExecuteReader();
            //if (reader1.Read()) ;
            //{
            //    textBox1.Text = reader1["firstname"].ToString();
            //    textBox2.Text = reader1["lastname"].ToString();
            //    textBox3.Text = reader1["sum"].ToString();
            //}

          
            //conn1.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("select top 1 p1.Barcode,p1.image, p1.mobile, p1.name fathername ,p2.name mothername from dbo.person p1 ,Left join dbo.prson p2 ON p2.Barcode = p1.Barcode AND p2.personType=2   WHERE P1.Barcode=123 ORDER BY p1.personTypeconn1",conn1) ;
           conn1.Close();
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("select top 1 p1.Barcode,p1.Image, Church.Name churchName, p1.name fathername ,p2.name mothername   from dbo.person p1 Left join person p2 ON p2.Barcode = p1.Barcode AND p2.personType = 2 left join Church on Church.ID = p1.CurchID WHERE P1.Barcode = '"+ textBox11.Text+ "' ORDER BY p1.PersonType", conn1);
             cmd1.Parameters.AddWithValue("ID", textBox11.Text);
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();


            if (reader1.Read()) 
            {
                panel1.Visible = true;
                button1.Visible = true;

                label6.Text = reader1["fathername"].ToString();
            //    label7.Text = reader1["mothername"].ToString();
                label8.Text = reader1["churchName"].ToString();
                label9.Text = reader1["Barcode"].ToString();
               // pictureBox1.Image = reader1["image"].ToString();
                

                pictureBox1.ImageLocation = Application.StartupPath.Substring(0,(Application.StartupPath.Length - 10))+ reader1["image"].ToString();

                //MemoryStream ms = new MemoryStream((byte[])reader1["Image"]);
                //pictureBox1.Image = new Bitmap(ms);

            }
            else
            {
                panel1.Visible = false;
                button1.Visible = false;
                MessageBox.Show("من فضلك قم بإدخال رقم بحث صحيح");
            }
            conn1.Close();
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData date = qr.CreateQrCode(label9.Text, QRCodeGenerator.ECCLevel.Q);

            QRCode code = new QRCode(date);
            pic.Image = code.GetGraphic(5);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textQRcode_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddServiceCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    } 
