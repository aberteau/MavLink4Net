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
    
    
    public class VfrHudMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.VfrHudMessage tMessage = message as MavLink4Net.Messages.Common.VfrHudMessage;
            writer.Write(tMessage.Airspeed);
            writer.Write(tMessage.Groundspeed);
            writer.Write(tMessage.Alt);
            writer.Write(tMessage.Climb);
            writer.Write(tMessage.Heading);
            writer.Write(tMessage.Throttle);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.VfrHudMessage message = new MavLink4Net.Messages.Common.VfrHudMessage();
            message.Airspeed = reader.ReadSingle();
            message.Groundspeed = reader.ReadSingle();
            message.Alt = reader.ReadSingle();
            message.Climb = reader.ReadSingle();
            message.Heading = reader.ReadInt16();
            message.Throttle = reader.ReadUInt16();
            return message;
        }
    }
}
