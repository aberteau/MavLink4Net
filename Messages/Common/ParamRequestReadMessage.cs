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
    /// Request to read the onboard parameter with the param_id string id. Onboard parameters are stored as key[const char*] -> value[float]. This allows to send a parameter to any other component (such as the GCS) without the need of previous knowledge of possible parameter names. Thus the same GCS can store different parameters for different autopilots. See also https://mavlink.io/en/protocol/parameter.html for a full documentation of QGroundControl and IMU code.
    /// </summary>
    /// <remarks>
    /// PARAM_REQUEST_READ
    /// </remarks>
    public class ParamRequestReadMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// System ID
        /// </summary>
        /// <remarks>
        /// target_system
        /// </remarks>
        private byte _targetSystem;
        
        /// <summary>
        /// Component ID
        /// </summary>
        /// <remarks>
        /// target_component
        /// </remarks>
        private byte _targetComponent;
        
        /// <summary>
        /// Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        /// <remarks>
        /// param_id
        /// </remarks>
        private char[] _paramId = new char[16];
        
        /// <summary>
        /// Parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)
        /// </summary>
        /// <remarks>
        /// param_index
        /// </remarks>
        private short _paramIndex;
        
        public ParamRequestReadMessage() : 
                base(MavLink4Net.Messages.MavMessageType.ParamRequestRead, 214)
        {
        }
        
        /// <summary>
        /// System ID
        /// </summary>
        public byte TargetSystem
        {
            get
            {
                return this._targetSystem;
            }
            set
            {
                this._targetSystem = value;
            }
        }
        
        /// <summary>
        /// Component ID
        /// </summary>
        public byte TargetComponent
        {
            get
            {
                return this._targetComponent;
            }
            set
            {
                this._targetComponent = value;
            }
        }
        
        /// <summary>
        /// Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string
        /// </summary>
        public char[] ParamId
        {
            get
            {
                return this._paramId;
            }
            set
            {
                this._paramId = value;
            }
        }
        
        /// <summary>
        /// Parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)
        /// </summary>
        public short ParamIndex
        {
            get
            {
                return this._paramIndex;
            }
            set
            {
                this._paramIndex = value;
            }
        }
    }
}