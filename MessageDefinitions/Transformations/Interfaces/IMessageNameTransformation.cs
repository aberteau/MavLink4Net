namespace MavLink4Net.MessageDefinitions.Transformations.Interfaces
{
    public interface IMessageNameTransformation
    {
        string Transform(Xml.Message pMessage);
    }
}