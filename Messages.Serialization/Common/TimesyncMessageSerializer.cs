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
    
    
    public class TimesyncMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.Message message)
        {
            MavLink4Net.Messages.Common.TimesyncMessage tMessage = message as MavLink4Net.Messages.Common.TimesyncMessage;
            writer.Write(tMessage.Tc1);
            writer.Write(tMessage.Ts1);
        }
        
        public MavLink4Net.Messages.Message Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.TimesyncMessage message = new MavLink4Net.Messages.Common.TimesyncMessage();
            message.Tc1 = reader.ReadInt64();
            message.Ts1 = reader.ReadInt64();
            return message;
        }
    }
}