namespace MavLink4Net.MessageDefinitions.Tests.Data
{
    class MessageInfo
    {
        public uint MsgId { get; set; }
        public string Name { get; set; }
        public byte Crc { get; set; }
        public uint Minlength { get; set; }
        public uint Length { get; set; }

        public MessageInfo(uint msgid, string name, byte crc, uint minlength, uint length)
        {
            this.MsgId = msgid;
            this.Name = name;
            this.Crc = crc;
            this.Minlength = minlength;
            this.Length = length;
        }
    }
}
