using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions.Transformations.Interfaces;

namespace MavLink4Net.MessageDefinitions
{
    public class MavLink1MessageFilter
        : IMessageFilter
    {
        public IEnumerable<Xml.Message> Filter(IEnumerable<Xml.Message> xMessages)
        {
            // discard anything beyond 255
            IEnumerable<Xml.Message> filteredMessages = xMessages.Where(m => m.Id < 256);
            return filteredMessages;
        }
    }
}
