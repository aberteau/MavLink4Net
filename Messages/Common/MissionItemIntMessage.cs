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
    /// Message encoding a mission item. This message is emitted to announce
    ///                the presence of a mission item and to set a mission item on the system. The mission item can be either in x, y, z meters (type: LOCAL) or x:lat, y:lon, z:altitude. Local frame is Z-down, right handed (NED), global frame is Z-up, right handed (ENU). See also https://mavlink.io/en/protocol/mission.html.
    /// </summary>
    /// <remarks>
    /// MISSION_ITEM_INT
    /// </remarks>
    public class MissionItemIntMessage : MavLink4Net.Messages.Message
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
        /// Waypoint ID (sequence number). Starts at zero. Increases monotonically for each waypoint, no gaps in the sequence (0,1,2,3,4).
        /// </summary>
        /// <remarks>
        /// seq
        /// </remarks>
        private ushort _seq;
        
        /// <summary>
        /// The coordinate system of the waypoint. see MAV_FRAME in mavlink_types.h
        /// </summary>
        /// <remarks>
        /// frame
        /// </remarks>
        private Frame _frame;
        
        /// <summary>
        /// The scheduled action for the waypoint. see MAV_CMD in common.xml MAVLink specs
        /// </summary>
        /// <remarks>
        /// command
        /// </remarks>
        private Cmd _command;
        
        /// <summary>
        /// false:0, true:1
        /// </summary>
        /// <remarks>
        /// current
        /// </remarks>
        private byte _current;
        
        /// <summary>
        /// autocontinue to next wp
        /// </summary>
        /// <remarks>
        /// autocontinue
        /// </remarks>
        private byte _autocontinue;
        
        /// <summary>
        /// PARAM1, see MAV_CMD enum
        /// </summary>
        /// <remarks>
        /// param1
        /// </remarks>
        private float _param1;
        
        /// <summary>
        /// PARAM2, see MAV_CMD enum
        /// </summary>
        /// <remarks>
        /// param2
        /// </remarks>
        private float _param2;
        
        /// <summary>
        /// PARAM3, see MAV_CMD enum
        /// </summary>
        /// <remarks>
        /// param3
        /// </remarks>
        private float _param3;
        
        /// <summary>
        /// PARAM4, see MAV_CMD enum
        /// </summary>
        /// <remarks>
        /// param4
        /// </remarks>
        private float _param4;
        
        /// <summary>
        /// PARAM5 / local: x position in meters * 1e4, global: latitude in degrees * 10^7
        /// </summary>
        /// <remarks>
        /// x
        /// </remarks>
        private int _x;
        
        /// <summary>
        /// PARAM6 / y position: local: x position in meters * 1e4, global: longitude in degrees *10^7
        /// </summary>
        /// <remarks>
        /// y
        /// </remarks>
        private int _y;
        
        /// <summary>
        /// PARAM7 / z position: global: altitude in meters (relative or absolute, depending on frame.
        /// </summary>
        /// <remarks>
        /// z
        /// </remarks>
        private float _z;
        
        /// <summary>
        /// Mission type, see MAV_MISSION_TYPE
        /// </summary>
        /// <remarks>
        /// mission_type
        /// </remarks>
        private MissionType _missionType;
        
        public MissionItemIntMessage() : 
                base(MavLink4Net.Messages.MavMessageType.MissionItemInt, 209)
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
        /// Waypoint ID (sequence number). Starts at zero. Increases monotonically for each waypoint, no gaps in the sequence (0,1,2,3,4).
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
        /// The coordinate system of the waypoint. see MAV_FRAME in mavlink_types.h
        /// </summary>
        public Frame Frame
        {
            get
            {
                return this._frame;
            }
            set
            {
                this._frame = value;
            }
        }
        
        /// <summary>
        /// The scheduled action for the waypoint. see MAV_CMD in common.xml MAVLink specs
        /// </summary>
        public Cmd Command
        {
            get
            {
                return this._command;
            }
            set
            {
                this._command = value;
            }
        }
        
        /// <summary>
        /// false:0, true:1
        /// </summary>
        public byte Current
        {
            get
            {
                return this._current;
            }
            set
            {
                this._current = value;
            }
        }
        
        /// <summary>
        /// autocontinue to next wp
        /// </summary>
        public byte Autocontinue
        {
            get
            {
                return this._autocontinue;
            }
            set
            {
                this._autocontinue = value;
            }
        }
        
        /// <summary>
        /// PARAM1, see MAV_CMD enum
        /// </summary>
        public float Param1
        {
            get
            {
                return this._param1;
            }
            set
            {
                this._param1 = value;
            }
        }
        
        /// <summary>
        /// PARAM2, see MAV_CMD enum
        /// </summary>
        public float Param2
        {
            get
            {
                return this._param2;
            }
            set
            {
                this._param2 = value;
            }
        }
        
        /// <summary>
        /// PARAM3, see MAV_CMD enum
        /// </summary>
        public float Param3
        {
            get
            {
                return this._param3;
            }
            set
            {
                this._param3 = value;
            }
        }
        
        /// <summary>
        /// PARAM4, see MAV_CMD enum
        /// </summary>
        public float Param4
        {
            get
            {
                return this._param4;
            }
            set
            {
                this._param4 = value;
            }
        }
        
        /// <summary>
        /// PARAM5 / local: x position in meters * 1e4, global: latitude in degrees * 10^7
        /// </summary>
        public int X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
        
        /// <summary>
        /// PARAM6 / y position: local: x position in meters * 1e4, global: longitude in degrees *10^7
        /// </summary>
        public int Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }
        
        /// <summary>
        /// PARAM7 / z position: global: altitude in meters (relative or absolute, depending on frame.
        /// </summary>
        public float Z
        {
            get
            {
                return this._z;
            }
            set
            {
                this._z = value;
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
