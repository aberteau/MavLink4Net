using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Transformations.Interfaces
{
    public interface IMessageFilter
    {
        IEnumerable<Xml.Message> Filter(IEnumerable<Xml.Message> pMessages);
    }
}
