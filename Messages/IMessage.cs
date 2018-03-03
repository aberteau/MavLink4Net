using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.Messages
{
    public interface IMessage
    {
        MavMessageType MavType { get; }
        byte CrcExtra { get; }
    }
}
