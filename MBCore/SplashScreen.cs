using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBCore
{
    public partial class SplashScreen : Form
    {
        Action AfterShow;

        public SplashScreen(string title, Image logo, Color backColor, Action afterShow)
        {
            InitializeComponent();

            programLogo.Image = logo;
            titleLabel.Text = title;
            BackColor = backColor;

            AfterShow = afterShow;
        }

        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            await Task.Delay(500);

            AfterShow?.Invoke();

            Hide();
        }
    }
}
