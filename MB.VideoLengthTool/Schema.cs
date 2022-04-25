using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.VideoLengthTool
{
    [Serializable]
    public class Schema
    {
        [Serializable]
        public struct SchemaItem
        {
            public string Name;
            public TimeSpan Time;

            public SchemaItem(string name, TimeSpan time) : this()
            {
                Name = name;
                Time = time;
            }
        }

        [NonSerialized] public string filePath;
        public List<SchemaItem> items = new List<SchemaItem>();

        public Schema(params SchemaItem[] startItems) { if (startItems != null && startItems.Length > 0) items.AddRange(startItems); }

        public static Schema LoadFromFile(string path)
        {
            var schema = Deserialize(File.ReadAllText(path));

            schema.filePath = path;

            return schema;
        }

        public static Schema Deserialize(string data) => JsonConvert.DeserializeObject<Schema>(data);
        public string Serialize() => JsonConvert.SerializeObject(this);

        public override string ToString() => Serialize();
    }
}
