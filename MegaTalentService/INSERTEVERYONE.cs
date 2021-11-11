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
        //    get { return textBox7.Text; }
        //}
        int Record_Id;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");

        //  SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        //  int ID = 0;
        //Entities entities = new Entities();
        ////SqlConnaction con = new qlConnaction();
        public InsertPerson()
        {

            InitializeComponent();
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
           // BarCode = textBox7.Text;
            btnChildren.Visible = true;
            //BarCode = textBox7.Text;
            //SqlConnection con = new SqlConnection(conString);

            ////SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-001BUBP\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True");
            ////SqlCommand cmd = new SqlCommand("Person", con);
            ////cmd.CommandType = CommandType.StoredProcedure;
            ////cmd.Parameters.AddWithValue("@name", textBox1.Text);
            ////cmd.Parameters.AddWithValue("@email", textBox2.Text);
            ////cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            ////cmd.Parameters.AddWithValue("@address", textBox4.Text);
            //con.Open();
            //if (con.State == System.Data.ConnectionState.Open)
            //{
            //    string q = "insert into [Person] (textBox1,textBox2,textBox3,textBox4) values (@name ,@Birthday ,@Mobile ,@Telephon)";
            //    //string q= "insert into Person(name,)values('" + textBox1.Text.ToString()+"')";
            //    SqlCommand cmd = new SqlCommand(q, con);
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show( "Data Saved");
            //}

            ////int i = cmd.ExecuteNonQuery();

            ////con.Close();

            ////if (i != 0)
            ////{
            ////    MessageBox.Show(i + "Data Saved");
            ////}
            ///
            //SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
            //SqlConnection con = new SqlConnection(@"DESKTOP-001BUBP;initial catalog=5admaa;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
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
                MessageBox.Show("الملف موجود مسبقا");
            }

            //DataTable dtt = new DataTable();
            //SqlDataAdapter daa = new SqlDataAdapter("select * from Person ", con);
            //daa.Fill(dtt);
            //dataGridView1.DataSource = dtt;

            SqlCommand cmd = new SqlCommand("InsertPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Mobile", textBox4.Text);
            cmd.Parameters.AddWithValue("@Telephone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Salary", textBox8.Text);
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
            cmd.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Image", "\\Image\\" + filename);
            cmd.Parameters.AddWithValue("@CityID", comboBox2.SelectedValue);


            cmd.Parameters.AddWithValue("@NationalID", textBox13.Text);
            cmd.Parameters.AddWithValue("@Job", textBox14.Text);

            if (radioFather.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(1));
            if (radioMother.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(2));

            if (radioSon.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(3));

            if (radioDoughter.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(4));

            ///////////////////////

            // con.Open();
            //cmd = new SqlCommand("insert into Person values('"+ 
            //    Convert.ToInt32(radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked) + "')", con);
            //cmd.ExecuteNonQuery();
            //  con.Close();


            ///////////////////////







            //  cmd.Parameters.AddWithValue("@Gender", checkBox1.Checked);
            //  cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedValue);
            if (radioButton1.Checked == true)
                cmd.Parameters.AddWithValue("@Gender", radioButton1.Checked);
            else
                cmd.Parameters.AddWithValue("@Gender", false);


            //cmd.Parameters.AddWithValue("@PersonType",radioButton5.Checked.Equals("1") );






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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void InsertPerson_Load(object sender, EventArgs e)
        {
           // btnChildren.Visible = false;

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
            //cmd.CommandText = "select Name ,Birthday as 'تاريخ الميلاد',Mobile as 'رقم التليفون',Telephone as 'رقم التليفون الارضي',BarCode as 'الرقم القومي',Email as 'الايميل'" +
            //    ",RecognitionFather as 'الاب الكاهن',Khadem as 'الخادم المسؤل',Gender as 'النوع',SocialStatus as 'الحاله الاجتماعية',Salary as 'المرتب'," +
            //    "Address as 'العنوان',Notes as 'الملاحظات',CurchID as 'الكنيسه التابع لها' ,Image as 'الصوره الشخصية' from Person";
            cmd.CommandText = "select * from dbo.InsertPersonview";
            con.Open();
            dtt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dtt;
            con.Close();
            dataGridView1.DataSource = dtt;

            // dataGridView1.Columns[0].HeaderText = "id";
            //dataGridView1.Columns[1].HeaderText = "الاسم";
            //dataGridView1.Columns[2].HeaderText = "تاريخ الميلاد";
            //dataGridView1.Columns[3].HeaderText = "رقم التليفون";
            //dataGridView1.Columns[4].HeaderText = "رقم التليفون الارضي";
            //dataGridView1.Columns[5].HeaderText = "الرقم السري";
            //dataGridView1.Columns[5].HeaderText = "التعليم";
            //dataGridView1.Columns[6].HeaderText = "المؤهلات";
            //dataGridView1.Columns[7].HeaderText = "الايميل ";
            //dataGridView1.Columns[8].HeaderText = "اب الاعتراف";
            //dataGridView1.Columns[9].HeaderText = "الاجتماع ";
            //dataGridView1.Columns[10].HeaderText = "النوع";
            //dataGridView1.Columns[11].HeaderText = "الحاله الاجتماعية";
            //////
            //dataGridView1.Columns[12].HeaderText = "المرتب";
            //dataGridView1.Columns[13].HeaderText = "العنوان ";

            //dataGridView1.Columns[14].HeaderText = "الكنيسه التابع لها";
            //dataGridView1.Columns[15].HeaderText = "المحافظة";
            //dataGridView1.Columns[19].HeaderText = "عنوان الصوره";
            //    dataGridView1.Columns[15].HeaderText = "الصوره الشخصية";
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

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
               $@"[الأسم] like'%{(textBox12.Text)}%'   
                    OR [رقم التليفون]like '%{textBox12.Text}%'
                       OR[رقم التليفون الارضي]like '%{textBox12.Text}%'
                            OR [الكنيسة]like '%{textBox12.Text}%'
                                OR[رقم البحث]lIKE '%{textBox12.Text}%'
                                  OR [المرحلة التعليميه]lIKE '%{textBox12.Text}%'
                                     OR [المؤهل الدراسي]lIKE '%{textBox12.Text}%'
                                        OR [الخادم المسؤال]lIKE '%{textBox12.Text}%'
                                            OR[الايميل]lIKE '%{textBox12.Text}%'
                                               OR [الاب الكاهن]lIKE '%{textBox12.Text}%'
                                                  OR [الاجتماع التابع له]lIKE '%{textBox12.Text}%'
                                                    OR [المحافظة]lIKE '%{textBox12.Text}%'
                                                         OR [الكنيسة]lIKE '%{textBox12.Text}%'
                                                            OR [[رقم البحث] ]lIKE '%{textBox12.Text}%'";
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Mobile", textBox4.Text);
            cmd.Parameters.AddWithValue("@Telephone", textBox3.Text);
            cmd.Parameters.AddWithValue("@Salary", textBox8.Text);
            cmd.Parameters.AddWithValue("@Notes", textBox10.Text);
            cmd.Parameters.AddWithValue("@BarCode", textBox7.Text);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@Khadem", textBox6.Text);
            cmd.Parameters.AddWithValue("@SocialStatus", textBox5.Text);
            cmd.Parameters.AddWithValue("@RecognitionFather", textBox11.Text);
            cmd.Parameters.AddWithValue("@NationalID", textBox13.Text);
            cmd.Parameters.AddWithValue("@Job", textBox14.Text);
            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@QualificationID", comboBox5.SelectedValue);
            cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@KhadmaID", comboBox3.SelectedValue);
            cmd.Parameters.AddWithValue("@CurchID", comboBox4.SelectedValue);
            cmd.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Image", "\\Image\\" + filename);
            cmd.Parameters.AddWithValue("@CityID", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@NationalID", textBox13.Text);
            cmd.Parameters.AddWithValue("@Job", textBox14.Text);

            if (radioFather.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(1));
            if (radioMother.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(2));

            if (radioSon.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(3));

            if (radioDoughter.Checked)
                cmd.Parameters.AddWithValue("@PersonType", Convert.ToInt32(4));


            if (radioButton1.Checked == true)
                cmd.Parameters.AddWithValue("@Gender", radioButton1.Checked);
            else
                cmd.Parameters.AddWithValue("@Gender", false);

            con.Open();
            int i = cmd.ExecuteNonQuery();



            if (i != 0)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل");
                con.Close();
            }
            // حفظ  الصوره في الدانا بيز 


            // using (var b=new Bitmap (for))

        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1 && e.ColumnIndex > -1)
            //{
            //    //  ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    //txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    //txt_State.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            //    //Record_Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            //    //radioButton1.Checked = bool.Parse( dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());

            //    textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            //    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            //    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            //    // comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            //    textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            //    textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            //    //textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            //    comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    comboBox5.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //    comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            //    comboBox4.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            //}
        } 


        private void button5_Click(object sender, EventArgs e)
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
                    MessageBox.Show("من فضلك ارفع صوره شخصيه");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show("الصوره موجوده بالفعل");
            }

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
            radioDoughter.Checked = false;
            radioFather.Checked = false;
            radioMother.Checked = false;
            radioButton2.Checked = false;
            radioDoughter.Checked = false;


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            InsertChardren index = new InsertChardren();
            index.Show();
            //this.Hide();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
//الاسكرين شوت بتاع جورج
//private void button1_Click(object sender, EventArgs e)
//{
//    using (var bmp = new Bitmap(panel1.Width, panel1.Height))
//    {
//        panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
//        bmp.Save(@"test/" + textBox5.Text + ".bmp");
//        // bmp.save(@"test/"+ textBox5.Text + "bmp");
//    }
//}

