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
    
    
    public class DebugVectMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.DebugVectMessage tMessage = message as MavLink4Net.Messages.Common.DebugVectMessage;
            writer.Write(tMessage.TimeUsec);
            writer.Write(tMessage.X);
            writer.Write(tMessage.Y);
            writer.Write(tMessage.Z);
            writer.Write(tMessage.Name[0]);
            writer.Write(tMessage.Name[1]);
            writer.Write(tMessage.Name[2]);
            writer.Write(tMessage.Name[3]);
            writer.Write(tMessage.Name[4]);
            writer.Write(tMessage.Name[5]);
            writer.Write(tMessage.Name[6]);
            writer.Write(tMessage.Name[7]);
            writer.Write(tMessage.Name[8]);
            writer.Write(tMessage.Name[9]);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.DebugVectMessage message = new MavLink4Net.Messages.Common.DebugVectMessage();
            message.TimeUsec = reader.ReadUInt64();
            message.X = reader.ReadSingle();
            message.Y = reader.ReadSingle();
            message.Z = reader.ReadSingle();
            message.Name[0] = reader.ReadChar();
            message.Name[1] = reader.ReadChar();
            message.Name[2] = reader.ReadChar();
            message.Name[3] = reader.ReadChar();
            message.Name[4] = reader.ReadChar();
            message.Name[5] = reader.ReadChar();
            message.Name[6] = reader.ReadChar();
            message.Name[7] = reader.ReadChar();
            message.Name[8] = reader.ReadChar();
            message.Name[9] = reader.ReadChar();
            return message;
        }
    }
}
