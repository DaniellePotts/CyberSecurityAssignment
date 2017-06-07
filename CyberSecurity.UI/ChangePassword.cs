using CyberSecurity.Data;
using CyberSecurity.Services;
using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class ChangePassword : Form
    {
        /*This page lets the user change their password. in order to do so, the user must correctly enter their own password, and type a new password that is:
         a) unique (hasnt been used before) b) is not weak c) is not similar to the previous password*/
        User user;
        UserService service;
        PasswordGenerator gen;
        PasswordService passService;

        int passAttempts = 0;
        public ChangePassword(long id)
        {
            InitializeComponent();
            service = new UserService();
            gen = new PasswordGenerator();
            user = service.GetUser(id);
            passService = new PasswordService();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate the new password
            if(newPassDupeTxt.Text == "" || newPassTxt.Text == "" || oldPassTxt.Text == "") //first, we check that the user has entered data
            {
                MessageBox.Show("All fields must contain data", "Error", MessageBoxButtons.OK);
            }
            else if (newPassTxt.Text != newPassDupeTxt.Text)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK); //secondly, we check the newly entered password is matched in the duplicated input box
            }
            else if (oldPassTxt.Text != user.Password) //third, we check that the password was correct
            {
                passAttempts++; //increment the number of attempts the password has been attempted
                
                MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK);

                if(passAttempts == 3) //if the password attempts is 3, then we exit the system
                {
                    MessageBox.Show("Password has been entered incorrectly 3 times. System will log out");
                    this.Hide();
                    var login = new Login();
                    login.Show();
                }
            }
            else if(newPassTxt.Text == user.Password) //check that the new password does not equal the users current password
            {
                MessageBox.Show("The new password is the same as the old password.", "Error", MessageBoxButtons.OK);
            }
            else if(user.Details != null)
            {
                if(user.Details.FirstName == newPassTxt.Text || user.Details.MiddleNames == newPassTxt.Text || user.Details.LastName == newPassTxt.Text)
                {
                    MessageBox.Show("Password should not match any of your names, as that is not a strong password", "Invalid Password", MessageBoxButtons.OK);
                }
                else if(newPassTxt.Text.Contains(user.Details.FirstName) || newPassTxt.Text.Contains(user.Details.MiddleNames) || newPassTxt.Text.Contains(user.Details.LastName))
                {
                    MessageBox.Show("Password should not match or contain any of your names, as that is not a strong password", "Invalid Password", MessageBoxButtons.OK);
                }
            }
            else if(user.GuineaPigData != null)
            {
                if(user.GuineaPigData.Name == newPassTxt.Text)
                {
                    MessageBox.Show("Password should not match any of your guinea pig's name, as that is not a strong password", "Invalid Password", MessageBoxButtons.OK);
                }
                else if (newPassTxt.Text.Contains(user.GuineaPigData.Name))
                {
                    MessageBox.Show("Password should not match or contain your guinea pig's name, as that is not a strong password", "Invalid Password", MessageBoxButtons.OK);
                }
            }
            else if(gen.DetermineStrength(newPassTxt.Text) == PasswordStrength.Weak) //check the password strength
            {
                MessageBox.Show("Password is too weak to be saved.", "Invalid Password", MessageBoxButtons.OK);
            }
            else if(gen.CheckPasswordSimilarities(user.Password, newPassTxt.Text) > 10) //ensure the password is not similar to the old password
            {
                MessageBox.Show("Password is too similar to the previous password.", "Invalid Password", MessageBoxButtons.OK);
            }
            else if (passService.CheckPasswords(user.Username,newPassTxt.Text)) //check that the password has not been used before
            {
                MessageBox.Show("This password has been used before and it cannot be used again.", "Invalid Password", MessageBoxButtons.OK);
            }
            else
            {
                //if user passes all validation, we can change the password
                user.Password = newPassTxt.Text; 

                if (passGenCheck.Checked) //if the password was generated, we need to save it to a file
                {
                    gen.SavePasswordToFile(newPassTxt.Text,user.Username);
                }

                service.UpdateUser(user); //we can then update the user
                passService.Update(user.Username, newPassTxt.Text); //update the password archive and then return to the mainUI
                MessageBox.Show("Password was changed", "Password Updated", MessageBoxButtons.OK);
                this.Hide();
                var previousForm = new MainUI(user.Id);
                previousForm.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var previousForm = new MainUI(user.Id);
            previousForm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //dyanamic checks on the password stength, constantly output to the user the current password strength
            txtPasswordStrength.Text = "Password Strength: " + gen.DetermineStrength(newPassTxt.Text).ToString();

            if(newPassDupeTxt.Text != "")
            {
                passwordMatchtxt.Text = newPassTxt.Text == newPassDupeTxt.Text ? "Passwords match" : "Passwords do not match";
            }
        }

        private void newPassDupeTxt_TextChanged(object sender, EventArgs e)
        {
            if (newPassTxt.Text != "")
            {
                passwordMatchtxt.Text = newPassTxt.Text == newPassDupeTxt.Text ? "Passwords match" : "Passwords do not match";
            }
        }

        private void passGenCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passGenCheck.Checked)
            {
                if(newPassTxt.Text != "")
                {
                    newPassTxt.Text = "";
                }
                if(newPassDupeTxt.Text != "")
                {
                    newPassDupeTxt.Text = "";
                }
                newPassTxt.Enabled = false;
                newPassDupeTxt.Enabled = false;
                newPassTxt.Text = gen.GeneratePassword(); //if the user checks "generate password", then generate a new password, disable input on the text boxes
                newPassDupeTxt.Text = newPassTxt.Text; //dupelicate the password
            }
            else
            {
                newPassTxt.Enabled = true;
                newPassDupeTxt.Enabled = true;
            }
        }
    }
}
