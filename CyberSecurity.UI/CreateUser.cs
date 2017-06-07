using CyberSecurity.Data;
using CyberSecurity.Services;
using System;
using System.Linq;
using System.Windows.Forms;
namespace CyberSecurity.UI
{
    public partial class CreateUserFrm : Form
    {
        /*This page lets the user create an account. in order to do so, the user must create a unique username and they must create a medium or strong password. the user can create their password themselves
         or they can generate a password*/
        UserService userService;
        private PasswordStrength strength;
        PasswordGenerator helper;
        public CreateUserFrm()
        {
            InitializeComponent();
            userService = new UserService();
            helper = new PasswordGenerator();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var onLoad = new OnLoad();
            onLoad.Show();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {
            //validate the password, output relevant messages to inform the user of the situation
            if (usernameTxt.Text == "" || passwordTxt.Text == "" || retypedPassTxt.Text == "") //first check we have data in the input fields
            {
                MessageBox.Show("Username and password fields are required to register.", "error", MessageBoxButtons.OK);
            }
            else if(passwordTxt.Text != retypedPassTxt.Text) //check that the new password and the retyped version match
            {
                MessageBox.Show("Passwords do not match.");
            }
            else if (!userService.CheckUsernameIsUnique(usernameTxt.Text)) //check the username is unique
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK);
            }
            else if (ValidateUsername(usernameTxt.Text)) //check the username does not contain special characters
            {
                MessageBox.Show("Username cannot contain special characters", "Error", MessageBoxButtons.OK);
            }
            else if (helper.CheckAgainstPhrases(passwordTxt.Text) == PasswordStrength.Weak)
            {
                MessageBox.Show("Password matches common phrases or the example password.", "Error", MessageBoxButtons.OK);
            }
            else if (strength == PasswordStrength.Weak) //check the password strength is not weak
            {
                MessageBox.Show("Password is too weak", "error", MessageBoxButtons.OK);
            }
            else
            {
                //then we can create the user, and add them to db. a new id is generated at the service layer.
                var user = new User
                {
                    Username = usernameTxt.Text.ToString(),
                    Password = passwordTxt.Text.ToString(),
                    PasswordUses = 0,
                };

                userService.AddUser(user);
                var passService = new PasswordService();

                var newPassword = new PasswordArchive //create a new password archive and store the users first password
                {
                    ID = user.Id,
                    Username = user.Username,
                    Passwords = new System.Collections.Generic.List<string>(),
                };

                newPassword.Passwords.Add(user.Password);

                passService.Put(newPassword);

                if (generatePassCheck.Checked) //if the password was generated, save the password to a file
                {
                    var passGen = new PasswordGenerator();
                    passGen.SavePasswordToFile(passwordTxt.Text,usernameTxt.Text);
                    MessageBox.Show("Generated Password was saved to project folders", "Password Saved", MessageBoxButtons.OK);
                }

                MessageBox.Show(generatePassCheck.Checked ? "User created! Password was saved to a file.": "User Created!", "User Created", MessageBoxButtons.OK);
                this.Hide();
                var mainUi = new MainUI(user.Id);
                mainUi.Show();
            }
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
            var passGen = new PasswordGenerator();
            strength = passGen.DetermineStrength(passwordTxt.Text.ToString());
            passwordStrengthLbl.Text = "Password Strength: " + strength.ToString(); //dynamically update the strength of the password

            if(retypedPassTxt.Text != "")
            {
                passwordsMatchTxt.Text = passwordTxt.Text == retypedPassTxt.Text ? "Passwords match" : "Passwords do not match";
            }
        }

        private void generatePassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (generatePassCheck.Checked)
            {
                passwordTxt.Enabled = false;
                retypedPassTxt.Enabled = false;
                if (passwordTxt.Text != "")
                {
                    passwordTxt.Text = "";
                }

                var passGen = new PasswordGenerator();

                passwordTxt.Text = passGen.GeneratePassword(); //generate a new password for the user if they choose to generate a new one
                retypedPassTxt.Text = passwordTxt.Text;
            }
            else
            {
                passwordTxt.Enabled = true;
                retypedPassTxt.Enabled = true;
            }
        }

        public bool ValidateUsername(string username) //check the username does not contain characters
        {
            return username.Any(ch => !Char.IsLetterOrDigit(ch));
        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {
            if (ValidateUsername(usernameTxt.Text))
            {
                specialCharsTxt.Text = "Username cannot contain special characters e.g: @#/";
            }
            else
            {
                specialCharsTxt.Text = "";
            }
        }

        private void retypedPassTxt_TextChanged(object sender, EventArgs e)
        {
            if (passwordTxt.Text != "")
            {
                passwordsMatchTxt.Text = passwordTxt.Text == retypedPassTxt.Text ? "Passwords match" : "Passwords do not match";
            }
        }
    }
}
