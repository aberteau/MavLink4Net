//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MavLink4Net.Messages.Serialization.Common
{
    
    
    public class DataStreamMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.DataStreamMessage tMessage = message as MavLink4Net.Messages.Common.DataStreamMessage;
            writer.Write(tMessage.MessageRate);
            writer.Write(tMessage.StreamId);
            writer.Write(tMessage.OnOff);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.DataStreamMessage message = new MavLink4Net.Messages.Common.DataStreamMessage();
            message.MessageRate = reader.ReadUInt16();
            message.StreamId = reader.ReadByte();
            message.OnOff = reader.ReadByte();
            return message;
        }
    }
}
