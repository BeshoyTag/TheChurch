using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MegaTalentService
{
    public partial class InsertChardren : Form
    {



        //   int Record_Id;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
        public InsertChardren()
        {
            InsertPerson p = new InsertPerson();
            //textBox7.Text = p.BarCode;

            InitializeComponent();
            radioButton4.Checked = true;
            radioButton1.Checked = true;
           // textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            InsertChardren index = new InsertChardren();

            index.Show();
            this.Hide();
        }

        private void InsertChardren_Load(object sender, EventArgs e)
        {
           textBox1.Text = InsertPerson.BarCode;
            refreshData();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                textBox7.Focus();
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBox7, "برجلء ادخال الاسم");
            }
            else if (textBox13.Text == string.Empty)
            //  else if (textBox13.Text == string.)
            {
                textBox13.Focus();
                errorProvider2.RightToLeft = true;
                errorProvider2.SetError(textBox13, "برجاء ادخال الرقم القومي");

            }
            else if (textBox1.Text == string.Empty)
            {
                textBox1.Focus();
                errorProvider3.RightToLeft = true;
                errorProvider3.SetError(textBox1, "برجاء ادخال رقم البحث");

            }
            else
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);

                try
                {
                    if (filename == null)
                    {
                        MessageBox.Show("من فضلك اختار صوره ");
                    }
                    else
                    {
                        //we already define our connection globaly. We are just calling the object of connection.
                        //con.Open();
                        //SqlCommand cmmd = new SqlCommand("insert into Person (Image)values('\\Image\\" + filename + "')", con);
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(openFileDialog1.FileName, path + "\\Image\\" + filename);
                        //cmmd.ExecuteNonQuery();
                        //con.Close();
                        // MessageBox.Show("Image uploaded successfully.");
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("الملف موجود مسبقا");
                }


                SqlCommand cmd = new SqlCommand("InsertPersonChildren", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", textBox7.Text);
                cmd.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Mobile", textBox3.Text);
                cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedValue);
                if (radioButton1.Checked == true)
                    cmd.Parameters.AddWithValue("@Gender", radioButton1.Checked);
                if (radioButton2.Checked == true)
                    cmd.Parameters.AddWithValue("@Gender", radioButton2.Checked);

                //else
                //    cmd.Parameters.AddWithValue("@Gender", false);


                //cmd.Parameters.AddWithValue("@Telephone", textBox3.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox8.Text == "" ? 0 : decimal.Parse(textBox8.Text));
                cmd.Parameters.AddWithValue("@Notes", textBox10.Text);
                cmd.Parameters.AddWithValue("@BarCode", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);

                cmd.Parameters.AddWithValue("@Khadem", textBox6.Text);
                cmd.Parameters.AddWithValue("@SocialStatus", textBox5.Text);
                cmd.Parameters.AddWithValue("@RecognitionFather", textBox11.Text);

                //  cmd.Parameters.AddWithValue("@Address", textBox9.Text);
                cmd.Parameters.AddWithValue("@QualificationID", comboBox5.SelectedValue);
                //cmd.Parameters.AddWithValue("@AddressID", comboBox2.SelectedValue);

                //   cmd.Parameters.AddWithValue("@City", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@KhadmaID", comboBox3.SelectedValue);
                //cmd.Parameters.AddWithValue("@CurchID", comboBox4.SelectedValue);

                cmd.Parameters.AddWithValue("@Image", "\\Image\\" + filename);
                cmd.Parameters.AddWithValue("@NationalID", textBox13.Text);
                cmd.Parameters.AddWithValue("@Job", textBox14.Text);

                if (radioButton6.Checked)
                    cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(1));
                if (radioButton5.Checked)
                    cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(2));

                if (radioButton4.Checked)
                    cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(3));

                if (radioButton3.Checked)
                    cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(4));




                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    MessageBox.Show("تم الحفظ");
                    ClearData();

                    refreshData();
                }
                // حفظ  الصوره في الدانا بيز 


                // using (var b=new Bitmap (for))
            }
        }
        private void refreshData()
        {
            DataTable dtQualification = new DataTable();
            SqlDataAdapter daQualification = new SqlDataAdapter("select * from Qualification", con);
            daQualification.Fill(dtQualification);
            comboBox5.DataSource = dtQualification;
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "ID";


            DataTable dtKhadma = new DataTable();
            SqlDataAdapter daKhadma = new SqlDataAdapter("select * from Khadma", con);
            daKhadma.Fill(dtKhadma);
            comboBox3.DataSource = dtKhadma;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from education", con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";



            DataTable dttt = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter("select * from City", con);
            daaa.Fill(dttt);
            comboBox2.DataSource = dttt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";



            DataTable dtttt = new DataTable();
            SqlDataAdapter daaaa = new SqlDataAdapter("select * from Church", con);
            daaaa.Fill(dtttt);
            comboBox4.DataSource = dtttt;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";


            DataTable dttttt = new DataTable();
            SqlDataAdapter daaaaa = new SqlDataAdapter("select * from City", con);
            daaaaa.Fill(dttttt);
            comboBox2.DataSource = dttttt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";


    
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != string.Empty)
            {
                errorProvider1.Clear();
            }
        }



        void ClearData()
        {
            textBox13.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            pictureBox2.Image = null;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
            textBox10.Text = "";
            textBox11.Text = "";

          //  textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
           
            textBox8.Text = "";
            textBox9.Text = "";


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            New_Dashboard dash = (New_Dashboard)Application.OpenForms["New_Dashboard"];
            Panel panel = (Panel)dash.Controls["PnlFormLoader"];
            label2.Text = "إدخال مخدوم";
            panel.Controls.Clear();
            InsertPerson person = new InsertPerson()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            person.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(person);
            person.Show();
        }

        private void DashboardCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DashboardMinimizedBtn_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            //To where your opendialog box get starting location. My initial directory location is desktop.
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select Image to be upload.";
            //which type image format you want to upload in database. just add them.
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        //    label1.Text = path;
                        pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != string.Empty)
            {
                errorProvider2.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                errorProvider3.Clear();
            }
        }
    }
}