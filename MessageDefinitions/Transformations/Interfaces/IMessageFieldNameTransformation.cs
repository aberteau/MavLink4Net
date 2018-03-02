namespace MavLink4Net.MessageDefinitions.Transformations.Interfaces
{
    public interface IMessageFieldNameTransformation
    {
        string Transform(Xml.MessageField pMessageField);
    }
}