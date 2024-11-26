using System;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class PostCreationModal : Form
    {
        public PostCreationModal()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;
        }





        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
