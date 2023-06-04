using System.Linq;
using System.Xml.Linq;

namespace Tools.FileSaves
{
    public class SaveFile
    {
        private const string _ROOT_NAME = "ROOT";
        private readonly XElement _data;

        public SaveFile(string fileName)
        {
            this.fileName = fileName;
            BinarySaves.CreateAndInitFileIfNotExist(fileName);
            _data = XElement.Parse(BinarySaves.Load(fileName));
        }

        public string fileName { get; }

        public static string GetDefaultData() => new XElement(_ROOT_NAME).ToString();

        public string GetData() => _data.ToString();

        public bool HasName(string name) => _data.Elements(name).Any();

        public int GetInt(string name, int defaultValue = 0)
        {
            if (!HasName(name)) return defaultValue;

            return int.TryParse(GetData(name), out int result) ? result : defaultValue;
        }

        public uint GetUInt(string name, uint defaultValue = 0)
        {
            if (!HasName(name)) return defaultValue;

            return uint.TryParse(GetData(name), out uint result) ? result : defaultValue;
        }

        public ulong GetULong(string name, ulong defaultValue = 0)
        {
            if (!HasName(name)) return defaultValue;

            return ulong.TryParse(GetData(name), out ulong result) ? result : defaultValue;
        }

        public float GetFloat(string name, float defaultValue = 0)
        {
            if (!HasName(name)) return defaultValue;

            return float.TryParse(GetData(name), out float result) ? result : defaultValue;
        }

        public bool GetBool(string name, bool defaultValue = false)
        {
            if (!HasName(name)) return defaultValue;

            return byte.TryParse(GetData(name), out byte result) ? result != 0 : defaultValue;
        }

        public string GetString(string name, string defaultValue = "")
        {
            if (!HasName(name)) return defaultValue;

            return GetData(name);
        }

        public void SetInt(string name, int value)
        {
            string data = value.ToString();

            if (!HasName(name))
            {
                _data.Add(new XElement(name, data));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = data;
            BinarySaves.Save(this);
        }

        public void SetUInt(string name, uint value)
        {
            string data = value.ToString();

            if (!HasName(name))
            {
                _data.Add(new XElement(name, data));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = data;
            BinarySaves.Save(this);
        }

        public void SetULong(string name, ulong value)
        {
            string data = value.ToString();

            if (!HasName(name))
            {
                _data.Add(new XElement(name, data));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = data;
            BinarySaves.Save(this);
        }

        public void SetFloat(string name, float value)
        {
            string data = value.ToString();

            if (!HasName(name))
            {
                _data.Add(new XElement(name, data));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = data;
            BinarySaves.Save(this);
        }

        public void SetBool(string name, bool value)
        {
            string data = value == false ? "0" : "1";

            if (!HasName(name))
            {
                _data.Add(new XElement(name, data));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = data;
            BinarySaves.Save(this);
        }

        public void SetString(string name, string value)
        {
            if (!HasName(name))
            {
                _data.Add(new XElement(name, value));
                BinarySaves.Save(this);
                return;
            }

            _data.Element(name).Value = value;
            BinarySaves.Save(this);
        }

        private string GetData(string name) => _data.Element(name).Value;
    }
}