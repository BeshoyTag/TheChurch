using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MegaTalentService
{
    public partial class New_Dashboard : Form
    {



        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse


         );

        public New_Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            PnlNav.Height = DashboardBtn.Height;
            PnlNav.Top = DashboardBtn.Top;
            PnlNav.Left = DashboardBtn.Left;
            DashboardBtn.BackColor = Color.FromArgb(46, 51, 73);
            //
            //label2.Text = "الصفحة الرئيسية";
            this.PnlFormLoader.Controls.Clear();
            PeopleSearch search = new PeopleSearch()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            search.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(search);
            search.Show();
        }

        private void New_Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = DashboardBtn.Height;
            PnlNav.Top = DashboardBtn.Top;
            PnlNav.Left = DashboardBtn.Left;
            DashboardBtn.BackColor = Color.FromArgb(46, 51, 73);
            //
           // label2.Text = "الصفحة الرئيسية";
            this.PnlFormLoader.Controls.Clear();
            PeopleSearch search = new PeopleSearch()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            search.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(search);
            search.Show();
            //
            
            
        }

        private void InsertPersonBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = InsertPersonBtn.Height;
            PnlNav.Top = InsertPersonBtn.Top;
            PnlNav.Left = InsertPersonBtn.Left;
            InsertPersonBtn.BackColor = Color.FromArgb(46, 51, 73);
            //
          //  label2.Text = "إدخال مخدوم";
            this.PnlFormLoader.Controls.Clear();
            InsertPerson person = new InsertPerson()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            person.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(person);
            person.Show();
            

        }

        private void EditInfoBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = EditInfoBtn.Height;
            PnlNav.Top = EditInfoBtn.Top;
            PnlNav.Left = EditInfoBtn.Left;
            EditInfoBtn.BackColor = Color.FromArgb(46, 51, 73);

            this.PnlFormLoader.Controls.Clear();
            Edit EditInfoPerson = new Edit()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            EditInfoPerson.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(EditInfoPerson);
            EditInfoPerson.Show();

        }

        private void AddServiceBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = AddServiceBtn.Height;
            PnlNav.Top = AddServiceBtn.Top;
            PnlNav.Left = AddServiceBtn.Left;
            AddServiceBtn.BackColor = Color.FromArgb(46, 51, 73);
            //
            //label2.Text = "إضافة خدمة";
            this.PnlFormLoader.Controls.Clear();
            AddService AddService_Vrb = new AddService()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            AddService_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(AddService_Vrb);
            AddService_Vrb.Show();
        }

        private void ServiceTakingBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = ServiceTakingBtn.Height;
            PnlNav.Top = ServiceTakingBtn.Top;
            PnlNav.Left = ServiceTakingBtn.Left;
            ServiceTakingBtn.BackColor = Color.FromArgb(46, 51, 73);

            //

            this.PnlFormLoader.Controls.Clear();
            The_Dashboard dashboard = new The_Dashboard()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void ContactUsBtn_Click(object sender, EventArgs e)
        {
            PnlNav.Height = ContactUsBtn.Height;
            PnlNav.Top = ContactUsBtn.Top;
            PnlNav.Left = ContactUsBtn.Left;
            ContactUsBtn.BackColor = Color.FromArgb(46, 51, 73);
            //
            //Info index = new Info();
            //index.Show();
            //this.Hide();

            //label2.Text = "تواصل معنا";
            this.PnlFormLoader.Controls.Clear();
            Info Information = new Info()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Information.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Information);
            Information.Show(); 
        }





        private void DashboardBtn_Leave(object sender, EventArgs e)
        {
            DashboardBtn.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void InsertPersonBtn_Leave(object sender, EventArgs e)
        {
            InsertPersonBtn.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void EditInfoBtn_Leave(object sender, EventArgs e)
        {
            EditInfoBtn.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void AddServiceBtn_Leave(object sender, EventArgs e)
        {
            AddServiceBtn.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void ServiceTakingBtn_Leave(object sender, EventArgs e)
        {
            ServiceTakingBtn.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void ContactUsBtn_Leave(object sender, EventArgs e)
        {
            ContactUsBtn.BackColor = Color.FromArgb(24, 30, 54);

        }



        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void PnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignOutBtn_Click_1(object sender, EventArgs e)
        {
            Log_In index = new Log_In();
            index.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            New_Dashboard IDCard = (New_Dashboard)Application.OpenForms["New_Dashboard"];
            Panel pnl = (Panel)IDCard.Controls["PnlFormLoader"];
            pnl.Controls.Clear();
            DesigenID design_id = new DesigenID()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            design_id.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(design_id);
            design_id.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Register index = new Register();
            index.Show();
            this.Hide();
        }
    }
}
