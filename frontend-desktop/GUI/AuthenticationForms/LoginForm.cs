using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.AuthenticationForms
{
    public partial class LoginForm : Form
    {
        private event EventHandler goToRegister;

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
    }
}
