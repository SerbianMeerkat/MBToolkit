using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBToolkit
{
    public partial class AppControl : UserControl
    {
        TKApp app;

        public AppControl(TKApp app)
        {
            this.app = app;

            InitializeComponent();
        }

        private void AppControl_Load(object sender, EventArgs e)
        {
            appName.Text = app.Name;
            appLogo.Image = app.Logo;
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            app.Launch();

            Application.Exit();
        }
    }
}
