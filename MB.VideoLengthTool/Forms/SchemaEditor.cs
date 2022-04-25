using MB.VideoLengthTool.Controls;
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

namespace MB.VideoLengthTool.Forms
{
    public partial class SchemaEditor : Form
    {
        Func<Schema, bool> OnFinishAction;
        Action OnCancelAction;

        Schema schema;

        bool finished;

        public SchemaEditor(string title, Action onCancel, Func<Schema, bool> onFinish, Schema schema = null)
        {
            this.schema = schema != null ? schema : new Schema(
                new Schema.SchemaItem("", new TimeSpan(8, 0, 0)),
                new Schema.SchemaItem("", new TimeSpan(9, 0, 0)),
                new Schema.SchemaItem("", new TimeSpan(10, 0, 0)));

            OnCancelAction = onCancel;
            OnFinishAction = onFinish;

            FormClosing += (e, a) =>
            {
                if (!finished)
                    OnCancelAction?.Invoke();
            };

            InitializeComponent();

            Text = title;
        }

        List<SchemaItemControl> items = new List<SchemaItemControl>();

        public static void NewSchema(Action OnCancel)
        {
            new SchemaEditor("New Schema", OnCancel, (schema) =>
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.AddExtension = true;
                    dialog.Filter = "Schema file (*.hschema)|*.hschema";
                    dialog.Title = "Export Schema File";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(dialog.FileName, schema.Serialize());

                        schema.filePath = dialog.FileName;

                        CompareWindow.Open(schema);

                        return true;
                    }

                    return false;
                }
            }).Show();
        }

        public static void EditSchema(Schema schema, Action OnCancel)
        {
            new SchemaEditor($"Edit Schema - {schema.filePath}", OnCancel, (newSchema) =>
            {
                File.WriteAllText(schema.filePath, newSchema.Serialize());

                CompareWindow.Open(newSchema);

                return true;
            }, schema).Show();
        }

        private void SchemaEditor_Load(object sender, EventArgs e)
        {
            foreach (Schema.SchemaItem item in schema.items)
            {
                AddSchemaItem(item.Name, item.Time);
            }

            SizeChanged += (s, a) => UpdateLayout();
        }

        void AddSchemaItem(string name, TimeSpan time)
        {
            var item = new SchemaItemControl(this);

            item.ItemName = name;
            item.ItemTime = time;

            item.Show();

            items.Add(item);
            itemPanel.Controls.Add(item);

            UpdateLayout();
        }

        public void RemoveSchemaItem(SchemaItemControl item)
        {
            item.Hide();

            items.Remove(item);

            UpdateLayout();
        }

        void UpdateLayout()
        {
            foreach (SchemaItemControl control in items)
            {
                control.Width = itemPanel.Width - 6 - (itemPanel.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
            }
        }

        private void addSchemaItemButton_Click(object sender, EventArgs e)
        {
            AddSchemaItem("", new TimeSpan(8, 0, 0));
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createSchemaButton_Click(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Please add an item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            schema.items = (from l1 in items
                            select new Schema.SchemaItem()
                            {
                                Name = l1.ItemName,
                                Time = l1.ItemTime
                            }
                            ).ToList();

            if ((bool)OnFinishAction?.Invoke(schema))
            {
                finished = true;

                Close();
            }
        }
    }
}
