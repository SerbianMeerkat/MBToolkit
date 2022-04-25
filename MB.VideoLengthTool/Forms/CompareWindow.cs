using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MB.VideoLengthTool.Controls;
using System.IO;

namespace MB.VideoLengthTool.Forms
{
    public partial class CompareWindow : Form
    {
        Schema schema;

        public static CompareWindow singleton;
        List<VideoComparasonControl> schemaVideoFileControls = new List<VideoComparasonControl>();

        bool forceClose;

        public static void Open(Schema schema)
        {
            if (singleton != null)
                singleton.Hide();

            if (!string.IsNullOrEmpty(schema.filePath))
                RecentSchemas.AddRecentSchema(schema.filePath);

            singleton = new CompareWindow(schema);
            singleton.Show();
        }

        public CompareWindow(Schema schema)
        {
            InitializeComponent();

            this.schema = schema;

            Text = $"{schema.filePath}";

            FormClosing += HandleClose;

            Resize += (s, a) =>
            {
                UpdateLayout();
            };
        }

        void HandleClose(object sender, FormClosingEventArgs args)
        {
            if (!forceClose)
            {
                if (MessageBox.Show("Are you sure?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    args.Cancel = false;
                    new LandingPage().Show();
                }
                else
                {
                    args.Cancel = true;
                }
            }

            if (!args.Cancel)
                VideoComparasonControl.comparasonControls.Clear();
        }

        private void CompareWindow_Load(object sender, EventArgs e)
        {
            foreach (var item in schema.items)
            {
                var control = new VideoComparasonControl(item);

                schemaVideoFileControls.Add(control);
                videoFileLayout.Controls.Add(control);
            }

            UpdateLayout();
        }

        void UpdateLayout()
        {
            foreach (Control control in videoFileLayout.Controls)
            {
                control.Width = videoFileLayout.Width - 6 - (videoFileLayout.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
            }
        }

        public void ExportSpreadsheet()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Spreadsheet (*.xlsx)|*.xlsx";
                dialog.AddExtension = true;

                dialog.FileName = Path.GetFileNameWithoutExtension(schema.filePath);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CreateSpreadsheet(dialog.FileName);
                }
            }
        }

        void CreateSpreadsheet(string filePath)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Unable to create spreadsheet; Microsoft Excel is not installed");
                return;
            }

            Workbook workbook = xlApp.Workbooks.Add();

            Worksheet worksheet = (Worksheet)workbook.Worksheets.get_Item(1);

            worksheet.Cells[1, 1] = "Name";
            worksheet.Cells[1, 2] = "Start Time";
            worksheet.Cells[1, 3] = "Diff";
            worksheet.Cells[1, 4] = "Video Path";

            int i = 2;

            foreach (VideoComparasonControl control in schemaVideoFileControls)
            {
                worksheet.Cells[i, 1] = control.schemaItem.Name;
                worksheet.Cells[i, 2] = control.schemaItem.Time.ToString("g");
                worksheet.Cells[i, 3] = control.Difference.ToString("g");
                worksheet.Cells[i, 4] = control.selectedFile;

                i++;
            }

            try
            {
                workbook.SaveAs(filePath);
                workbook.Close(true);
                xlApp.Quit();

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(xlApp);
            } 
            catch(Exception e)
            {
                if(MessageBox.Show($"Excel error: {e.Message}", "Excel error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    CreateSpreadsheet(filePath);
                    return;
                }
            }

            MessageBox.Show($"Exported spreadsheet successfully ({filePath})", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void spreadsheetButton_Click(object sender, EventArgs e)
        {
            ExportSpreadsheet();
        }

        private void editSchemaButton_Click(object sender, EventArgs e)
        {
            SchemaEditor.EditSchema(schema, () => Open(schema));

            forceClose = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
