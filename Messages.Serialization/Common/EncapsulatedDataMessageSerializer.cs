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
    
    
    public class EncapsulatedDataMessageSerializer : MavLink4Net.Messages.Serialization.IMessageSerializer
    {
        
        public void Serialize(System.IO.BinaryWriter writer, MavLink4Net.Messages.IMessage message)
        {
            MavLink4Net.Messages.Common.EncapsulatedDataMessage tMessage = message as MavLink4Net.Messages.Common.EncapsulatedDataMessage;
            writer.Write(tMessage.Seqnr);
            writer.Write(tMessage.Data[0]);
            writer.Write(tMessage.Data[1]);
            writer.Write(tMessage.Data[2]);
            writer.Write(tMessage.Data[3]);
            writer.Write(tMessage.Data[4]);
            writer.Write(tMessage.Data[5]);
            writer.Write(tMessage.Data[6]);
            writer.Write(tMessage.Data[7]);
            writer.Write(tMessage.Data[8]);
            writer.Write(tMessage.Data[9]);
            writer.Write(tMessage.Data[10]);
            writer.Write(tMessage.Data[11]);
            writer.Write(tMessage.Data[12]);
            writer.Write(tMessage.Data[13]);
            writer.Write(tMessage.Data[14]);
            writer.Write(tMessage.Data[15]);
            writer.Write(tMessage.Data[16]);
            writer.Write(tMessage.Data[17]);
            writer.Write(tMessage.Data[18]);
            writer.Write(tMessage.Data[19]);
            writer.Write(tMessage.Data[20]);
            writer.Write(tMessage.Data[21]);
            writer.Write(tMessage.Data[22]);
            writer.Write(tMessage.Data[23]);
            writer.Write(tMessage.Data[24]);
            writer.Write(tMessage.Data[25]);
            writer.Write(tMessage.Data[26]);
            writer.Write(tMessage.Data[27]);
            writer.Write(tMessage.Data[28]);
            writer.Write(tMessage.Data[29]);
            writer.Write(tMessage.Data[30]);
            writer.Write(tMessage.Data[31]);
            writer.Write(tMessage.Data[32]);
            writer.Write(tMessage.Data[33]);
            writer.Write(tMessage.Data[34]);
            writer.Write(tMessage.Data[35]);
            writer.Write(tMessage.Data[36]);
            writer.Write(tMessage.Data[37]);
            writer.Write(tMessage.Data[38]);
            writer.Write(tMessage.Data[39]);
            writer.Write(tMessage.Data[40]);
            writer.Write(tMessage.Data[41]);
            writer.Write(tMessage.Data[42]);
            writer.Write(tMessage.Data[43]);
            writer.Write(tMessage.Data[44]);
            writer.Write(tMessage.Data[45]);
            writer.Write(tMessage.Data[46]);
            writer.Write(tMessage.Data[47]);
            writer.Write(tMessage.Data[48]);
            writer.Write(tMessage.Data[49]);
            writer.Write(tMessage.Data[50]);
            writer.Write(tMessage.Data[51]);
            writer.Write(tMessage.Data[52]);
            writer.Write(tMessage.Data[53]);
            writer.Write(tMessage.Data[54]);
            writer.Write(tMessage.Data[55]);
            writer.Write(tMessage.Data[56]);
            writer.Write(tMessage.Data[57]);
            writer.Write(tMessage.Data[58]);
            writer.Write(tMessage.Data[59]);
            writer.Write(tMessage.Data[60]);
            writer.Write(tMessage.Data[61]);
            writer.Write(tMessage.Data[62]);
            writer.Write(tMessage.Data[63]);
            writer.Write(tMessage.Data[64]);
            writer.Write(tMessage.Data[65]);
            writer.Write(tMessage.Data[66]);
            writer.Write(tMessage.Data[67]);
            writer.Write(tMessage.Data[68]);
            writer.Write(tMessage.Data[69]);
            writer.Write(tMessage.Data[70]);
            writer.Write(tMessage.Data[71]);
            writer.Write(tMessage.Data[72]);
            writer.Write(tMessage.Data[73]);
            writer.Write(tMessage.Data[74]);
            writer.Write(tMessage.Data[75]);
            writer.Write(tMessage.Data[76]);
            writer.Write(tMessage.Data[77]);
            writer.Write(tMessage.Data[78]);
            writer.Write(tMessage.Data[79]);
            writer.Write(tMessage.Data[80]);
            writer.Write(tMessage.Data[81]);
            writer.Write(tMessage.Data[82]);
            writer.Write(tMessage.Data[83]);
            writer.Write(tMessage.Data[84]);
            writer.Write(tMessage.Data[85]);
            writer.Write(tMessage.Data[86]);
            writer.Write(tMessage.Data[87]);
            writer.Write(tMessage.Data[88]);
            writer.Write(tMessage.Data[89]);
            writer.Write(tMessage.Data[90]);
            writer.Write(tMessage.Data[91]);
            writer.Write(tMessage.Data[92]);
            writer.Write(tMessage.Data[93]);
            writer.Write(tMessage.Data[94]);
            writer.Write(tMessage.Data[95]);
            writer.Write(tMessage.Data[96]);
            writer.Write(tMessage.Data[97]);
            writer.Write(tMessage.Data[98]);
            writer.Write(tMessage.Data[99]);
            writer.Write(tMessage.Data[100]);
            writer.Write(tMessage.Data[101]);
            writer.Write(tMessage.Data[102]);
            writer.Write(tMessage.Data[103]);
            writer.Write(tMessage.Data[104]);
            writer.Write(tMessage.Data[105]);
            writer.Write(tMessage.Data[106]);
            writer.Write(tMessage.Data[107]);
            writer.Write(tMessage.Data[108]);
            writer.Write(tMessage.Data[109]);
            writer.Write(tMessage.Data[110]);
            writer.Write(tMessage.Data[111]);
            writer.Write(tMessage.Data[112]);
            writer.Write(tMessage.Data[113]);
            writer.Write(tMessage.Data[114]);
            writer.Write(tMessage.Data[115]);
            writer.Write(tMessage.Data[116]);
            writer.Write(tMessage.Data[117]);
            writer.Write(tMessage.Data[118]);
            writer.Write(tMessage.Data[119]);
            writer.Write(tMessage.Data[120]);
            writer.Write(tMessage.Data[121]);
            writer.Write(tMessage.Data[122]);
            writer.Write(tMessage.Data[123]);
            writer.Write(tMessage.Data[124]);
            writer.Write(tMessage.Data[125]);
            writer.Write(tMessage.Data[126]);
            writer.Write(tMessage.Data[127]);
            writer.Write(tMessage.Data[128]);
            writer.Write(tMessage.Data[129]);
            writer.Write(tMessage.Data[130]);
            writer.Write(tMessage.Data[131]);
            writer.Write(tMessage.Data[132]);
            writer.Write(tMessage.Data[133]);
            writer.Write(tMessage.Data[134]);
            writer.Write(tMessage.Data[135]);
            writer.Write(tMessage.Data[136]);
            writer.Write(tMessage.Data[137]);
            writer.Write(tMessage.Data[138]);
            writer.Write(tMessage.Data[139]);
            writer.Write(tMessage.Data[140]);
            writer.Write(tMessage.Data[141]);
            writer.Write(tMessage.Data[142]);
            writer.Write(tMessage.Data[143]);
            writer.Write(tMessage.Data[144]);
            writer.Write(tMessage.Data[145]);
            writer.Write(tMessage.Data[146]);
            writer.Write(tMessage.Data[147]);
            writer.Write(tMessage.Data[148]);
            writer.Write(tMessage.Data[149]);
            writer.Write(tMessage.Data[150]);
            writer.Write(tMessage.Data[151]);
            writer.Write(tMessage.Data[152]);
            writer.Write(tMessage.Data[153]);
            writer.Write(tMessage.Data[154]);
            writer.Write(tMessage.Data[155]);
            writer.Write(tMessage.Data[156]);
            writer.Write(tMessage.Data[157]);
            writer.Write(tMessage.Data[158]);
            writer.Write(tMessage.Data[159]);
            writer.Write(tMessage.Data[160]);
            writer.Write(tMessage.Data[161]);
            writer.Write(tMessage.Data[162]);
            writer.Write(tMessage.Data[163]);
            writer.Write(tMessage.Data[164]);
            writer.Write(tMessage.Data[165]);
            writer.Write(tMessage.Data[166]);
            writer.Write(tMessage.Data[167]);
            writer.Write(tMessage.Data[168]);
            writer.Write(tMessage.Data[169]);
            writer.Write(tMessage.Data[170]);
            writer.Write(tMessage.Data[171]);
            writer.Write(tMessage.Data[172]);
            writer.Write(tMessage.Data[173]);
            writer.Write(tMessage.Data[174]);
            writer.Write(tMessage.Data[175]);
            writer.Write(tMessage.Data[176]);
            writer.Write(tMessage.Data[177]);
            writer.Write(tMessage.Data[178]);
            writer.Write(tMessage.Data[179]);
            writer.Write(tMessage.Data[180]);
            writer.Write(tMessage.Data[181]);
            writer.Write(tMessage.Data[182]);
            writer.Write(tMessage.Data[183]);
            writer.Write(tMessage.Data[184]);
            writer.Write(tMessage.Data[185]);
            writer.Write(tMessage.Data[186]);
            writer.Write(tMessage.Data[187]);
            writer.Write(tMessage.Data[188]);
            writer.Write(tMessage.Data[189]);
            writer.Write(tMessage.Data[190]);
            writer.Write(tMessage.Data[191]);
            writer.Write(tMessage.Data[192]);
            writer.Write(tMessage.Data[193]);
            writer.Write(tMessage.Data[194]);
            writer.Write(tMessage.Data[195]);
            writer.Write(tMessage.Data[196]);
            writer.Write(tMessage.Data[197]);
            writer.Write(tMessage.Data[198]);
            writer.Write(tMessage.Data[199]);
            writer.Write(tMessage.Data[200]);
            writer.Write(tMessage.Data[201]);
            writer.Write(tMessage.Data[202]);
            writer.Write(tMessage.Data[203]);
            writer.Write(tMessage.Data[204]);
            writer.Write(tMessage.Data[205]);
            writer.Write(tMessage.Data[206]);
            writer.Write(tMessage.Data[207]);
            writer.Write(tMessage.Data[208]);
            writer.Write(tMessage.Data[209]);
            writer.Write(tMessage.Data[210]);
            writer.Write(tMessage.Data[211]);
            writer.Write(tMessage.Data[212]);
            writer.Write(tMessage.Data[213]);
            writer.Write(tMessage.Data[214]);
            writer.Write(tMessage.Data[215]);
            writer.Write(tMessage.Data[216]);
            writer.Write(tMessage.Data[217]);
            writer.Write(tMessage.Data[218]);
            writer.Write(tMessage.Data[219]);
            writer.Write(tMessage.Data[220]);
            writer.Write(tMessage.Data[221]);
            writer.Write(tMessage.Data[222]);
            writer.Write(tMessage.Data[223]);
            writer.Write(tMessage.Data[224]);
            writer.Write(tMessage.Data[225]);
            writer.Write(tMessage.Data[226]);
            writer.Write(tMessage.Data[227]);
            writer.Write(tMessage.Data[228]);
            writer.Write(tMessage.Data[229]);
            writer.Write(tMessage.Data[230]);
            writer.Write(tMessage.Data[231]);
            writer.Write(tMessage.Data[232]);
            writer.Write(tMessage.Data[233]);
            writer.Write(tMessage.Data[234]);
            writer.Write(tMessage.Data[235]);
            writer.Write(tMessage.Data[236]);
            writer.Write(tMessage.Data[237]);
            writer.Write(tMessage.Data[238]);
            writer.Write(tMessage.Data[239]);
            writer.Write(tMessage.Data[240]);
            writer.Write(tMessage.Data[241]);
            writer.Write(tMessage.Data[242]);
            writer.Write(tMessage.Data[243]);
            writer.Write(tMessage.Data[244]);
            writer.Write(tMessage.Data[245]);
            writer.Write(tMessage.Data[246]);
            writer.Write(tMessage.Data[247]);
            writer.Write(tMessage.Data[248]);
            writer.Write(tMessage.Data[249]);
            writer.Write(tMessage.Data[250]);
            writer.Write(tMessage.Data[251]);
            writer.Write(tMessage.Data[252]);
        }
        
        public MavLink4Net.Messages.IMessage Deserialize(System.IO.BinaryReader reader)
        {
            MavLink4Net.Messages.Common.EncapsulatedDataMessage message = new MavLink4Net.Messages.Common.EncapsulatedDataMessage();
            message.Seqnr = reader.ReadUInt16();
            message.Data[0] = reader.ReadByte();
            message.Data[1] = reader.ReadByte();
            message.Data[2] = reader.ReadByte();
            message.Data[3] = reader.ReadByte();
            message.Data[4] = reader.ReadByte();
            message.Data[5] = reader.ReadByte();
            message.Data[6] = reader.ReadByte();
            message.Data[7] = reader.ReadByte();
            message.Data[8] = reader.ReadByte();
            message.Data[9] = reader.ReadByte();
            message.Data[10] = reader.ReadByte();
            message.Data[11] = reader.ReadByte();
            message.Data[12] = reader.ReadByte();
            message.Data[13] = reader.ReadByte();
            message.Data[14] = reader.ReadByte();
            message.Data[15] = reader.ReadByte();
            message.Data[16] = reader.ReadByte();
            message.Data[17] = reader.ReadByte();
            message.Data[18] = reader.ReadByte();
            message.Data[19] = reader.ReadByte();
            message.Data[20] = reader.ReadByte();
            message.Data[21] = reader.ReadByte();
            message.Data[22] = reader.ReadByte();
            message.Data[23] = reader.ReadByte();
            message.Data[24] = reader.ReadByte();
            message.Data[25] = reader.ReadByte();
            message.Data[26] = reader.ReadByte();
            message.Data[27] = reader.ReadByte();
            message.Data[28] = reader.ReadByte();
            message.Data[29] = reader.ReadByte();
            message.Data[30] = reader.ReadByte();
            message.Data[31] = reader.ReadByte();
            message.Data[32] = reader.ReadByte();
            message.Data[33] = reader.ReadByte();
            message.Data[34] = reader.ReadByte();
            message.Data[35] = reader.ReadByte();
            message.Data[36] = reader.ReadByte();
            message.Data[37] = reader.ReadByte();
            message.Data[38] = reader.ReadByte();
            message.Data[39] = reader.ReadByte();
            message.Data[40] = reader.ReadByte();
            message.Data[41] = reader.ReadByte();
            message.Data[42] = reader.ReadByte();
            message.Data[43] = reader.ReadByte();
            message.Data[44] = reader.ReadByte();
            message.Data[45] = reader.ReadByte();
            message.Data[46] = reader.ReadByte();
            message.Data[47] = reader.ReadByte();
            message.Data[48] = reader.ReadByte();
            message.Data[49] = reader.ReadByte();
            message.Data[50] = reader.ReadByte();
            message.Data[51] = reader.ReadByte();
            message.Data[52] = reader.ReadByte();
            message.Data[53] = reader.ReadByte();
            message.Data[54] = reader.ReadByte();
            message.Data[55] = reader.ReadByte();
            message.Data[56] = reader.ReadByte();
            message.Data[57] = reader.ReadByte();
            message.Data[58] = reader.ReadByte();
            message.Data[59] = reader.ReadByte();
            message.Data[60] = reader.ReadByte();
            message.Data[61] = reader.ReadByte();
            message.Data[62] = reader.ReadByte();
            message.Data[63] = reader.ReadByte();
            message.Data[64] = reader.ReadByte();
            message.Data[65] = reader.ReadByte();
            message.Data[66] = reader.ReadByte();
            message.Data[67] = reader.ReadByte();
            message.Data[68] = reader.ReadByte();
            message.Data[69] = reader.ReadByte();
            message.Data[70] = reader.ReadByte();
            message.Data[71] = reader.ReadByte();
            message.Data[72] = reader.ReadByte();
            message.Data[73] = reader.ReadByte();
            message.Data[74] = reader.ReadByte();
            message.Data[75] = reader.ReadByte();
            message.Data[76] = reader.ReadByte();
            message.Data[77] = reader.ReadByte();
            message.Data[78] = reader.ReadByte();
            message.Data[79] = reader.ReadByte();
            message.Data[80] = reader.ReadByte();
            message.Data[81] = reader.ReadByte();
            message.Data[82] = reader.ReadByte();
            message.Data[83] = reader.ReadByte();
            message.Data[84] = reader.ReadByte();
            message.Data[85] = reader.ReadByte();
            message.Data[86] = reader.ReadByte();
            message.Data[87] = reader.ReadByte();
            message.Data[88] = reader.ReadByte();
            message.Data[89] = reader.ReadByte();
            message.Data[90] = reader.ReadByte();
            message.Data[91] = reader.ReadByte();
            message.Data[92] = reader.ReadByte();
            message.Data[93] = reader.ReadByte();
            message.Data[94] = reader.ReadByte();
            message.Data[95] = reader.ReadByte();
            message.Data[96] = reader.ReadByte();
            message.Data[97] = reader.ReadByte();
            message.Data[98] = reader.ReadByte();
            message.Data[99] = reader.ReadByte();
            message.Data[100] = reader.ReadByte();
            message.Data[101] = reader.ReadByte();
            message.Data[102] = reader.ReadByte();
            message.Data[103] = reader.ReadByte();
            message.Data[104] = reader.ReadByte();
            message.Data[105] = reader.ReadByte();
            message.Data[106] = reader.ReadByte();
            message.Data[107] = reader.ReadByte();
            message.Data[108] = reader.ReadByte();
            message.Data[109] = reader.ReadByte();
            message.Data[110] = reader.ReadByte();
            message.Data[111] = reader.ReadByte();
            message.Data[112] = reader.ReadByte();
            message.Data[113] = reader.ReadByte();
            message.Data[114] = reader.ReadByte();
            message.Data[115] = reader.ReadByte();
            message.Data[116] = reader.ReadByte();
            message.Data[117] = reader.ReadByte();
            message.Data[118] = reader.ReadByte();
            message.Data[119] = reader.ReadByte();
            message.Data[120] = reader.ReadByte();
            message.Data[121] = reader.ReadByte();
            message.Data[122] = reader.ReadByte();
            message.Data[123] = reader.ReadByte();
            message.Data[124] = reader.ReadByte();
            message.Data[125] = reader.ReadByte();
            message.Data[126] = reader.ReadByte();
            message.Data[127] = reader.ReadByte();
            message.Data[128] = reader.ReadByte();
            message.Data[129] = reader.ReadByte();
            message.Data[130] = reader.ReadByte();
            message.Data[131] = reader.ReadByte();
            message.Data[132] = reader.ReadByte();
            message.Data[133] = reader.ReadByte();
            message.Data[134] = reader.ReadByte();
            message.Data[135] = reader.ReadByte();
            message.Data[136] = reader.ReadByte();
            message.Data[137] = reader.ReadByte();
            message.Data[138] = reader.ReadByte();
            message.Data[139] = reader.ReadByte();
            message.Data[140] = reader.ReadByte();
            message.Data[141] = reader.ReadByte();
            message.Data[142] = reader.ReadByte();
            message.Data[143] = reader.ReadByte();
            message.Data[144] = reader.ReadByte();
            message.Data[145] = reader.ReadByte();
            message.Data[146] = reader.ReadByte();
            message.Data[147] = reader.ReadByte();
            message.Data[148] = reader.ReadByte();
            message.Data[149] = reader.ReadByte();
            message.Data[150] = reader.ReadByte();
            message.Data[151] = reader.ReadByte();
            message.Data[152] = reader.ReadByte();
            message.Data[153] = reader.ReadByte();
            message.Data[154] = reader.ReadByte();
            message.Data[155] = reader.ReadByte();
            message.Data[156] = reader.ReadByte();
            message.Data[157] = reader.ReadByte();
            message.Data[158] = reader.ReadByte();
            message.Data[159] = reader.ReadByte();
            message.Data[160] = reader.ReadByte();
            message.Data[161] = reader.ReadByte();
            message.Data[162] = reader.ReadByte();
            message.Data[163] = reader.ReadByte();
            message.Data[164] = reader.ReadByte();
            message.Data[165] = reader.ReadByte();
            message.Data[166] = reader.ReadByte();
            message.Data[167] = reader.ReadByte();
            message.Data[168] = reader.ReadByte();
            message.Data[169] = reader.ReadByte();
            message.Data[170] = reader.ReadByte();
            message.Data[171] = reader.ReadByte();
            message.Data[172] = reader.ReadByte();
            message.Data[173] = reader.ReadByte();
            message.Data[174] = reader.ReadByte();
            message.Data[175] = reader.ReadByte();
            message.Data[176] = reader.ReadByte();
            message.Data[177] = reader.ReadByte();
            message.Data[178] = reader.ReadByte();
            message.Data[179] = reader.ReadByte();
            message.Data[180] = reader.ReadByte();
            message.Data[181] = reader.ReadByte();
            message.Data[182] = reader.ReadByte();
            message.Data[183] = reader.ReadByte();
            message.Data[184] = reader.ReadByte();
            message.Data[185] = reader.ReadByte();
            message.Data[186] = reader.ReadByte();
            message.Data[187] = reader.ReadByte();
            message.Data[188] = reader.ReadByte();
            message.Data[189] = reader.ReadByte();
            message.Data[190] = reader.ReadByte();
            message.Data[191] = reader.ReadByte();
            message.Data[192] = reader.ReadByte();
            message.Data[193] = reader.ReadByte();
            message.Data[194] = reader.ReadByte();
            message.Data[195] = reader.ReadByte();
            message.Data[196] = reader.ReadByte();
            message.Data[197] = reader.ReadByte();
            message.Data[198] = reader.ReadByte();
            message.Data[199] = reader.ReadByte();
            message.Data[200] = reader.ReadByte();
            message.Data[201] = reader.ReadByte();
            message.Data[202] = reader.ReadByte();
            message.Data[203] = reader.ReadByte();
            message.Data[204] = reader.ReadByte();
            message.Data[205] = reader.ReadByte();
            message.Data[206] = reader.ReadByte();
            message.Data[207] = reader.ReadByte();
            message.Data[208] = reader.ReadByte();
            message.Data[209] = reader.ReadByte();
            message.Data[210] = reader.ReadByte();
            message.Data[211] = reader.ReadByte();
            message.Data[212] = reader.ReadByte();
            message.Data[213] = reader.ReadByte();
            message.Data[214] = reader.ReadByte();
            message.Data[215] = reader.ReadByte();
            message.Data[216] = reader.ReadByte();
            message.Data[217] = reader.ReadByte();
            message.Data[218] = reader.ReadByte();
            message.Data[219] = reader.ReadByte();
            message.Data[220] = reader.ReadByte();
            message.Data[221] = reader.ReadByte();
            message.Data[222] = reader.ReadByte();
            message.Data[223] = reader.ReadByte();
            message.Data[224] = reader.ReadByte();
            message.Data[225] = reader.ReadByte();
            message.Data[226] = reader.ReadByte();
            message.Data[227] = reader.ReadByte();
            message.Data[228] = reader.ReadByte();
            message.Data[229] = reader.ReadByte();
            message.Data[230] = reader.ReadByte();
            message.Data[231] = reader.ReadByte();
            message.Data[232] = reader.ReadByte();
            message.Data[233] = reader.ReadByte();
            message.Data[234] = reader.ReadByte();
            message.Data[235] = reader.ReadByte();
            message.Data[236] = reader.ReadByte();
            message.Data[237] = reader.ReadByte();
            message.Data[238] = reader.ReadByte();
            message.Data[239] = reader.ReadByte();
            message.Data[240] = reader.ReadByte();
            message.Data[241] = reader.ReadByte();
            message.Data[242] = reader.ReadByte();
            message.Data[243] = reader.ReadByte();
            message.Data[244] = reader.ReadByte();
            message.Data[245] = reader.ReadByte();
            message.Data[246] = reader.ReadByte();
            message.Data[247] = reader.ReadByte();
            message.Data[248] = reader.ReadByte();
            message.Data[249] = reader.ReadByte();
            message.Data[250] = reader.ReadByte();
            message.Data[251] = reader.ReadByte();
            message.Data[252] = reader.ReadByte();
            return message;
        }
    }
}
