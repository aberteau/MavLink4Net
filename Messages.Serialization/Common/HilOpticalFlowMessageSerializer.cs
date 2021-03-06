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
    
    
    public class HilOpticalFlowMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.HilOpticalFlowMessage tMessage = message as MavLink4Net.Messages.Common.HilOpticalFlowMessage;
            writer.Write(tMessage.TimeUsec);
            writer.Write(tMessage.IntegrationTimeUs);
            writer.Write(tMessage.IntegratedX);
            writer.Write(tMessage.IntegratedY);
            writer.Write(tMessage.IntegratedXgyro);
            writer.Write(tMessage.IntegratedYgyro);
            writer.Write(tMessage.IntegratedZgyro);
            writer.Write(tMessage.TimeDeltaDistanceUs);
            writer.Write(tMessage.Distance);
            writer.Write(tMessage.Temperature);
            writer.Write(tMessage.SensorId);
            writer.Write(tMessage.Quality);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.HilOpticalFlowMessage message = new MavLink4Net.Messages.Common.HilOpticalFlowMessage();
            message.TimeUsec = reader.ReadUInt64();
            message.IntegrationTimeUs = reader.ReadUInt32();
            message.IntegratedX = reader.ReadSingle();
            message.IntegratedY = reader.ReadSingle();
            message.IntegratedXgyro = reader.ReadSingle();
            message.IntegratedYgyro = reader.ReadSingle();
            message.IntegratedZgyro = reader.ReadSingle();
            message.TimeDeltaDistanceUs = reader.ReadUInt32();
            message.Distance = reader.ReadSingle();
            message.Temperature = reader.ReadInt16();
            message.SensorId = reader.ReadByte();
            message.Quality = reader.ReadByte();
            return message;
        }
    }
}
