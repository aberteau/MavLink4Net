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
    /// Barometer readings for 3rd barometer
    /// </summary>
    /// <remarks>
    /// SCALED_PRESSURE3
    /// </remarks>
    public class ScaledPressure3Message : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (milliseconds since system boot)
        /// </summary>
        /// <remarks>
        /// time_boot_ms
        /// </remarks>
        private uint _timeBootMs;
        
        /// <summary>
        /// Absolute pressure (hectopascal)
        /// </summary>
        /// <remarks>
        /// press_abs
        /// </remarks>
        private float _pressAbs;
        
        /// <summary>
        /// Differential pressure 1 (hectopascal)
        /// </summary>
        /// <remarks>
        /// press_diff
        /// </remarks>
        private float _pressDiff;
        
        /// <summary>
        /// Temperature measurement (0.01 degrees celsius)
        /// </summary>
        /// <remarks>
        /// temperature
        /// </remarks>
        private short _temperature;
        
        public ScaledPressure3Message() : 
                base(MavLink4Net.Messages.MavMessageType.ScaledPressure3, 131)
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
        /// Absolute pressure (hectopascal)
        /// </summary>
        public float PressAbs
        {
            get
            {
                return this._pressAbs;
            }
            set
            {
                this._pressAbs = value;
            }
        }
        
        /// <summary>
        /// Differential pressure 1 (hectopascal)
        /// </summary>
        public float PressDiff
        {
            get
            {
                return this._pressDiff;
            }
            set
            {
                this._pressDiff = value;
            }
        }
        
        /// <summary>
        /// Temperature measurement (0.01 degrees celsius)
        /// </summary>
        public short Temperature
        {
            get
            {
                return this._temperature;
            }
            set
            {
                this._temperature = value;
            }
        }
    }
}
