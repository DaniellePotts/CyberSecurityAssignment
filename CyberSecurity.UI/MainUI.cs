using System;
using System.Windows.Forms;

namespace CyberSecurity.UI
{
    public partial class MainUI : Form
    {
        long id; //pass the id of the user through the system
        /*UI is just a placeholder in order to help the user move from feature to feature*/
        public MainUI(long id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editLogin = new EditDetailsLogin(id);
            editLogin.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            var changePassUi = new ChangePassword(id);
            changePassUi.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userDetials = new UserDetailsFrm(id);
            userDetials.Show();
        }
    }
}
