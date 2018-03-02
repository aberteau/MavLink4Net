using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions
{
    class MessageFieldCrcData
    {
        public int DefinitionIndex { get; set; }

        public int TypeLength { get; set; }

        public int ArrayLength { get; set; }

        public Xml.MessageField Field { get; set; }
    }
}
