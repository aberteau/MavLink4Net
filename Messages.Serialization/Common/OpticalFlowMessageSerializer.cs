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
    
    
    public class OpticalFlowMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.OpticalFlowMessage tMessage = message as MavLink4Net.Messages.Common.OpticalFlowMessage;
            writer.Write(tMessage.TimeUsec);
            writer.Write(tMessage.FlowCompMX);
            writer.Write(tMessage.FlowCompMY);
            writer.Write(tMessage.GroundDistance);
            writer.Write(tMessage.FlowX);
            writer.Write(tMessage.FlowY);
            writer.Write(tMessage.SensorId);
            writer.Write(tMessage.Quality);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.OpticalFlowMessage message = new MavLink4Net.Messages.Common.OpticalFlowMessage();
            message.TimeUsec = reader.ReadUInt64();
            message.FlowCompMX = reader.ReadSingle();
            message.FlowCompMY = reader.ReadSingle();
            message.GroundDistance = reader.ReadSingle();
            message.FlowX = reader.ReadInt16();
            message.FlowY = reader.ReadInt16();
            message.SensorId = reader.ReadByte();
            message.Quality = reader.ReadByte();
            return message;
        }
    }
}
