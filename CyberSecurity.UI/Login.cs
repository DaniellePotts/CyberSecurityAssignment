using CyberSecurity.Data;
using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class Login : Form
    {
        //this page lets the user login to the main system. in order to login, the user must correctly enter their username and password.
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        int loginAttempts = 0;

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")//check we have data to work with in the fields
            {
                MessageBox.Show("All fields must have an entry to attempt to login", "Invalid", MessageBoxButtons.OK);
            }
            else
            {
                var userService = new UserService();
                var user = userService.FindUser(usernameTxt.Text.ToString(), passwordTxt.Text.ToString());
                if (user == null)
                {
                    //if the user inputs incorrect data, dont let them know if it was the password or username they got wrong.
                    MessageBox.Show("Login failed. Check your username and password entries.", "Error", MessageBoxButtons.OK);
                    loginAttempts++; //increment login attempts
                    
                    if (loginAttempts == 3) //if login attempts ==3, lock system for 30 seconds, disable fields and display timer.
                    {
                        usernameTxt.Enabled = false;
                        passwordTxt.Enabled = false;
                        loginBtn.Enabled = false;
                        timeTxt.Visible = true;
                        var now = DateTime.Now;
                        while ((DateTime.Now - now).TotalSeconds <= 30) //when we have surpassed 30 seconds, we re-enable everything
                        {
                            timeTxt.Text = (DateTime.Now - now).TotalSeconds.ToString();
                            timeTxt.Refresh();
                        }

                        usernameTxt.Enabled = true;
                        passwordTxt.Enabled = true;
                        loginBtn.Enabled = true;
                        timeTxt.Visible = false;
                        loginAttempts = 0;
                    }
                }
                else
                {
                    //if login is succesful...

                    user.PasswordUses++; //incremment password uses
                    userService.UpdateUser(user);

                    if (user.PasswordUses >= 5) //if password has been used to login in at least five times, prompt the user to change it (kinda like a 72 day change password)
                    {
                        var result = MessageBox.Show("It has been at least 5 days since you last changed your password. Would you like to change it now?", "Password", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            this.Hide();
                            var changePassword = new ChangePassword(user.Id); //if user wants to change their password take them straight to the changePassword UI
                            changePassword.Show();
                        }
                        else //otherwise take them to the mainUI
                        {
                            this.Show();
                            var mainUi = new MainUI(user.Id);
                            mainUi.Show();
                        }
                    }
                    else
                    {
                        this.Show();
                        var mainUi = new MainUI(user.Id);
                        mainUi.Show();
                    }
                }
            }
        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var onLoad = new OnLoad();
            onLoad.Show();
        }
    }
}
