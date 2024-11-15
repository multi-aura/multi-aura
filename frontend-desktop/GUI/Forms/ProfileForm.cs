using CustomControl.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace GUI.Forms
{
    public partial class ProfileForm : Form
    {
        private Label selectedLabel;

        public ProfileForm()
        {
            InitializeComponent();
            RegisterHoverAndClickEventsForLabels();
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < 50; i++)
            {
                BriefPost briefPost = new BriefPost();
                panelResults.Controls.Add(briefPost);
            }
        }

        // Đăng ký sự kiện Hover, Leave, và Click cho các Label
        private void RegisterHoverAndClickEventsForLabels()
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    // Gán sự kiện MouseHover và MouseLeave
                    label.MouseHover += Label_MouseHover;
                    label.MouseLeave += Label_MouseLeave;

                    // Gán sự kiện Click
                    label.Click += Label_Click;
                }
            }

            SetSelectedLabel(labelPosts);
        }

        // Sự kiện Hover: làm cho text của label thành bold
        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label && label != selectedLabel)
            {
                SetFocusedLabel(label, true);
            }
        }

        // Sự kiện Leave: làm cho text của label trở về bình thường
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label && label != selectedLabel)
            {
                SetFocusedLabel(label, false);
            }
        }

        // Sự kiện Click: làm cho text của label được click thành bold, các label khác bình thường
        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                SetSelectedLabel(clickedLabel);

                //TODO: make changes in panelResults

            }
        }

        // Phương thức đặt kiểu chữ của Label
        private void SetFocusedLabel(Label label, bool isFocused)
        {
            label.Font = new Font(label.Font, isFocused ? FontStyle.Bold : FontStyle.Regular);
            label.BackColor = isFocused ? Color.FromArgb(148, 148, 148) : Color.Transparent;
        }

        private void UnsetSelectedLabel(Label label)
        {
            label.Font = new Font(label.Font, FontStyle.Regular);
            label.BackColor = Color.Transparent;
        }

        private void SetSelectedLabel(Label clickedLabel)
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    UnsetSelectedLabel(label);
                }
            }

            clickedLabel.Font = new Font(clickedLabel.Font, FontStyle.Bold);
            clickedLabel.BackColor = Color.Transparent;
            selectedLabel = clickedLabel;
        }
    }
}
