using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB.VideoLengthTool.Forms
{
    public partial class App : Form
    {
        public static App singleton;

        static Timer timer;

        public App()
        {
            singleton = this;

            InitializeComponent();
        }

        private async void App_Load(object sender, EventArgs e)
        {
            await Task.Delay(500);

            bool regularLaunch = true;

            foreach (string arg in Program.arguments)
            {
                if (arg.EndsWith(".hschema"))
                {
                    CompareWindow.Open(Schema.LoadFromFile(arg));
                    regularLaunch = false;
                }
            }

            if (regularLaunch)
                new LandingPage().Show();

            timer = new Timer();

            timer.Tick += (s, a) =>
            {
                if (Application.OpenForms.Cast<Form>().Where(x => x.Visible == true).Count() == 0)
                    singleton.Close();
            };

            timer.Interval = 100;
            timer.Enabled = true;

            Hide();
        }
    }
}
