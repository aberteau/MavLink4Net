using System.IO;

namespace MavLink4Net.Messages.Serialization
{
    public interface IMessageSerializer
    {
        void Serialize(BinaryWriter writer, IMessage message);
        IMessage Deserialize(BinaryReader reader);
    }
}
