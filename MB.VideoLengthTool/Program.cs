using MB.VideoLengthTool.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB.VideoLengthTool
{
    internal static class Program
    {
        public static string[] arguments;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            arguments = args;

            RegisterForFileExtension(".hschema", Application.ExecutablePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }

        public static void Close()
        {
            App.singleton.Close();
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
