using System.Collections.Generic;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations.Interfaces
{
    public interface IEnumEntryNameTranslation
    {
        void SetContext(IEnumerable<EnumEntry> xEnumEntries, string xEnumName);
        string TranslateName(MessageDefinitions.Data.EnumEntry pEnumEntry);
    }
}