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
    public partial class Register : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=5admaa;Integrated Security=True");
        SqlCommand cmd;
        public Register()
        {
            InitializeComponent();


            NotSeePasswordBtn.Visible = false;
            SeePasswordBtn.Visible = false;
        }

        private void log_in_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

    

        private void loginbtn_Click(object sender, EventArgs e)
        {
            Log_In index = new Log_In();
            index.Show();
            this.Hide();
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(usernametxt.Text) == false)
            {
                if (passwordtxt.Text == passwordtxt2.Text)
                {
                    if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
                    {
                        con.Open();
                        cmd = new SqlCommand("insert into Login values" +
                            "('" + usernametxt.Text + "','" + passwordtxt.Text + "','"
                            + Convert.ToInt32(radioButton1.Checked ||   
                            radioButton2.Checked || radioButton3.Checked) + "')", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم إنشاء حسابك بنجاح");
                        con.Close();
                        //

                        //Log_In index = new Log_In();
                        //index.Show();
                        //this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("من فضلك قم بإختيار وظيفتك");

                    }
                }
                else
                {
                    MessageBox.Show("كلمة المرور غير متطابقة");
                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بكتابة اسم المستخدم");
            }
            
            
        }


        
        private void passwordtxt2_TextChanged(object sender, EventArgs e)
        {
          

        }


        private void Register_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].WindowState = FormWindowState.Maximized;
            }
        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Log_InCloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Log_InMinimizedBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void usernamelbl_Click(object sender, EventArgs e)
        {

        }

        private void usernametxt_Enter(object sender, EventArgs e)
        {
            if (usernametxt.Text == "إسم المستخدم")
            {
                usernametxt.Text = "";
                usernametxt.ForeColor = Color.Aqua;
            }
        }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            if (usernametxt.Text == "")
            {
                usernametxt.Text = "إسم المستخدم";
                usernametxt.ForeColor = Color.DarkGray;
            }
        }

        private void passwordtxt_Enter(object sender, EventArgs e)
        {
            if (passwordtxt.Text == "كلمة المرور")
            {
                passwordtxt.Text = "";
                passwordtxt.ForeColor = Color.Aqua;
                passwordtxt.PasswordChar = '*';

            }
        }

        private void passwordtxt_Leave(object sender, EventArgs e)
        {
            if (passwordtxt.Text == "")
            {
                passwordtxt.Text = "كلمة المرور";
                passwordtxt.ForeColor = Color.DarkGray;
                passwordtxt.PasswordChar = '\0';

            }
        }

        private void passwordtxt2_Enter(object sender, EventArgs e)
        {
            if (passwordtxt2.Text == "تأكيد كلمة المرور")
            {
                passwordtxt2.Text = "";
                passwordtxt2.ForeColor = Color.Aqua;
                passwordtxt2.PasswordChar = '*';

            }
        }

        private void passwordtxt2_Leave(object sender, EventArgs e)
        {
            if (passwordtxt2.Text == "")
            {
                passwordtxt2.Text = "تأكيد كلمة المرور";
                passwordtxt2.ForeColor = Color.DarkGray;
                passwordtxt2.PasswordChar = '\0';

            }
        }

        private void passwordtxt2_TextChanged_1(object sender, EventArgs e)
        {
            //if (passwordtxt.Text == "كلمة المرور" && passwordtxt2.Text == "تأكيد كلمة المرور")
            //{
            //    NotSeePasswordBtn.Visible = false;
            //    SeePasswordBtn.Visible = false;
            //}
            //else if (passwordtxt.PasswordChar == '*' && passwordtxt2.PasswordChar == '*')
            //{
            //    SeePasswordBtn.Visible = true;
            //    NotSeePasswordBtn.Visible = false;
            //}
            //else
            //{
            //    SeePasswordBtn.Visible = false;
            //    NotSeePasswordBtn.Visible = true;
            //}
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            if (passwordtxt.Text == "كلمة المرور" && passwordtxt2.Text == "تأكيد كلمة المرور")
            {
                NotSeePasswordBtn.Visible = false;
                SeePasswordBtn.Visible = false;
            }
            else if (passwordtxt.PasswordChar == '*' && passwordtxt2.PasswordChar == '*')
            {
                SeePasswordBtn.Visible = true;
                NotSeePasswordBtn.Visible = false;
            }
            else
            {
                SeePasswordBtn.Visible = false;
                NotSeePasswordBtn.Visible = true;
            }
        }

        private void SeePasswordBtn_Click(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '\0';
            passwordtxt2.PasswordChar = '\0';
            NotSeePasswordBtn.Visible = true;
            SeePasswordBtn.Visible = false;
        }

        private void NotSeePasswordBtn_Click(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
            passwordtxt2.PasswordChar = '*';
            NotSeePasswordBtn.Visible = false;
            SeePasswordBtn.Visible = true;
        }
    }
}
