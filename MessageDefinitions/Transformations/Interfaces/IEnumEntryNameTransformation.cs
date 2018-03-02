using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Transformations.Interfaces
{
    public interface IEnumEntryNameTransformation
    {
        void SetContext(IEnumerable<Xml.EnumEntry> xEnumEntries, string xEnumName);
        string Transform(Xml.EnumEntry pEnumEntry);
    }
}