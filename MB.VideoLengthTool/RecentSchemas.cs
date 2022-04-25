using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.VideoLengthTool
{
    public static class RecentSchemas
    {
        public static event EventHandler RecentSchemasChanged;

        public static string[] GetRecentSchemas()
        {
            CheckForDeadPaths();

            return Properties.Settings.Default.RecentSchemas.Cast<string>().ToList().ToArray();
        }

        static void CheckForDeadPaths()
        {
            for (int i = 0; i < Properties.Settings.Default.RecentSchemas.Count;)
            {
                var path = Properties.Settings.Default.RecentSchemas[i];

                if (!File.Exists(path))
                {
                    Properties.Settings.Default.RecentSchemas.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            Properties.Settings.Default.Save();
        }

        public static void AddRecentSchema(string path)
        {
            if (Properties.Settings.Default.RecentSchemas == null)
                Properties.Settings.Default.RecentSchemas = new System.Collections.Specialized.StringCollection();

            if (Properties.Settings.Default.RecentSchemas.Contains(path))
                Properties.Settings.Default.RecentSchemas.Remove(path);

            Properties.Settings.Default.RecentSchemas.Add(path);

            Properties.Settings.Default.Save();

            RecentSchemasChanged?.Invoke(null, null);
        }
    }
}
