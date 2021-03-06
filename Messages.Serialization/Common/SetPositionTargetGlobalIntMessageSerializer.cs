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
    
    
    public class SetPositionTargetGlobalIntMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.SetPositionTargetGlobalIntMessage tMessage = message as MavLink4Net.Messages.Common.SetPositionTargetGlobalIntMessage;
            writer.Write(tMessage.TimeBootMs);
            writer.Write(tMessage.LatInt);
            writer.Write(tMessage.LonInt);
            writer.Write(tMessage.Alt);
            writer.Write(tMessage.Vx);
            writer.Write(tMessage.Vy);
            writer.Write(tMessage.Vz);
            writer.Write(tMessage.Afx);
            writer.Write(tMessage.Afy);
            writer.Write(tMessage.Afz);
            writer.Write(tMessage.Yaw);
            writer.Write(tMessage.YawRate);
            writer.Write(tMessage.TypeMask);
            writer.Write(tMessage.TargetSystem);
            writer.Write(tMessage.TargetComponent);
            writer.Write(((byte)(tMessage.CoordinateFrame)));
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.SetPositionTargetGlobalIntMessage message = new MavLink4Net.Messages.Common.SetPositionTargetGlobalIntMessage();
            message.TimeBootMs = reader.ReadUInt32();
            message.LatInt = reader.ReadInt32();
            message.LonInt = reader.ReadInt32();
            message.Alt = reader.ReadSingle();
            message.Vx = reader.ReadSingle();
            message.Vy = reader.ReadSingle();
            message.Vz = reader.ReadSingle();
            message.Afx = reader.ReadSingle();
            message.Afy = reader.ReadSingle();
            message.Afz = reader.ReadSingle();
            message.Yaw = reader.ReadSingle();
            message.YawRate = reader.ReadSingle();
            message.TypeMask = reader.ReadUInt16();
            message.TargetSystem = reader.ReadByte();
            message.TargetComponent = reader.ReadByte();
            message.CoordinateFrame = ((MavLink4Net.Messages.Common.Frame)(reader.ReadByte()));
            return message;
        }
    }
}
