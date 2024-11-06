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
    public partial class SuggestForYouCommon : UserControl
    {
        public SuggestForYouCommon()
        {
            InitializeComponent();
            this.labelSeeAll.MouseHover += LabelSeeAll_MouseHover;
            this.labelSeeAll.MouseLeave += LabelSeeAll_MouseLeave;
        }

        private void LabelSeeAll_MouseHover(object sender, EventArgs e)
        {
            this.labelSeeAll.ForeColor = Color.FromArgb(144, 144, 144);
        }
        private void LabelSeeAll_MouseLeave(object sender, EventArgs e)
        {
            this.labelSeeAll.ForeColor = Color.White;
        }
    }
}
