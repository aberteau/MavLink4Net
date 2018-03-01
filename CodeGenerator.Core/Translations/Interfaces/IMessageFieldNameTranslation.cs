namespace MavLink4Net.CodeGenerator.Core.Translations.Interfaces
{
    public interface IMessageFieldNameTranslation
    {
        string TranslateName(MessageDefinitions.Data.MessageField pMessageField);
    }
}