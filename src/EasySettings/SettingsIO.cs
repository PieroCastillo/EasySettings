using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace EasySettings
{
    public partial class SettingsManager
    {
        public void Load()
        {
            var path = this.Path;
            //XmlReader reader = XmlReader.Create("http://github.com/PieroCastillo/EasySettings");
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            foreach(XmlNode node in xml.DocumentElement.ChildNodes)
            {
                var valueID = node.Attributes["ID"].Value;
                //var valuetype = node.Attributes["Type"].Value;
                var value = node.Attributes["Value"].Value;
                var S = new Setting(valueID);
                S.SetValue(value);
                Settings.Add(S);
            }
        }

        public void Save()
        {
            var path = this.Path;

            XmlDocument xml = new XmlDocument();
            foreach(Setting s in Settings)
            {
                var value = s.GetValue();
                var valueID = s.ID;
                XmlAttribute AttibuteID = xml.CreateAttribute("ID");
                AttibuteID.Value = valueID.ToString();
                XmlAttribute AttibuteValue = xml.CreateAttribute("Value");
                AttibuteID.Value = value.ToString();
                XmlNode settingsnode = xml.CreateElement("Setting");
                settingsnode.Attributes.Append(AttibuteValue);
                settingsnode.Attributes.Append(AttibuteID);
            }
            xml.Save(path);
        }
    }
}
