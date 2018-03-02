using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class Message
    {
        public int Id { get; set; }

        public Xml.Message XmlDefinition { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<MessageField> Fields { get; set; }

        public byte CrcExtra { get; set; }

        public bool IsNameTransformed => !XmlDefinition.Name.Equals(Name);
    }
}
