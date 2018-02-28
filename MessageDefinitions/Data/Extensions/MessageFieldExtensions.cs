using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Data.Extensions
{
    public static class MessageFieldExtensions
    {
        public static IEnumerable<MessageField> OrderForSerialization(this IEnumerable<MessageField> messageFields)
        {
            IEnumerable<MessageField> orderedMessageFields = messageFields.OrderByDescending(f => f.Type.TypeLength).ThenBy(f => f.DefinitionIndex).ToList();
            return orderedMessageFields;
        }
    }
}
