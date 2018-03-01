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
    /// Request the overall list of mission items from the system/component.
    /// </summary>
    /// <remarks>
    /// MISSION_REQUEST_LIST
    /// </remarks>
    public class MissionRequestListMessage : MavLink4Net.Messages.Message
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
        /// Mission type, see MAV_MISSION_TYPE
        /// </summary>
        /// <remarks>
        /// mission_type
        /// </remarks>
        private MissionType _missionType;
        
        public MissionRequestListMessage() : 
                base(MavLink4Net.Messages.MavMessageType.MissionRequestList, 148)
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
