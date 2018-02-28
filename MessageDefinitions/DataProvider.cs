using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions
{
    public class DataProvider
    {
        public static Data.MavLink LoadMavLink(string path)
        {
            Xml.MavLink xMavLink = XmlSerializer.Deserialize(path);
            MavLink dMavLink = Mappers.MappingHelper.ToModel(xMavLink);

            return dMavLink;
        }
    }
}
