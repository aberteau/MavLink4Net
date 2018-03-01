using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations.Interfaces
{
    public interface IMessageNameTranslation
    {
        string TranslateName(Message pMessage);
    }
}