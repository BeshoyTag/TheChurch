using MegaTalentService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace MegaTalentService
{
    public partial class InsertPerson : Form

    {
        public static string BarCode;
        //{
        //    get { return textBox11.Text; }
        //}
int Record_Id;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True"); 


        //Entities entities = new Entities();
        ////SqlConnaction con = new qlConnaction();
        public InsertPerson()
        {
            InitializeComponent();

            //for (int i = 0; i < 23; i++)
            //{
            //    dataGridView1.Columns[i].ReadOnly = true;
            //}

            radioButton6.Checked = true;
            radioButton1.Checked = true;
            dataGridView1.Visible = false;

            button3.Enabled = false;
            button4.Enabled = false;

            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
                
        }
        public string conString = "data source=DESKTOP-001BUBP;initial catalog=5admaa;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        private void button1_Click(object sender, EventArgs e)
        {
            
           //if(ValidateChildren(ValidationConstraints.Enabled))
           // {
           //     MessageBox.Show(textBox7.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // }
            
          
            
            
            
            //
            BarCode = textBox7.Text;
           string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);

            try
            {
                if (filename == null)
                {
                    MessageBox.Show("من فضلك قم بإختيار صورة ");
                }
                else
                {
                     string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    System.IO.File.Copy(openFileDialog1.FileName, path + "\\Image\\" + filename);
               
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("الملف موجود مسبقاً");
            }

            SqlCommand cmd = new SqlCommand("InsertPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Mobile", textBox3.Text);
            cmd.Parameters.AddWithValue("@Telephone", textBox4.Text);
            cmd.Parameters.AddWithValue("@Salary", textBox8.Text == "" ? 0 : decimal.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@Notes", textBox10.Text);

            cmd.Parameters.AddWithValue("@BarCode", textBox7.Text);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@Khadem", textBox6.Text);
            cmd.Parameters.AddWithValue("@SocialStatus", textBox5.Text);
            cmd.Parameters.AddWithValue("@RecognitionFather", textBox11.Text);

            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@QualificationID", comboBox5.SelectedValue);
            //cmd.Parameters.AddWithValue("@AddressID", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedValue);
            //   cmd.Parameters.AddWithValue("@City", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@KhadmaID", comboBox3.SelectedValue);
            cmd.Parameters.AddWithValue("@CurchID", comboBox4.SelectedValue);
            cmd.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Image", "\\Image\\" + filename);
            cmd.Parameters.AddWithValue("@CityID", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@Total_Income", textBox16.Text == "" ? 0 : decimal.Parse(textBox16.Text));
            cmd.Parameters.AddWithValue("@Total_Cost", textBox15.Text == "" ? 0 : decimal.Parse(textBox15.Text));
            cmd.Parameters.AddWithValue("@HM", textBox17.Text == "" ? 0 : decimal.Parse(textBox17.Text));
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

            if (radioButton1.Checked == true)
                cmd.Parameters.AddWithValue("@Gender", radioButton1.Checked);
            else
                cmd.Parameters.AddWithValue("@Gender", false);


            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("تم الحفظ");
                dataGridView1.Visible = true;
                ClearData();
                refreshData();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            radioButton6.Checked = true;
            radioButton1.Checked = true;

        }

         private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertPerson_Load(object sender, EventArgs e)
        {
            //button3.Visible = false;

            refreshData();
            //textBox1.ReadOnly = true;
        }
        void refreshData()
        {
            this.dataGridView1.RightToLeft = RightToLeft.Yes;
            DataTable dtt = new DataTable();
            //   SqlDataAdapter daa = new SqlDataAdapter("select * from ", con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from dbo.InsertPersonview";
            con.Open();
            dtt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dtt;
            con.Close();
            dataGridView1.DataSource = dtt;

            
            DataTable dtQualification = new DataTable();
            SqlDataAdapter daQualification = new SqlDataAdapter("select * from Qualification", con);
            daQualification.Fill(dtQualification);
            comboBox5.DataSource = dtQualification;
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "ID";
            //comboBox5.SelectedIndex = -1;
            //comboBox5.SelectedText = "   ";


            DataTable dtKhadma = new DataTable();
            SqlDataAdapter daKhadma = new SqlDataAdapter("select * from Khadma", con);
            daKhadma.Fill(dtKhadma);
            comboBox3.DataSource = dtKhadma;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            //comboBox3.SelectedIndex = -1;
            //comboBox3.SelectedText = "   ";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from education", con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            //comboBox1.SelectedIndex = -1;
            //comboBox1.SelectedText = "   ";


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


          
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =

                 ($@"[الأسم] LIKE'%{(textBox12.Text)}%'   
                    OR [رقم التليفون]lIKE '%{textBox12.Text}%'
                       OR[رقم التليفون الارضي]lIKE '%{textBox12.Text}%'
                            OR [الكنيسة]lIKE '%{textBox12.Text}%'
                                OR[رقم البحث]lIKE '%{textBox12.Text}%'
                                  OR [المرحلة التعليميه]lIKE '%{textBox12.Text}%'
                                     OR [المؤهل الدراسي]lIKE '%{textBox12.Text}%'
                                        OR [الخادم المسؤال]lIKE '%{textBox12.Text}%'
                                            OR[الايميل]lIKE '%{textBox12.Text}%'
                                               OR [الاب الكاهن]lIKE '%{textBox12.Text}%'
                                                  OR [الاجتماع التابع له] LIke '%{textBox12.Text}%'
                                                    OR [المحافظة]lIKE '%{textBox12.Text}%'
                                                         OR [الكنيسة]lIKE '%{textBox12.Text}%'
        ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

       
            
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }






        void ClearData()
        {
            pictureBox2.Image = null;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton6.Checked = false;
            radioButton5.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //BarCode = textBox7.Text;

            New_Dashboard dash = (New_Dashboard)Application.OpenForms["New_Dashboard"];
            Panel pnl = (Panel)dash.Controls["PnlFormLoader"];
            pnl.Controls.Clear();
            InsertChardren child = new InsertChardren()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            child.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(child);
           // label2.Text = "إدخال فرد إلي الاُسرة";
            child.Show();


          


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

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
                //else
                //{
                //    MessageBox.Show("من فضلك ارفع صوره شخصيه");
                //}
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show("الصوره موجوده بالفعل");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BarCode = textBox7.Text;

            New_Dashboard IDCard = (New_Dashboard)Application.OpenForms["New_Dashboard"];
            Panel pnl = (Panel)IDCard.Controls["PnlFormLoader"];
            pnl.Controls.Clear();
            DesigenID design_id = new DesigenID()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            design_id.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(design_id);
            design_id.Show();

            
            //textBox11.Text = textBox7.Text;
            //label1.Hide();
            //textBox11.Hide();
            //button3.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            //if (String.IsNullOrEmpty(textBox7.Text))
            //{
            //    e.Cancel = true;
            //    textBox7.Focus();
            //    errorProvider1.SetError(textBox7, "قم بإدخال رقم البحث");
            //}
            //else
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(textBox7, null);

            //}
        }
    }

}
