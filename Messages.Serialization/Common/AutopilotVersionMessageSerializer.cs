//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;


namespace MavLink4Net.Messages.Serialization.Common
{
    
    
    public class AutopilotVersionMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.Message message)
        {
            MavLink4Net.Messages.Common.AutopilotVersionMessage tMessage = message as MavLink4Net.Messages.Common.AutopilotVersionMessage;
            writer.Write(((ulong)(tMessage.Capabilities)));
            writer.Write(tMessage.Uid);
            writer.Write(tMessage.FlightSwVersion);
            writer.Write(tMessage.MiddlewareSwVersion);
            writer.Write(tMessage.OsSwVersion);
            writer.Write(tMessage.BoardVersion);
            writer.Write(tMessage.VendorId);
            writer.Write(tMessage.ProductId);
            writer.Write(tMessage.FlightCustomVersion[0]);
            writer.Write(tMessage.FlightCustomVersion[1]);
            writer.Write(tMessage.FlightCustomVersion[2]);
            writer.Write(tMessage.FlightCustomVersion[3]);
            writer.Write(tMessage.FlightCustomVersion[4]);
            writer.Write(tMessage.FlightCustomVersion[5]);
            writer.Write(tMessage.FlightCustomVersion[6]);
            writer.Write(tMessage.FlightCustomVersion[7]);
            writer.Write(tMessage.MiddlewareCustomVersion[0]);
            writer.Write(tMessage.MiddlewareCustomVersion[1]);
            writer.Write(tMessage.MiddlewareCustomVersion[2]);
            writer.Write(tMessage.MiddlewareCustomVersion[3]);
            writer.Write(tMessage.MiddlewareCustomVersion[4]);
            writer.Write(tMessage.MiddlewareCustomVersion[5]);
            writer.Write(tMessage.MiddlewareCustomVersion[6]);
            writer.Write(tMessage.MiddlewareCustomVersion[7]);
            writer.Write(tMessage.OsCustomVersion[0]);
            writer.Write(tMessage.OsCustomVersion[1]);
            writer.Write(tMessage.OsCustomVersion[2]);
            writer.Write(tMessage.OsCustomVersion[3]);
            writer.Write(tMessage.OsCustomVersion[4]);
            writer.Write(tMessage.OsCustomVersion[5]);
            writer.Write(tMessage.OsCustomVersion[6]);
            writer.Write(tMessage.OsCustomVersion[7]);
            writer.Write(tMessage.Uid2[0]);
            writer.Write(tMessage.Uid2[1]);
            writer.Write(tMessage.Uid2[2]);
            writer.Write(tMessage.Uid2[3]);
            writer.Write(tMessage.Uid2[4]);
            writer.Write(tMessage.Uid2[5]);
            writer.Write(tMessage.Uid2[6]);
            writer.Write(tMessage.Uid2[7]);
            writer.Write(tMessage.Uid2[8]);
            writer.Write(tMessage.Uid2[9]);
            writer.Write(tMessage.Uid2[10]);
            writer.Write(tMessage.Uid2[11]);
            writer.Write(tMessage.Uid2[12]);
            writer.Write(tMessage.Uid2[13]);
            writer.Write(tMessage.Uid2[14]);
            writer.Write(tMessage.Uid2[15]);
            writer.Write(tMessage.Uid2[16]);
            writer.Write(tMessage.Uid2[17]);
        }
        
        public MavLink4Net.Messages.Message Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.AutopilotVersionMessage message = new MavLink4Net.Messages.Common.AutopilotVersionMessage();
            message.Capabilities = ((MavLink4Net.Messages.Common.ProtocolCapability)(reader.ReadUInt64()));
            message.Uid = reader.ReadUInt64();
            message.FlightSwVersion = reader.ReadUInt32();
            message.MiddlewareSwVersion = reader.ReadUInt32();
            message.OsSwVersion = reader.ReadUInt32();
            message.BoardVersion = reader.ReadUInt32();
            message.VendorId = reader.ReadUInt16();
            message.ProductId = reader.ReadUInt16();
            message.FlightCustomVersion[0] = reader.ReadByte();
            message.FlightCustomVersion[1] = reader.ReadByte();
            message.FlightCustomVersion[2] = reader.ReadByte();
            message.FlightCustomVersion[3] = reader.ReadByte();
            message.FlightCustomVersion[4] = reader.ReadByte();
            message.FlightCustomVersion[5] = reader.ReadByte();
            message.FlightCustomVersion[6] = reader.ReadByte();
            message.FlightCustomVersion[7] = reader.ReadByte();
            message.MiddlewareCustomVersion[0] = reader.ReadByte();
            message.MiddlewareCustomVersion[1] = reader.ReadByte();
            message.MiddlewareCustomVersion[2] = reader.ReadByte();
            message.MiddlewareCustomVersion[3] = reader.ReadByte();
            message.MiddlewareCustomVersion[4] = reader.ReadByte();
            message.MiddlewareCustomVersion[5] = reader.ReadByte();
            message.MiddlewareCustomVersion[6] = reader.ReadByte();
            message.MiddlewareCustomVersion[7] = reader.ReadByte();
            message.OsCustomVersion[0] = reader.ReadByte();
            message.OsCustomVersion[1] = reader.ReadByte();
            message.OsCustomVersion[2] = reader.ReadByte();
            message.OsCustomVersion[3] = reader.ReadByte();
            message.OsCustomVersion[4] = reader.ReadByte();
            message.OsCustomVersion[5] = reader.ReadByte();
            message.OsCustomVersion[6] = reader.ReadByte();
            message.OsCustomVersion[7] = reader.ReadByte();
            message.Uid2[0] = reader.ReadByte();
            message.Uid2[1] = reader.ReadByte();
            message.Uid2[2] = reader.ReadByte();
            message.Uid2[3] = reader.ReadByte();
            message.Uid2[4] = reader.ReadByte();
            message.Uid2[5] = reader.ReadByte();
            message.Uid2[6] = reader.ReadByte();
            message.Uid2[7] = reader.ReadByte();
            message.Uid2[8] = reader.ReadByte();
            message.Uid2[9] = reader.ReadByte();
            message.Uid2[10] = reader.ReadByte();
            message.Uid2[11] = reader.ReadByte();
            message.Uid2[12] = reader.ReadByte();
            message.Uid2[13] = reader.ReadByte();
            message.Uid2[14] = reader.ReadByte();
            message.Uid2[15] = reader.ReadByte();
            message.Uid2[16] = reader.ReadByte();
            message.Uid2[17] = reader.ReadByte();
            return message;
        }
    }
}