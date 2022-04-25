using MB.VideoLengthTool.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB.VideoLengthTool.Controls
{
    public partial class SchemaItemControl : UserControl
    {
        SchemaEditor newSchemaWindow;

        public string ItemName { get => schemaItemName.Text; set => schemaItemName.Text = value; }
        public TimeSpan ItemTime { get => schemaItemTime.Value.TimeOfDay; set => schemaItemTime.Value = schemaItemTime.MinDate + value; }

        public SchemaItemControl(SchemaEditor newSchemaWindow)
        {
            this.newSchemaWindow = newSchemaWindow;

            InitializeComponent();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            newSchemaWindow.RemoveSchemaItem(this);
        }
    }
}
