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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        static TKApp[] apps = new TKApp[]
        {
            new TKApp("Video Length Tool", "MB.VideoLengthTool.exe"),
            new TKApp("Video 2", "MB.VideoLengthTool.exe")
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = 0;

            foreach(TKApp app in apps)
            {
                var control = new AppControl(app);

                width += 15 + control.Width;

                appPanel.Controls.Add(control);
            }

            width += 15;

            Size = new Size(width, Height);
        }
    }
}
