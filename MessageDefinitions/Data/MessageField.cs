using System;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class MessageField
    {
        public Int32 DefinitionIndex { get; set; }

        public MessageFieldType Type { get; set; }

        public string Name { get; set; }

        public string Units { get; set; }

        public string Display { get; set; }

        public string Text { get; set; }
    }
}
