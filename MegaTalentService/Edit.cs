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
using System.IO;

namespace MegaTalentService
{
    public partial class Edit : Form
    {
        public string conString = "data source=DESKTOP-001BUBP;initial catalog=5admaa;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        int Record_Id;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
        public Edit()
        {
            InitializeComponent();

            //for (int i = 0; i < 23; i++)
            //{
            //    dataGridView1.Columns[i].ReadOnly = true;
            //}
            ClearData();
        }

        //private void textBox12_TextChanged(object sender, EventArgs e)
        //{


        //    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
        //       $@"الأسم LIKE'%{(textBox12.Text)}%'   
        //            OR [رقم التليفون]lIKE '%{textBox12.Text}%'
        //               OR[رقم التليفون الارضي]lIKE '%{textBox12.Text}%'
        //                    OR [الكنيسة]lIKE '%{textBox12.Text}%'
        //                        OR[رقم البحث]lIKE '%{textBox12.Text}%'
        //                          OR [المرحلة التعليميه]lIKE '%{textBox12.Text}%'
        //                             OR [المؤهل الدراسي]lIKE '%{textBox12.Text}%'
        //                                OR [الخادم المسؤال]lIKE '%{textBox12.Text}%'
        //                                    OR[الايميل]lIKE '%{textBox12.Text}%'
        //                                       OR [الاب الكاهن]lIKE '%{textBox12.Text}%'
        //                                          OR [الخدمه المتاحة]lIKE '%{textBox12.Text}%'
        //                                            OR [المحافظة ]lIKE '%{textBox12.Text}%'
        //                                                  OR [الكنيسة ]lIKE '%{textBox12.Text}%'
        //                                              OR [[رقم البحث] ]lIKE '%{textBox12.Text}%' ";
        //}



        void LoadData() {
            DataTable dttt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from dbo.EditView";
            con.Open();
            dttt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dttt;
            con.Close();
            dataGridView1.DataSource = dttt;


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



            DataTable dtttc = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter("select * from City", con);
            daaa.Fill(dtttc);
            comboBox2.DataSource = dtttc;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";



            DataTable dtttt = new DataTable();
            SqlDataAdapter daaaa = new SqlDataAdapter("select * from Church", con);
            daaaa.Fill(dtttt);
            comboBox4.DataSource = dtttt;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";



        }
        private void Edit_Load(object sender, EventArgs e)
        { 


            this.dataGridView1.RightToLeft = RightToLeft.Yes;
            LoadData();
            textBox17.Text = "0";


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertChardren index = new InsertChardren();
            index.Show();
            this.Hide();
        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged_2(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                
               ($@"[الاسم] LIKE'%{(textBox12.Text)}%'   
                  OR[BarCode]lIKE '%{textBox12.Text}%'                        
                    
");
        }

        private void Edit_MouseClick(object sender, MouseEventArgs e)
        {



        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            comboBox1.Text = "";
            comboBox5.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox3.SelectedText = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                comboBox1.SelectedText = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboBox5.SelectedText = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                comboBox2.SelectedText = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                textBox15.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();

                pictureBox2.ImageLocation = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10))+dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();

                LoadData();
               

            }
        }
       
        private void button2_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Focus();
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBox1, "برجلء ادخال الاسم");
            }
            else if (textBox13.Text == string.Empty)
            //  else if (textBox13.Text == string.)
            {
                textBox13.Focus();
                errorProvider2.RightToLeft = true;
                errorProvider2.SetError(textBox13, "برجاء ادخال الرقم القومي");

            }
            else if (textBox7.Text == string.Empty)
            {
                textBox7.Focus();
                errorProvider3.RightToLeft = true;
                errorProvider3.SetError(textBox7, "برجاء ادخال رقم البحث");

            }
            else
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                SqlCommand cmd = new SqlCommand("EditPerson", con);
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
                cmd.Parameters.AddWithValue("@QualificationID", comboBox1.SelectedValue);
                //cmd.Parameters.AddWithValue("@AddressID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@Education", comboBox5.SelectedValue);
                //   cmd.Parameters.AddWithValue("@City", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@KhadmaID", comboBox3.SelectedValue);
                cmd.Parameters.AddWithValue("@CurchID", comboBox4.SelectedValue);
                cmd.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Image", "\\Image\\" + filename);
                cmd.Parameters.AddWithValue("@CityID", comboBox2.SelectedValue);
                //  cmd.Parameters.AddWithValue("@Gender", checkBox1.Checked);
                //  cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@NationalID", textBox13.Text);
                cmd.Parameters.AddWithValue("@Job", textBox14.Text);
                cmd.Parameters.AddWithValue("@Total_Income", textBox16.Text == "" ? 0 : decimal.Parse(textBox16.Text));
                cmd.Parameters.AddWithValue("@Total_Cost", textBox15.Text == "" ? 0 : decimal.Parse(textBox15.Text));
                cmd.Parameters.AddWithValue("@HM", textBox17.Text == "" ? 0 : decimal.Parse(textBox17.Text));




                if (con.State == ConnectionState.Closed)

                    con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();


                if (i != 0)
                {

                    MessageBox.Show("تم التعديل");

                }
                LoadData();
                //ClearData();
                refreshData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Delete from person where barcode = N'{textBox7.Text}'  or name = N'{textBox1.Text}'", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();



            if (i != 0)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحذف");
                con.Close();
            }

            ClearData();
            refreshData();
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
     //       dataGridView1.DataSource = dtt;
            con.Close();

           
            DataTable dtQualification = new DataTable();
            SqlDataAdapter daQualification = new SqlDataAdapter("select * from Qualification", con);
            daQualification.Fill(dtQualification);
            comboBox1.DataSource = dtQualification;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            

            DataTable dtKhadma = new DataTable();
            SqlDataAdapter daKhadma = new SqlDataAdapter("select * from Khadma", con);
            daKhadma.Fill(dtKhadma);
            comboBox3.DataSource = dtKhadma;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from education", con);
            da.Fill(dt);
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "ID";



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

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
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
                        pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }

             
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            pictureBox2.Image = null;

        }

        private void AddServiceCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            New_Dashboard dash = (New_Dashboard)Application.OpenForms["New_Dashboard"];
            Panel pnl = (Panel)dash.Controls["PnlFormLoader"];
            pnl.Controls.Clear();
            InsertChardren child = new InsertChardren()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            child.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(child);
            child.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                errorProvider1.Clear();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != string.Empty)
            {
                errorProvider3.Clear();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != string.Empty)
            {
                errorProvider2.Clear();
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }


}
