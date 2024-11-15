using BLL;
using CustomControl.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class HomeForm : Form
    {
        private AppDataProvider _appDataProvider;

        public event EventHandler<Form> ShowModalRequested;

        public HomeForm(EventHandler<Form> showModalRequested)
        {
            InitializeComponent();
            _appDataProvider = AppDataProvider.Instance;
            ShowModalRequested = showModalRequested;
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < 2; i++)
            {
                PostCommon postCommon = new PostCommon();
                postCommon.Dock = DockStyle.Top;

                //if (_appDataProvider.MainForm is MainForm mainForm)
                //{
                //    postCommon.ShowModalRequested += mainForm.ShowModalRequest;
                //}
                //else
                //{
                //    // Xử lý khi MainForm không hợp lệ hoặc chưa được khởi tạo
                //    MessageBox.Show("MainForm is not properly initialized.");
                //}

                postCommon.ShowModalRequested += ShowModalRequested;
                //postCommon.ShowModalRequested += ((MainForm)_appDataProvider.MainForm).ShowModalRequest;
                panelPosts.Controls.Add(postCommon);
            }
        }
    }
}
