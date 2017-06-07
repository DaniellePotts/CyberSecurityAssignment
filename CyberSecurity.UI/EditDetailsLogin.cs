using CyberSecurity.Data;
using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class EditDetailsLogin : Form
    {
        /*This page links to the edit page. this page requires that the user logs in again in order to edit their data. this is an attempt to enforce integrity protection. this should protect the user from having
         their data edited in such situations where the user accidently leaves their account on, and someone passes by and attempts to change their data without their permission*/
        long id;
        int loginAttempts = 0;
        public EditDetailsLogin(long id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void EditDetailsLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            /*Check the user has entered the login details correctly. we want to protect the
             integrity of users and as such, if the system is left on, we dont wanna passerbys to be
             able to change the users details. therefore, we require the user login again, and if they
             get the password wrong, we want to end the session*/
            var userService = new UserService();
            var user = userService.FindUser(txtUsername.Text.ToString(), txtPassword.Text.ToString());
            if (user != null)
            {
                this.Hide();
                var editDetails = new EditDetails(user.Id);
                editDetails.Show();
            }
            else
            {
                //if login fails...

                MessageBox.Show("Details were incorrect. Try again.", "Error", MessageBoxButtons.OK);
                loginAttempts++; //increment login attempts

                if(loginAttempts == 3) //if login attempts == 3, log the user out
                {
                    MessageBox.Show("Password was incorrect 3 times, system will now lock.", "Invalid Password", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainUi = new MainUI(id);
            mainUi.Show();
        }
    }
}
