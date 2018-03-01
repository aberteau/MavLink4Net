using System.IO;

namespace MavLink4Net.Messages.Serialization
{
    public interface IMessageSerializer
    {
        void Serialize(BinaryWriter writer, Message message);
        Message Deserialize(BinaryReader reader);
    }
}
