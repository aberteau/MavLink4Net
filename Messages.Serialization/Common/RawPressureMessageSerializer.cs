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
    
    
    public class RawPressureMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.RawPressureMessage tMessage = message as MavLink4Net.Messages.Common.RawPressureMessage;
            writer.Write(tMessage.TimeUsec);
            writer.Write(tMessage.PressAbs);
            writer.Write(tMessage.PressDiff1);
            writer.Write(tMessage.PressDiff2);
            writer.Write(tMessage.Temperature);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.RawPressureMessage message = new MavLink4Net.Messages.Common.RawPressureMessage();
            message.TimeUsec = reader.ReadUInt64();
            message.PressAbs = reader.ReadInt16();
            message.PressDiff1 = reader.ReadInt16();
            message.PressDiff2 = reader.ReadInt16();
            message.Temperature = reader.ReadInt16();
            return message;
        }
    }
}
