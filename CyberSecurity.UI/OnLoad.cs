using CyberSecurity.Data;
using CyberSecurity.Services;
using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class OnLoad : Form
    {
        /*This page is the first page that loads when the user starts the program. this part lets the user navigate to either; create an account or login pages*/
        public OnLoad()
        {
            InitializeComponent();
        }

        private void OnLoad_Load(object sender, EventArgs e)
        {
            var userService = new UserService();
    
            if (!userService.CheckUsersExist()) //if there are no users in the db, dont let the user log in (i.e. dont display UI function to do so)
            {
                loginBtn.Visible = false;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (loginBtn.Visible)
            {
                this.Hide();
                var loginForm = new Login();
                loginForm.Show();
            }
        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserFrm createUserFrm = new CreateUserFrm();
            createUserFrm.Show();
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
