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
    /// The RAW IMU readings for 3rd 9DOF sensor setup. This message should contain the scaled values to the described units
    /// </summary>
    /// <remarks>
    /// SCALED_IMU3
    /// </remarks>
    public class ScaledImu3Message : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        /// <remarks>
        /// time_boot_ms
        /// </remarks>
        private uint _timeBootMs;
        
        /// <summary>
        /// X acceleration (mg)
        /// </summary>
        /// <remarks>
        /// xacc
        /// </remarks>
        private short _xacc;
        
        /// <summary>
        /// Y acceleration (mg)
        /// </summary>
        /// <remarks>
        /// yacc
        /// </remarks>
        private short _yacc;
        
        /// <summary>
        /// Z acceleration (mg)
        /// </summary>
        /// <remarks>
        /// zacc
        /// </remarks>
        private short _zacc;
        
        /// <summary>
        /// Angular speed around X axis (millirad /sec)
        /// </summary>
        /// <remarks>
        /// xgyro
        /// </remarks>
        private short _xgyro;
        
        /// <summary>
        /// Angular speed around Y axis (millirad /sec)
        /// </summary>
        /// <remarks>
        /// ygyro
        /// </remarks>
        private short _ygyro;
        
        /// <summary>
        /// Angular speed around Z axis (millirad /sec)
        /// </summary>
        /// <remarks>
        /// zgyro
        /// </remarks>
        private short _zgyro;
        
        /// <summary>
        /// X Magnetic field (milli tesla)
        /// </summary>
        /// <remarks>
        /// xmag
        /// </remarks>
        private short _xmag;
        
        /// <summary>
        /// Y Magnetic field (milli tesla)
        /// </summary>
        /// <remarks>
        /// ymag
        /// </remarks>
        private short _ymag;
        
        /// <summary>
        /// Z Magnetic field (milli tesla)
        /// </summary>
        /// <remarks>
        /// zmag
        /// </remarks>
        private short _zmag;
        
        public ScaledImu3Message() : 
                base(MavLink4Net.Messages.MavMessageType.ScaledImu3, 46)
        {
        }
        
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        public uint TimeBootMs
        {
            get
            {
                return this._timeBootMs;
            }
            set
            {
                this._timeBootMs = value;
            }
        }
        
        /// <summary>
        /// X acceleration (mg)
        /// </summary>
        public short Xacc
        {
            get
            {
                return this._xacc;
            }
            set
            {
                this._xacc = value;
            }
        }
        
        /// <summary>
        /// Y acceleration (mg)
        /// </summary>
        public short Yacc
        {
            get
            {
                return this._yacc;
            }
            set
            {
                this._yacc = value;
            }
        }
        
        /// <summary>
        /// Z acceleration (mg)
        /// </summary>
        public short Zacc
        {
            get
            {
                return this._zacc;
            }
            set
            {
                this._zacc = value;
            }
        }
        
        /// <summary>
        /// Angular speed around X axis (millirad /sec)
        /// </summary>
        public short Xgyro
        {
            get
            {
                return this._xgyro;
            }
            set
            {
                this._xgyro = value;
            }
        }
        
        /// <summary>
        /// Angular speed around Y axis (millirad /sec)
        /// </summary>
        public short Ygyro
        {
            get
            {
                return this._ygyro;
            }
            set
            {
                this._ygyro = value;
            }
        }
        
        /// <summary>
        /// Angular speed around Z axis (millirad /sec)
        /// </summary>
        public short Zgyro
        {
            get
            {
                return this._zgyro;
            }
            set
            {
                this._zgyro = value;
            }
        }
        
        /// <summary>
        /// X Magnetic field (milli tesla)
        /// </summary>
        public short Xmag
        {
            get
            {
                return this._xmag;
            }
            set
            {
                this._xmag = value;
            }
        }
        
        /// <summary>
        /// Y Magnetic field (milli tesla)
        /// </summary>
        public short Ymag
        {
            get
            {
                return this._ymag;
            }
            set
            {
                this._ymag = value;
            }
        }
        
        /// <summary>
        /// Z Magnetic field (milli tesla)
        /// </summary>
        public short Zmag
        {
            get
            {
                return this._zmag;
            }
            set
            {
                this._zmag = value;
            }
        }
    }
}
