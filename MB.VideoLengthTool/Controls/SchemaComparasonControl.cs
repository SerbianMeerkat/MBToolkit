using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MB.VideoLengthTool.Controls
{
    public partial class VideoComparasonControl : UserControl
    {
        public static List<VideoComparasonControl> comparasonControls = new List<VideoComparasonControl>();

        public static void CalculateDifferences()
        {
            TimeSpan time = comparasonControls[0].schemaItem.Time;

            foreach (VideoComparasonControl control in comparasonControls)
            {
                if (control.fileSelected)
                {
                    control.SetDifference(time - control.schemaItem.Time);
                    time += control.VideoLength;
                }
            }
        }

        public string selectedFile;
        public Schema.SchemaItem schemaItem;

        public TimeSpan Difference;

        public bool fileSelected => File.Exists(selectedFile);
        public TimeSpan VideoLength => fileSelected ? TimeSpan.FromSeconds(new WindowsMediaPlayer().newMedia(selectedFile).duration) : TimeSpan.Zero;

        public event EventHandler<VideoSelectedEventArgs> VideoSelected;

        public VideoComparasonControl(Schema.SchemaItem item)
        {
            comparasonControls.Add(this);
            schemaItem = item;

            VideoSelected += (e, a) => CalculateDifferences();

            InitializeComponent();
        }

        ~VideoComparasonControl()
        {
            comparasonControls.Remove(this);
        }

        private void SchemaVideoFileControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            detailsLabel.Text = $"{schemaItem.Name} - Start: {schemaItem.Time} - Video: {VideoLength} ({(fileSelected ? selectedFile : "No file selected")})";

            statusLabel.ForeColor = !fileSelected ? Color.Black : Difference.Minutes >= 1 ? Difference.TotalMilliseconds < 0 ? Color.Orange :  Color.Red : Color.Green;
            statusLabel.Text = fileSelected ? Difference.ToString("g") : "Select file";
        }

        public void SetDifference(TimeSpan span)
        {
            Difference = span;

            UpdateUI();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = dialog.FileName;

                    VideoSelected.Invoke(this, new VideoSelectedEventArgs(this, selectedFile));
                }
            }
        }

        private void VideoComparasonControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }

    public class VideoSelectedEventArgs : EventArgs
    {
        public VideoComparasonControl control;
        public string filePath;

        public VideoSelectedEventArgs(VideoComparasonControl control, string file)
        {
            this.control = control;
            filePath = file;
        }
    }
}
