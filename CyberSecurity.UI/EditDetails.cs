using CyberSecurity.Data;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class EditDetails : Form
    {
        /*This page lets the user edit their details*/
        User user;
        public EditDetails(long id) //pass the id through and use this to load the users data
        {
            InitializeComponent();
            var userService = new UserService();
            user = userService.GetUser(id);
            if(user.Details == null)
            {
                user.Details = new UserDetails();
            }

            if(user.GuineaPigData == null)
            {
                user.GuineaPigData = new GuineaPigData();
            }
        }

        private void EditDetails_Load(object sender, EventArgs e)
        {
            //load in user data (if it exists already) and populate fields
            forenameTxt.Text = user.Details.FirstName;
            middleNameTxt.Text = user.Details.MiddleNames;
            surnameTxt.Text = user.Details.LastName;
            addressTxt.Text = user.Details.Address;
            emailTxt.Text = user.Details.EmailAddress;
            phoneNumberTxt.Text = user.Details.PhoneNumber;

            guineaPigNameTxt.Text = user.GuineaPigData.Name;
            colour1Txt.Text = user.GuineaPigData.Colour1;
            colour2Txt.Text = user.GuineaPigData.Colour2;
            ageTxt.Text = user.GuineaPigData.Age.ToString();
            cuteRankingTxt.Text = user.GuineaPigData.CuteRanking.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsPhoneNumber(phoneNumberTxt.Text)) //validate the phone number
            {
                try
                {
                    user.Details.FirstName = forenameTxt.Text;
                    user.Details.MiddleNames = middleNameTxt.Text;
                    user.Details.LastName = surnameTxt.Text;
                    user.Details.Address = addressTxt.Text;
                    user.Details.PhoneNumber = phoneNumberTxt.Text;
                    user.Details.EmailAddress = emailTxt.Text != String.Empty ? new MailAddress(emailTxt.Text).ToString() : String.Empty; 

                    user.GuineaPigData.Age = Convert.ToInt32(ageTxt.Text);
                    user.GuineaPigData.Name = guineaPigNameTxt.Text;
                    user.GuineaPigData.Colour1 = colour1Txt.Text;
                    user.GuineaPigData.Colour2 = colour2Txt.Text;
                    user.GuineaPigData.CuteRanking = Convert.ToInt32(cuteRankingTxt.Text);

                    var userService = new UserService();
                    userService.UpdateUser(user);

                    MessageBox.Show(user.Username + " details were updated.", "Details Updated", MessageBoxButtons.OK);
                    this.Hide();
                    var mainUi = new MainUI(user.Id);
                    mainUi.Show();
                }
                catch (FormatException fe) //validate formats, ensure we have proper email addresses and numbers where there should be (i.e. age should be 4, not "four")
                {
                    MessageBox.Show(fe.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Input was not a valid phone number.", "Invalid number.", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainFrm = new MainUI(user.Id);
            mainFrm.Show();
        }

        public static bool IsPhoneNumber(string number)
        {
            if(number == String.Empty)
            {
                return true;
            }
            var numberChar = number.ToCharArray();

            if(numberChar.Length != 11) //phone number must be at least 11 characters long
            {
                return false;
            }

            for(var i = 0; i < numberChar.Length; i++) //ensure each character is a number
            {
                if (!Char.IsNumber(numberChar[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
