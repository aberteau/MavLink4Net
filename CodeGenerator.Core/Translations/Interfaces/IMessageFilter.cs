using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations.Interfaces
{
    public interface IMessageFilter
    {
        IEnumerable<Message> Filter(IEnumerable<Message> pMessages);
    }
}
