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
    
    
    public class DistanceSensorMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.DistanceSensorMessage tMessage = message as MavLink4Net.Messages.Common.DistanceSensorMessage;
            writer.Write(tMessage.TimeBootMs);
            writer.Write(tMessage.MinDistance);
            writer.Write(tMessage.MaxDistance);
            writer.Write(tMessage.CurrentDistance);
            writer.Write(((byte)(tMessage.Type)));
            writer.Write(tMessage.Id);
            writer.Write(((byte)(tMessage.Orientation)));
            writer.Write(tMessage.Covariance);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.DistanceSensorMessage message = new MavLink4Net.Messages.Common.DistanceSensorMessage();
            message.TimeBootMs = reader.ReadUInt32();
            message.MinDistance = reader.ReadUInt16();
            message.MaxDistance = reader.ReadUInt16();
            message.CurrentDistance = reader.ReadUInt16();
            message.Type = ((MavLink4Net.Messages.Common.DistanceSensor)(reader.ReadByte()));
            message.Id = reader.ReadByte();
            message.Orientation = ((MavLink4Net.Messages.Common.SensorOrientation)(reader.ReadByte()));
            message.Covariance = reader.ReadByte();
            return message;
        }
    }
}
