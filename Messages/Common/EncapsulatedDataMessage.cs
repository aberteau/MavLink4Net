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


namespace MavLink4Net.Messages.Common
{
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// ENCAPSULATED_DATA
    /// </remarks>
    public class EncapsulatedDataMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// sequence number (starting with 0 on every transmission)
        /// </summary>
        /// <remarks>
        /// seqnr
        /// </remarks>
        private ushort _seqnr;
        
        /// <summary>
        /// image data bytes
        /// </summary>
        /// <remarks>
        /// data
        /// </remarks>
        private byte[] _data = new byte[253];
        
        public EncapsulatedDataMessage() : 
                base(MavLink4Net.Messages.MavMessageType.EncapsulatedData, 223)
        {
        }
        
        /// <summary>
        /// sequence number (starting with 0 on every transmission)
        /// </summary>
        public ushort Seqnr
        {
            get
            {
                return this._seqnr;
            }
            set
            {
                this._seqnr = value;
            }
        }
        
        /// <summary>
        /// image data bytes
        /// </summary>
        public byte[] Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }
    }
}
