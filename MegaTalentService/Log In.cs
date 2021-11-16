using MegaTalentService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MegaTalentService
{
    public partial class Log_In : Form
    {
        Entities entities = new Entities();


        public Log_In()
        {

            InitializeComponent();


            NotSeePasswordBtn.Visible = false;
            SeePasswordBtn.Visible = false;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Dashboard index = new New_Dashboard();
            index.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Log_In_Load(object sender, EventArgs e)
        {

        }
        
       
        


        private void loginbtn_Click(object sender, EventArgs e)
        {
            
            if (usernametxt.Text != "إسم المستخدم" && passwordtxt.Text != "كلمة المرور")
            {

                var user = (from s in entities.Logins
                            where s.UserName == usernametxt.Text && s.Password == passwordtxt.Text
                            select s).FirstOrDefault();

                if (user != null)
                {
                    New_Dashboard index = new New_Dashboard();
                    index.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("عفوا لا يوجد حساب بإسم المستخدم وكلمة المرور هذان",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("من فضلك قم بملئ الحقول الفارغة",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void usernametxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text))
            {

                e.Cancel = true;
                usernametxt.Focus();
                errorProvider1.SetError(usernametxt, "من فضلك قم بإدخال اسم المستخدم");

            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(usernametxt, null);
            }
            
        }

        private void passwordtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordtxt.Text))
            {

                e.Cancel = true;
                passwordtxt.Focus();
                errorProvider1.SetError(passwordtxt, "من فضلك قم بإدخال كلمة المرور");

            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(passwordtxt, null);
            }
        }

       
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register index = new Register();
            index.Show();
            this.Hide();
        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void passwordtxt_Enter(object sender, EventArgs e)
        {
            if(passwordtxt.Text == "كلمة المرور")
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

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            
            if(passwordtxt.Text == "كلمة المرور")
            {
                NotSeePasswordBtn.Visible = false;
                SeePasswordBtn.Visible = false;
            }
            else if(passwordtxt.PasswordChar == '*')
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
            NotSeePasswordBtn.Visible = true;
            SeePasswordBtn.Visible = false;
        }

        private void NotSeePasswordBtn_Click(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
            NotSeePasswordBtn.Visible = false;
            SeePasswordBtn.Visible = true;
        }
    }
}
