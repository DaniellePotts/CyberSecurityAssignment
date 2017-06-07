using CyberSecurity.Data;
using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class UserDetailsFrm : Form
    {
        /*This page doesnt really do anything security wise, it just displays the users data. the user has the option to move from this page to the edit details page*/
        long id;
        User user;
        public UserDetailsFrm(long id)
        {
            InitializeComponent();
            this.id = id;

            var userSevice = new UserService();
            user = userSevice.GetUser(id);
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            if(user.Details == null)
            {
                user.Details = new UserDetails();
            }
            if(user.GuineaPigData == null)
            {
                user.GuineaPigData = new GuineaPigData();
            }
            txtName.Text = user.Details.FirstName + " " +
                           user.Details.MiddleNames + " " +
                           user.Details.LastName;

            txtAddress.Text = user.Details.Address;
            emailAddress.Text = user.Details.EmailAddress;
            phoneNumber.Text = user.Details.PhoneNumber;

            txtUsername.Text = user.Username;

            guineaPigNameTxt.Text = user.GuineaPigData.Name;
            ageTxt.Text = user.GuineaPigData.Age.ToString();
            colorsTxt.Text = user.GuineaPigData.Colour2 != "" ? user.GuineaPigData.Colour1 + " & " + user.GuineaPigData.Colour2 : user.GuineaPigData.Colour1;
            cuteRankTxt.Text = user.GuineaPigData.CuteRanking.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editDetailsLogin = new EditDetailsLogin(id);
            editDetailsLogin.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainUi = new MainUI(id);
            mainUi.Show();
        }
    }
}
