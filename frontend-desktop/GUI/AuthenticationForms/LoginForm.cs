using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL.DataProviders;
using BLL.Services;
namespace GUI.AuthenticationForms
{
    public partial class LoginForm : Form
    {
        private event EventHandler goToRegister;
        private readonly AuthService _authService;
        public LoginForm(EventHandler GoToRegister)
        {
            InitializeComponent();
            this.goToRegister = GoToRegister;
            this.labelGoToRegister.Click += LabelGoToRegister_Click;
        }

        private void LabelGoToRegister_Click(object sender, EventArgs e)
        {
            goToRegister?.Invoke(this, EventArgs.Empty);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            MessageBox.Show(username);

            try
            {
                // Gọi AuthDataProvider để xử lý đăng nhập
                await AuthDataProvider.Instance.LoginAsync(username, password);

                // Nếu đăng nhập thành công
                if (AuthDataProvider.Instance.CurrentUser != null)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm(); // Điều hướng đến MainForm
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
