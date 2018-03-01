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
    /// The heartbeat message shows that a system is present and responding. The type of the MAV and Autopilot hardware allow the receiving system to treat further messages from this system appropriate (e.g. by laying out the user interface based on the autopilot).
    /// </summary>
    /// <remarks>
    /// HEARTBEAT
    /// </remarks>
    public class HeartbeatMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Type of the MAV (quadrotor, helicopter, etc., up to 15 types, defined in MAV_TYPE ENUM)
        /// </summary>
        /// <remarks>
        /// type
        /// </remarks>
        private Type _type;
        
        /// <summary>
        /// Autopilot type / class. defined in MAV_AUTOPILOT ENUM
        /// </summary>
        /// <remarks>
        /// autopilot
        /// </remarks>
        private Autopilot _autopilot;
        
        /// <summary>
        /// System mode bitfield, see MAV_MODE_FLAG ENUM in mavlink/include/mavlink_types.h
        /// </summary>
        /// <remarks>
        /// base_mode
        /// </remarks>
        private ModeFlag _baseMode;
        
        /// <summary>
        /// A bitfield for use for autopilot-specific flags.
        /// </summary>
        /// <remarks>
        /// custom_mode
        /// </remarks>
        private uint _customMode;
        
        /// <summary>
        /// System status flag, see MAV_STATE ENUM
        /// </summary>
        /// <remarks>
        /// system_status
        /// </remarks>
        private State _systemStatus;
        
        /// <summary>
        /// MAVLink version, not writable by user, gets added by protocol because of magic data type: uint8_t_mavlink_version
        /// </summary>
        /// <remarks>
        /// mavlink_version
        /// </remarks>
        private byte _mavlinkVersion;
        
        public HeartbeatMessage() : 
                base(MavLink4Net.Messages.MavMessageType.Heartbeat, 50)
        {
        }
        
        /// <summary>
        /// Type of the MAV (quadrotor, helicopter, etc., up to 15 types, defined in MAV_TYPE ENUM)
        /// </summary>
        public Type Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
        
        /// <summary>
        /// Autopilot type / class. defined in MAV_AUTOPILOT ENUM
        /// </summary>
        public Autopilot Autopilot
        {
            get
            {
                return this._autopilot;
            }
            set
            {
                this._autopilot = value;
            }
        }
        
        /// <summary>
        /// System mode bitfield, see MAV_MODE_FLAG ENUM in mavlink/include/mavlink_types.h
        /// </summary>
        public ModeFlag BaseMode
        {
            get
            {
                return this._baseMode;
            }
            set
            {
                this._baseMode = value;
            }
        }
        
        /// <summary>
        /// A bitfield for use for autopilot-specific flags.
        /// </summary>
        public uint CustomMode
        {
            get
            {
                return this._customMode;
            }
            set
            {
                this._customMode = value;
            }
        }
        
        /// <summary>
        /// System status flag, see MAV_STATE ENUM
        /// </summary>
        public State SystemStatus
        {
            get
            {
                return this._systemStatus;
            }
            set
            {
                this._systemStatus = value;
            }
        }
        
        /// <summary>
        /// MAVLink version, not writable by user, gets added by protocol because of magic data type: uint8_t_mavlink_version
        /// </summary>
        public byte MavlinkVersion
        {
            get
            {
                return this._mavlinkVersion;
            }
            set
            {
                this._mavlinkVersion = value;
            }
        }
    }
}
