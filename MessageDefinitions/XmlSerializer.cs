using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MavLink4Net.MessageDefinitions.Xml;

namespace MavLink4Net.MessageDefinitions
{
    public class XmlSerializer
    {
        public static MavLink Deserialize(TextReader textReader)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MavLink));
            MavLink mavlink = (MavLink)serializer.Deserialize(textReader);
            return mavlink;
        }

        public static MavLink Deserialize(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            MavLink mavLink = Deserialize(streamReader);
            streamReader.Close();
            return mavLink;
        }
    }
}
