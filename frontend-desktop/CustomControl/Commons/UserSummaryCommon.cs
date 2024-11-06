using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class UserSummaryCommon : UserControl
    {
        public UserSummaryCommon()
        {
            InitializeComponent();
            this.actionButton.MouseHover += ActionButton_MouseHover;
            this.actionButton.MouseLeave += ActionButton_MouseLeave;
        }

        private void ActionButton_MouseHover(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.FromArgb(144, 144, 144);
        }
        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.White;
        }
    }
}

