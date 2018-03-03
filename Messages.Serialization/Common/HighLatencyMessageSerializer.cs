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
    
    
    public class HighLatencyMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.HighLatencyMessage tMessage = message as MavLink4Net.Messages.Common.HighLatencyMessage;
            writer.Write(tMessage.CustomMode);
            writer.Write(tMessage.Latitude);
            writer.Write(tMessage.Longitude);
            writer.Write(tMessage.Roll);
            writer.Write(tMessage.Pitch);
            writer.Write(tMessage.Heading);
            writer.Write(tMessage.HeadingSp);
            writer.Write(tMessage.AltitudeAmsl);
            writer.Write(tMessage.AltitudeSp);
            writer.Write(tMessage.WpDistance);
            writer.Write(((byte)(tMessage.BaseMode)));
            writer.Write(((byte)(tMessage.LandedState)));
            writer.Write(tMessage.Throttle);
            writer.Write(tMessage.Airspeed);
            writer.Write(tMessage.AirspeedSp);
            writer.Write(tMessage.Groundspeed);
            writer.Write(tMessage.ClimbRate);
            writer.Write(tMessage.GpsNsat);
            writer.Write(((byte)(tMessage.GpsFixType)));
            writer.Write(tMessage.BatteryRemaining);
            writer.Write(tMessage.Temperature);
            writer.Write(tMessage.TemperatureAir);
            writer.Write(tMessage.Failsafe);
            writer.Write(tMessage.WpNum);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.HighLatencyMessage message = new MavLink4Net.Messages.Common.HighLatencyMessage();
            message.CustomMode = reader.ReadUInt32();
            message.Latitude = reader.ReadInt32();
            message.Longitude = reader.ReadInt32();
            message.Roll = reader.ReadInt16();
            message.Pitch = reader.ReadInt16();
            message.Heading = reader.ReadUInt16();
            message.HeadingSp = reader.ReadInt16();
            message.AltitudeAmsl = reader.ReadInt16();
            message.AltitudeSp = reader.ReadInt16();
            message.WpDistance = reader.ReadUInt16();
            message.BaseMode = ((MavLink4Net.Messages.Common.ModeFlag)(reader.ReadByte()));
            message.LandedState = ((MavLink4Net.Messages.Common.LandedState)(reader.ReadByte()));
            message.Throttle = reader.ReadSByte();
            message.Airspeed = reader.ReadByte();
            message.AirspeedSp = reader.ReadByte();
            message.Groundspeed = reader.ReadByte();
            message.ClimbRate = reader.ReadSByte();
            message.GpsNsat = reader.ReadByte();
            message.GpsFixType = ((MavLink4Net.Messages.Common.GpsFixType)(reader.ReadByte()));
            message.BatteryRemaining = reader.ReadByte();
            message.Temperature = reader.ReadSByte();
            message.TemperatureAir = reader.ReadSByte();
            message.Failsafe = reader.ReadByte();
            message.WpNum = reader.ReadByte();
            return message;
        }
    }
}
