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
    
    
    public class ResourceRequestMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.ResourceRequestMessage tMessage = message as MavLink4Net.Messages.Common.ResourceRequestMessage;
            writer.Write(tMessage.RequestId);
            writer.Write(tMessage.UriType);
            writer.Write(tMessage.Uri[0]);
            writer.Write(tMessage.Uri[1]);
            writer.Write(tMessage.Uri[2]);
            writer.Write(tMessage.Uri[3]);
            writer.Write(tMessage.Uri[4]);
            writer.Write(tMessage.Uri[5]);
            writer.Write(tMessage.Uri[6]);
            writer.Write(tMessage.Uri[7]);
            writer.Write(tMessage.Uri[8]);
            writer.Write(tMessage.Uri[9]);
            writer.Write(tMessage.Uri[10]);
            writer.Write(tMessage.Uri[11]);
            writer.Write(tMessage.Uri[12]);
            writer.Write(tMessage.Uri[13]);
            writer.Write(tMessage.Uri[14]);
            writer.Write(tMessage.Uri[15]);
            writer.Write(tMessage.Uri[16]);
            writer.Write(tMessage.Uri[17]);
            writer.Write(tMessage.Uri[18]);
            writer.Write(tMessage.Uri[19]);
            writer.Write(tMessage.Uri[20]);
            writer.Write(tMessage.Uri[21]);
            writer.Write(tMessage.Uri[22]);
            writer.Write(tMessage.Uri[23]);
            writer.Write(tMessage.Uri[24]);
            writer.Write(tMessage.Uri[25]);
            writer.Write(tMessage.Uri[26]);
            writer.Write(tMessage.Uri[27]);
            writer.Write(tMessage.Uri[28]);
            writer.Write(tMessage.Uri[29]);
            writer.Write(tMessage.Uri[30]);
            writer.Write(tMessage.Uri[31]);
            writer.Write(tMessage.Uri[32]);
            writer.Write(tMessage.Uri[33]);
            writer.Write(tMessage.Uri[34]);
            writer.Write(tMessage.Uri[35]);
            writer.Write(tMessage.Uri[36]);
            writer.Write(tMessage.Uri[37]);
            writer.Write(tMessage.Uri[38]);
            writer.Write(tMessage.Uri[39]);
            writer.Write(tMessage.Uri[40]);
            writer.Write(tMessage.Uri[41]);
            writer.Write(tMessage.Uri[42]);
            writer.Write(tMessage.Uri[43]);
            writer.Write(tMessage.Uri[44]);
            writer.Write(tMessage.Uri[45]);
            writer.Write(tMessage.Uri[46]);
            writer.Write(tMessage.Uri[47]);
            writer.Write(tMessage.Uri[48]);
            writer.Write(tMessage.Uri[49]);
            writer.Write(tMessage.Uri[50]);
            writer.Write(tMessage.Uri[51]);
            writer.Write(tMessage.Uri[52]);
            writer.Write(tMessage.Uri[53]);
            writer.Write(tMessage.Uri[54]);
            writer.Write(tMessage.Uri[55]);
            writer.Write(tMessage.Uri[56]);
            writer.Write(tMessage.Uri[57]);
            writer.Write(tMessage.Uri[58]);
            writer.Write(tMessage.Uri[59]);
            writer.Write(tMessage.Uri[60]);
            writer.Write(tMessage.Uri[61]);
            writer.Write(tMessage.Uri[62]);
            writer.Write(tMessage.Uri[63]);
            writer.Write(tMessage.Uri[64]);
            writer.Write(tMessage.Uri[65]);
            writer.Write(tMessage.Uri[66]);
            writer.Write(tMessage.Uri[67]);
            writer.Write(tMessage.Uri[68]);
            writer.Write(tMessage.Uri[69]);
            writer.Write(tMessage.Uri[70]);
            writer.Write(tMessage.Uri[71]);
            writer.Write(tMessage.Uri[72]);
            writer.Write(tMessage.Uri[73]);
            writer.Write(tMessage.Uri[74]);
            writer.Write(tMessage.Uri[75]);
            writer.Write(tMessage.Uri[76]);
            writer.Write(tMessage.Uri[77]);
            writer.Write(tMessage.Uri[78]);
            writer.Write(tMessage.Uri[79]);
            writer.Write(tMessage.Uri[80]);
            writer.Write(tMessage.Uri[81]);
            writer.Write(tMessage.Uri[82]);
            writer.Write(tMessage.Uri[83]);
            writer.Write(tMessage.Uri[84]);
            writer.Write(tMessage.Uri[85]);
            writer.Write(tMessage.Uri[86]);
            writer.Write(tMessage.Uri[87]);
            writer.Write(tMessage.Uri[88]);
            writer.Write(tMessage.Uri[89]);
            writer.Write(tMessage.Uri[90]);
            writer.Write(tMessage.Uri[91]);
            writer.Write(tMessage.Uri[92]);
            writer.Write(tMessage.Uri[93]);
            writer.Write(tMessage.Uri[94]);
            writer.Write(tMessage.Uri[95]);
            writer.Write(tMessage.Uri[96]);
            writer.Write(tMessage.Uri[97]);
            writer.Write(tMessage.Uri[98]);
            writer.Write(tMessage.Uri[99]);
            writer.Write(tMessage.Uri[100]);
            writer.Write(tMessage.Uri[101]);
            writer.Write(tMessage.Uri[102]);
            writer.Write(tMessage.Uri[103]);
            writer.Write(tMessage.Uri[104]);
            writer.Write(tMessage.Uri[105]);
            writer.Write(tMessage.Uri[106]);
            writer.Write(tMessage.Uri[107]);
            writer.Write(tMessage.Uri[108]);
            writer.Write(tMessage.Uri[109]);
            writer.Write(tMessage.Uri[110]);
            writer.Write(tMessage.Uri[111]);
            writer.Write(tMessage.Uri[112]);
            writer.Write(tMessage.Uri[113]);
            writer.Write(tMessage.Uri[114]);
            writer.Write(tMessage.Uri[115]);
            writer.Write(tMessage.Uri[116]);
            writer.Write(tMessage.Uri[117]);
            writer.Write(tMessage.Uri[118]);
            writer.Write(tMessage.Uri[119]);
            writer.Write(tMessage.TransferType);
            writer.Write(tMessage.Storage[0]);
            writer.Write(tMessage.Storage[1]);
            writer.Write(tMessage.Storage[2]);
            writer.Write(tMessage.Storage[3]);
            writer.Write(tMessage.Storage[4]);
            writer.Write(tMessage.Storage[5]);
            writer.Write(tMessage.Storage[6]);
            writer.Write(tMessage.Storage[7]);
            writer.Write(tMessage.Storage[8]);
            writer.Write(tMessage.Storage[9]);
            writer.Write(tMessage.Storage[10]);
            writer.Write(tMessage.Storage[11]);
            writer.Write(tMessage.Storage[12]);
            writer.Write(tMessage.Storage[13]);
            writer.Write(tMessage.Storage[14]);
            writer.Write(tMessage.Storage[15]);
            writer.Write(tMessage.Storage[16]);
            writer.Write(tMessage.Storage[17]);
            writer.Write(tMessage.Storage[18]);
            writer.Write(tMessage.Storage[19]);
            writer.Write(tMessage.Storage[20]);
            writer.Write(tMessage.Storage[21]);
            writer.Write(tMessage.Storage[22]);
            writer.Write(tMessage.Storage[23]);
            writer.Write(tMessage.Storage[24]);
            writer.Write(tMessage.Storage[25]);
            writer.Write(tMessage.Storage[26]);
            writer.Write(tMessage.Storage[27]);
            writer.Write(tMessage.Storage[28]);
            writer.Write(tMessage.Storage[29]);
            writer.Write(tMessage.Storage[30]);
            writer.Write(tMessage.Storage[31]);
            writer.Write(tMessage.Storage[32]);
            writer.Write(tMessage.Storage[33]);
            writer.Write(tMessage.Storage[34]);
            writer.Write(tMessage.Storage[35]);
            writer.Write(tMessage.Storage[36]);
            writer.Write(tMessage.Storage[37]);
            writer.Write(tMessage.Storage[38]);
            writer.Write(tMessage.Storage[39]);
            writer.Write(tMessage.Storage[40]);
            writer.Write(tMessage.Storage[41]);
            writer.Write(tMessage.Storage[42]);
            writer.Write(tMessage.Storage[43]);
            writer.Write(tMessage.Storage[44]);
            writer.Write(tMessage.Storage[45]);
            writer.Write(tMessage.Storage[46]);
            writer.Write(tMessage.Storage[47]);
            writer.Write(tMessage.Storage[48]);
            writer.Write(tMessage.Storage[49]);
            writer.Write(tMessage.Storage[50]);
            writer.Write(tMessage.Storage[51]);
            writer.Write(tMessage.Storage[52]);
            writer.Write(tMessage.Storage[53]);
            writer.Write(tMessage.Storage[54]);
            writer.Write(tMessage.Storage[55]);
            writer.Write(tMessage.Storage[56]);
            writer.Write(tMessage.Storage[57]);
            writer.Write(tMessage.Storage[58]);
            writer.Write(tMessage.Storage[59]);
            writer.Write(tMessage.Storage[60]);
            writer.Write(tMessage.Storage[61]);
            writer.Write(tMessage.Storage[62]);
            writer.Write(tMessage.Storage[63]);
            writer.Write(tMessage.Storage[64]);
            writer.Write(tMessage.Storage[65]);
            writer.Write(tMessage.Storage[66]);
            writer.Write(tMessage.Storage[67]);
            writer.Write(tMessage.Storage[68]);
            writer.Write(tMessage.Storage[69]);
            writer.Write(tMessage.Storage[70]);
            writer.Write(tMessage.Storage[71]);
            writer.Write(tMessage.Storage[72]);
            writer.Write(tMessage.Storage[73]);
            writer.Write(tMessage.Storage[74]);
            writer.Write(tMessage.Storage[75]);
            writer.Write(tMessage.Storage[76]);
            writer.Write(tMessage.Storage[77]);
            writer.Write(tMessage.Storage[78]);
            writer.Write(tMessage.Storage[79]);
            writer.Write(tMessage.Storage[80]);
            writer.Write(tMessage.Storage[81]);
            writer.Write(tMessage.Storage[82]);
            writer.Write(tMessage.Storage[83]);
            writer.Write(tMessage.Storage[84]);
            writer.Write(tMessage.Storage[85]);
            writer.Write(tMessage.Storage[86]);
            writer.Write(tMessage.Storage[87]);
            writer.Write(tMessage.Storage[88]);
            writer.Write(tMessage.Storage[89]);
            writer.Write(tMessage.Storage[90]);
            writer.Write(tMessage.Storage[91]);
            writer.Write(tMessage.Storage[92]);
            writer.Write(tMessage.Storage[93]);
            writer.Write(tMessage.Storage[94]);
            writer.Write(tMessage.Storage[95]);
            writer.Write(tMessage.Storage[96]);
            writer.Write(tMessage.Storage[97]);
            writer.Write(tMessage.Storage[98]);
            writer.Write(tMessage.Storage[99]);
            writer.Write(tMessage.Storage[100]);
            writer.Write(tMessage.Storage[101]);
            writer.Write(tMessage.Storage[102]);
            writer.Write(tMessage.Storage[103]);
            writer.Write(tMessage.Storage[104]);
            writer.Write(tMessage.Storage[105]);
            writer.Write(tMessage.Storage[106]);
            writer.Write(tMessage.Storage[107]);
            writer.Write(tMessage.Storage[108]);
            writer.Write(tMessage.Storage[109]);
            writer.Write(tMessage.Storage[110]);
            writer.Write(tMessage.Storage[111]);
            writer.Write(tMessage.Storage[112]);
            writer.Write(tMessage.Storage[113]);
            writer.Write(tMessage.Storage[114]);
            writer.Write(tMessage.Storage[115]);
            writer.Write(tMessage.Storage[116]);
            writer.Write(tMessage.Storage[117]);
            writer.Write(tMessage.Storage[118]);
            writer.Write(tMessage.Storage[119]);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.ResourceRequestMessage message = new MavLink4Net.Messages.Common.ResourceRequestMessage();
            message.RequestId = reader.ReadByte();
            message.UriType = reader.ReadByte();
            message.Uri[0] = reader.ReadByte();
            message.Uri[1] = reader.ReadByte();
            message.Uri[2] = reader.ReadByte();
            message.Uri[3] = reader.ReadByte();
            message.Uri[4] = reader.ReadByte();
            message.Uri[5] = reader.ReadByte();
            message.Uri[6] = reader.ReadByte();
            message.Uri[7] = reader.ReadByte();
            message.Uri[8] = reader.ReadByte();
            message.Uri[9] = reader.ReadByte();
            message.Uri[10] = reader.ReadByte();
            message.Uri[11] = reader.ReadByte();
            message.Uri[12] = reader.ReadByte();
            message.Uri[13] = reader.ReadByte();
            message.Uri[14] = reader.ReadByte();
            message.Uri[15] = reader.ReadByte();
            message.Uri[16] = reader.ReadByte();
            message.Uri[17] = reader.ReadByte();
            message.Uri[18] = reader.ReadByte();
            message.Uri[19] = reader.ReadByte();
            message.Uri[20] = reader.ReadByte();
            message.Uri[21] = reader.ReadByte();
            message.Uri[22] = reader.ReadByte();
            message.Uri[23] = reader.ReadByte();
            message.Uri[24] = reader.ReadByte();
            message.Uri[25] = reader.ReadByte();
            message.Uri[26] = reader.ReadByte();
            message.Uri[27] = reader.ReadByte();
            message.Uri[28] = reader.ReadByte();
            message.Uri[29] = reader.ReadByte();
            message.Uri[30] = reader.ReadByte();
            message.Uri[31] = reader.ReadByte();
            message.Uri[32] = reader.ReadByte();
            message.Uri[33] = reader.ReadByte();
            message.Uri[34] = reader.ReadByte();
            message.Uri[35] = reader.ReadByte();
            message.Uri[36] = reader.ReadByte();
            message.Uri[37] = reader.ReadByte();
            message.Uri[38] = reader.ReadByte();
            message.Uri[39] = reader.ReadByte();
            message.Uri[40] = reader.ReadByte();
            message.Uri[41] = reader.ReadByte();
            message.Uri[42] = reader.ReadByte();
            message.Uri[43] = reader.ReadByte();
            message.Uri[44] = reader.ReadByte();
            message.Uri[45] = reader.ReadByte();
            message.Uri[46] = reader.ReadByte();
            message.Uri[47] = reader.ReadByte();
            message.Uri[48] = reader.ReadByte();
            message.Uri[49] = reader.ReadByte();
            message.Uri[50] = reader.ReadByte();
            message.Uri[51] = reader.ReadByte();
            message.Uri[52] = reader.ReadByte();
            message.Uri[53] = reader.ReadByte();
            message.Uri[54] = reader.ReadByte();
            message.Uri[55] = reader.ReadByte();
            message.Uri[56] = reader.ReadByte();
            message.Uri[57] = reader.ReadByte();
            message.Uri[58] = reader.ReadByte();
            message.Uri[59] = reader.ReadByte();
            message.Uri[60] = reader.ReadByte();
            message.Uri[61] = reader.ReadByte();
            message.Uri[62] = reader.ReadByte();
            message.Uri[63] = reader.ReadByte();
            message.Uri[64] = reader.ReadByte();
            message.Uri[65] = reader.ReadByte();
            message.Uri[66] = reader.ReadByte();
            message.Uri[67] = reader.ReadByte();
            message.Uri[68] = reader.ReadByte();
            message.Uri[69] = reader.ReadByte();
            message.Uri[70] = reader.ReadByte();
            message.Uri[71] = reader.ReadByte();
            message.Uri[72] = reader.ReadByte();
            message.Uri[73] = reader.ReadByte();
            message.Uri[74] = reader.ReadByte();
            message.Uri[75] = reader.ReadByte();
            message.Uri[76] = reader.ReadByte();
            message.Uri[77] = reader.ReadByte();
            message.Uri[78] = reader.ReadByte();
            message.Uri[79] = reader.ReadByte();
            message.Uri[80] = reader.ReadByte();
            message.Uri[81] = reader.ReadByte();
            message.Uri[82] = reader.ReadByte();
            message.Uri[83] = reader.ReadByte();
            message.Uri[84] = reader.ReadByte();
            message.Uri[85] = reader.ReadByte();
            message.Uri[86] = reader.ReadByte();
            message.Uri[87] = reader.ReadByte();
            message.Uri[88] = reader.ReadByte();
            message.Uri[89] = reader.ReadByte();
            message.Uri[90] = reader.ReadByte();
            message.Uri[91] = reader.ReadByte();
            message.Uri[92] = reader.ReadByte();
            message.Uri[93] = reader.ReadByte();
            message.Uri[94] = reader.ReadByte();
            message.Uri[95] = reader.ReadByte();
            message.Uri[96] = reader.ReadByte();
            message.Uri[97] = reader.ReadByte();
            message.Uri[98] = reader.ReadByte();
            message.Uri[99] = reader.ReadByte();
            message.Uri[100] = reader.ReadByte();
            message.Uri[101] = reader.ReadByte();
            message.Uri[102] = reader.ReadByte();
            message.Uri[103] = reader.ReadByte();
            message.Uri[104] = reader.ReadByte();
            message.Uri[105] = reader.ReadByte();
            message.Uri[106] = reader.ReadByte();
            message.Uri[107] = reader.ReadByte();
            message.Uri[108] = reader.ReadByte();
            message.Uri[109] = reader.ReadByte();
            message.Uri[110] = reader.ReadByte();
            message.Uri[111] = reader.ReadByte();
            message.Uri[112] = reader.ReadByte();
            message.Uri[113] = reader.ReadByte();
            message.Uri[114] = reader.ReadByte();
            message.Uri[115] = reader.ReadByte();
            message.Uri[116] = reader.ReadByte();
            message.Uri[117] = reader.ReadByte();
            message.Uri[118] = reader.ReadByte();
            message.Uri[119] = reader.ReadByte();
            message.TransferType = reader.ReadByte();
            message.Storage[0] = reader.ReadByte();
            message.Storage[1] = reader.ReadByte();
            message.Storage[2] = reader.ReadByte();
            message.Storage[3] = reader.ReadByte();
            message.Storage[4] = reader.ReadByte();
            message.Storage[5] = reader.ReadByte();
            message.Storage[6] = reader.ReadByte();
            message.Storage[7] = reader.ReadByte();
            message.Storage[8] = reader.ReadByte();
            message.Storage[9] = reader.ReadByte();
            message.Storage[10] = reader.ReadByte();
            message.Storage[11] = reader.ReadByte();
            message.Storage[12] = reader.ReadByte();
            message.Storage[13] = reader.ReadByte();
            message.Storage[14] = reader.ReadByte();
            message.Storage[15] = reader.ReadByte();
            message.Storage[16] = reader.ReadByte();
            message.Storage[17] = reader.ReadByte();
            message.Storage[18] = reader.ReadByte();
            message.Storage[19] = reader.ReadByte();
            message.Storage[20] = reader.ReadByte();
            message.Storage[21] = reader.ReadByte();
            message.Storage[22] = reader.ReadByte();
            message.Storage[23] = reader.ReadByte();
            message.Storage[24] = reader.ReadByte();
            message.Storage[25] = reader.ReadByte();
            message.Storage[26] = reader.ReadByte();
            message.Storage[27] = reader.ReadByte();
            message.Storage[28] = reader.ReadByte();
            message.Storage[29] = reader.ReadByte();
            message.Storage[30] = reader.ReadByte();
            message.Storage[31] = reader.ReadByte();
            message.Storage[32] = reader.ReadByte();
            message.Storage[33] = reader.ReadByte();
            message.Storage[34] = reader.ReadByte();
            message.Storage[35] = reader.ReadByte();
            message.Storage[36] = reader.ReadByte();
            message.Storage[37] = reader.ReadByte();
            message.Storage[38] = reader.ReadByte();
            message.Storage[39] = reader.ReadByte();
            message.Storage[40] = reader.ReadByte();
            message.Storage[41] = reader.ReadByte();
            message.Storage[42] = reader.ReadByte();
            message.Storage[43] = reader.ReadByte();
            message.Storage[44] = reader.ReadByte();
            message.Storage[45] = reader.ReadByte();
            message.Storage[46] = reader.ReadByte();
            message.Storage[47] = reader.ReadByte();
            message.Storage[48] = reader.ReadByte();
            message.Storage[49] = reader.ReadByte();
            message.Storage[50] = reader.ReadByte();
            message.Storage[51] = reader.ReadByte();
            message.Storage[52] = reader.ReadByte();
            message.Storage[53] = reader.ReadByte();
            message.Storage[54] = reader.ReadByte();
            message.Storage[55] = reader.ReadByte();
            message.Storage[56] = reader.ReadByte();
            message.Storage[57] = reader.ReadByte();
            message.Storage[58] = reader.ReadByte();
            message.Storage[59] = reader.ReadByte();
            message.Storage[60] = reader.ReadByte();
            message.Storage[61] = reader.ReadByte();
            message.Storage[62] = reader.ReadByte();
            message.Storage[63] = reader.ReadByte();
            message.Storage[64] = reader.ReadByte();
            message.Storage[65] = reader.ReadByte();
            message.Storage[66] = reader.ReadByte();
            message.Storage[67] = reader.ReadByte();
            message.Storage[68] = reader.ReadByte();
            message.Storage[69] = reader.ReadByte();
            message.Storage[70] = reader.ReadByte();
            message.Storage[71] = reader.ReadByte();
            message.Storage[72] = reader.ReadByte();
            message.Storage[73] = reader.ReadByte();
            message.Storage[74] = reader.ReadByte();
            message.Storage[75] = reader.ReadByte();
            message.Storage[76] = reader.ReadByte();
            message.Storage[77] = reader.ReadByte();
            message.Storage[78] = reader.ReadByte();
            message.Storage[79] = reader.ReadByte();
            message.Storage[80] = reader.ReadByte();
            message.Storage[81] = reader.ReadByte();
            message.Storage[82] = reader.ReadByte();
            message.Storage[83] = reader.ReadByte();
            message.Storage[84] = reader.ReadByte();
            message.Storage[85] = reader.ReadByte();
            message.Storage[86] = reader.ReadByte();
            message.Storage[87] = reader.ReadByte();
            message.Storage[88] = reader.ReadByte();
            message.Storage[89] = reader.ReadByte();
            message.Storage[90] = reader.ReadByte();
            message.Storage[91] = reader.ReadByte();
            message.Storage[92] = reader.ReadByte();
            message.Storage[93] = reader.ReadByte();
            message.Storage[94] = reader.ReadByte();
            message.Storage[95] = reader.ReadByte();
            message.Storage[96] = reader.ReadByte();
            message.Storage[97] = reader.ReadByte();
            message.Storage[98] = reader.ReadByte();
            message.Storage[99] = reader.ReadByte();
            message.Storage[100] = reader.ReadByte();
            message.Storage[101] = reader.ReadByte();
            message.Storage[102] = reader.ReadByte();
            message.Storage[103] = reader.ReadByte();
            message.Storage[104] = reader.ReadByte();
            message.Storage[105] = reader.ReadByte();
            message.Storage[106] = reader.ReadByte();
            message.Storage[107] = reader.ReadByte();
            message.Storage[108] = reader.ReadByte();
            message.Storage[109] = reader.ReadByte();
            message.Storage[110] = reader.ReadByte();
            message.Storage[111] = reader.ReadByte();
            message.Storage[112] = reader.ReadByte();
            message.Storage[113] = reader.ReadByte();
            message.Storage[114] = reader.ReadByte();
            message.Storage[115] = reader.ReadByte();
            message.Storage[116] = reader.ReadByte();
            message.Storage[117] = reader.ReadByte();
            message.Storage[118] = reader.ReadByte();
            message.Storage[119] = reader.ReadByte();
            return message;
        }
    }
}
