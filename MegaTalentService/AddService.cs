using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.OleDb;

namespace MegaTalentService
{
    public partial class AddService : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection
            (@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
      //  SqlCommand cmd;
        SqlDataAdapter adpt;
       // DataTable dt;

        List<string> listFiles = new List<string>();
        public AddService()
        {
            InitializeComponent();


            Addbtn.Enabled = false;
            RightPic.Hide();
            WrongPic.Hide();


            dataGridView1.Hide();
            label2.Hide();
            comboBox1.Hide();
            btnOpen.Hide();
            pictureBox1.Hide();
            Addbtn.Hide();
            button1.Hide();

        }

 



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddService_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from service", con);

            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";


            adpt = new SqlDataAdapter("select * from Person", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label3, "قم بإدخال أرقام فقط ");
                label3.Text = "قم بإدخال أرقام فقط ";

            }
            else
            {

                errorProvider1.SetError(label3, "");
                label3.Text = "";

            }

        }

        private void Checkbtn_Click(object sender, EventArgs e)
        {

           

        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // string sqlquery = "select * from Person where BarCode ='" + textBox1.Text + "'";

            con.Open();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string query =
            "Select * from Person WHERE BarCode='" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
       
            dataGridView1.DataSource = dt;

            object obj = cmd.ExecuteScalar();

            if (Convert.ToInt32(obj) > 0)
            {
                WrongPic.Visible = false;
                RightPic.Visible = true;
                Addbtn.Enabled = true;

                //
                dataGridView1.Visible = true;
                for(int i = 0; i < 26; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
                }
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[22].Visible = true;
                dataGridView1.Columns[1].HeaderText = "الإسم";
                dataGridView1.Columns[5].HeaderText = "رقم البحث";
                dataGridView1.Columns[22].HeaderText = "الرقم القومي";
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[22].Width = 495;
                //

                label2.Visible = true;
                comboBox1.Visible = true;
                btnOpen.Visible = true;
                pictureBox1.Visible = true;
                Addbtn.Visible = true;
                button1.Visible = true;


            }
            else
            {
                RightPic.Visible = false;
                WrongPic.Visible = true;
                Addbtn.Enabled = false;

                dataGridView1.Hide();
                label2.Hide();
                comboBox1.Hide();
                btnOpen.Hide();
                pictureBox1.Hide();
                Addbtn.Hide();
                button1.Hide();

            }

            con.Close();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RightPic.Visible == true)
                {
                    string filename =System.IO.Path.GetFileName(openFileDialog1.FileName)  ;
                    if (filename == null || filename == "openFileDialog1")
                    {                            

                        con.Open();
                        SqlCommand cmd = new SqlCommand
                        ("insert into Service (name)values(N'" + otherserve.Text + "')", con);

                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = new SqlCommand("select top 1  id from dbo.Service whERE name =N'" + otherserve.Text + "'", con);
                        //cmd1.ExecuteScalar();
                        string serviceID;//= comboBox1.SelectedValue = 1 ? cmd1 : comboBox1.SelectedValue;
                        if(comboBox1.SelectedValue.ToString() =="1")
                        {
                            serviceID = cmd1.ExecuteScalar().ToString();
                        }
                        else
                        {
                            serviceID = comboBox1.SelectedValue.ToString();
                        }



                        SqlCommand cmd2 = new SqlCommand
                      ("insert into ProfileServices (BarCode,ServiceID)values('" +textBox1.Text + "','" + serviceID + "')", con);

                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حفظ الخدمة");


                    }
                    else
                    {

                        filename = filename + DateTime.Now.ToString("MM.dd.yyyy HH.mm.ss");
                        con.Open();
                        SqlCommand cmd = new SqlCommand
                        ("insert into ProfileServices (BarCode,ServiceID,Attachment)values('" + textBox1.Text + "','" + comboBox1.SelectedValue + "','\\Image\\" + filename + "')", con);
                        string path =
                        Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(openFileDialog1.FileName, path + "\\Image\\" + filename);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حفظ الخدمة");
                    }
                }
                
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Already Exits");

            }








        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void signuplbl_Click(object sender, EventArgs e)
        {

        }

        private void DashboardCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select Image to be upload";
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

                //else
                //{
                //    MessageBox.Show("Please Upload an Image");
                //} 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RightPic_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

        }

        private void otherserve_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
