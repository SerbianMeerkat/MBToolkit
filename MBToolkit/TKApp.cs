using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBToolkit
{
    public struct TKApp
    {
        public string Name;
        public Image Logo;

        public string ExecutablePath;

        public TKApp(string name, string exePath, Image logo = null) : this()
        {
            Name = name;
            ExecutablePath = exePath;

            Logo = logo == null ? Icon.ExtractAssociatedIcon(exePath).ToBitmap() : logo;
        }

        public void Launch()
        {
            Process.Start(ExecutablePath);
        }
    }
}
