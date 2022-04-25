using MB.VideoLengthTool.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBCore;

namespace MB.VideoLengthTool
{
    public static class Program
    {
        public static string[] arguments;

        static Timer timer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            arguments = args;

            RegisterForFileExtension(".hschema", Application.ExecutablePath);

            Application.EnableVisualStyles();
            try { Application.SetCompatibleTextRenderingDefault(false); } catch { }
            Application.Run(new SplashScreen("VIDEO LENGTH TOOL", Properties.Resources.icon, System.Drawing.Color.White, () =>
            {
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
                        Application.Exit();
                };

                timer.Interval = 100;
                timer.Enabled = true;
            }));
        }

        private static void RegisterForFileExtension(string extension, string applicationPath)
        {
            RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + extension);
            FileReg.CreateSubKey("shell\\open\\command").SetValue("", applicationPath + " %1");
            FileReg.Close();

            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
