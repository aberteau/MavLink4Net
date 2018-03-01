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
    /// Request the information of the mission item with the sequence number seq. The response of the system to this message should be a MISSION_ITEM message. https://mavlink.io/en/protocol/mission.html
    /// </summary>
    /// <remarks>
    /// MISSION_REQUEST
    /// </remarks>
    public class MissionRequestMessage : MavLink4Net.Messages.Message
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
        /// Sequence
        /// </summary>
        /// <remarks>
        /// seq
        /// </remarks>
        private ushort _seq;
        
        /// <summary>
        /// Mission type, see MAV_MISSION_TYPE
        /// </summary>
        /// <remarks>
        /// mission_type
        /// </remarks>
        private MissionType _missionType;
        
        public MissionRequestMessage() : 
                base(MavLink4Net.Messages.MavMessageType.MissionRequest, 177)
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
        /// Sequence
        /// </summary>
        public ushort Seq
        {
            get
            {
                return this._seq;
            }
            set
            {
                this._seq = value;
            }
        }
        
        /// <summary>
        /// Mission type, see MAV_MISSION_TYPE
        /// </summary>
        public MissionType MissionType
        {
            get
            {
                return this._missionType;
            }
            set
            {
                this._missionType = value;
            }
        }
    }
}
