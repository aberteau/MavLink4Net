﻿using System;
using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class MavLink
    {
        public int Version { get; set; }

        public string Dialect { get; set; }

        public IEnumerable<Enum> Enums { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
