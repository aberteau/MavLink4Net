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
    /// current motion information from a designated system
    /// </summary>
    /// <remarks>
    /// FOLLOW_TARGET
    /// </remarks>
    public class FollowTargetMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp in milliseconds since system boot
        /// </summary>
        /// <remarks>
        /// timestamp
        /// </remarks>
        private ulong _timestamp;
        
        /// <summary>
        /// bit positions for tracker reporting capabilities (POS = 0, VEL = 1, ACCEL = 2, ATT + RATES = 3)
        /// </summary>
        /// <remarks>
        /// est_capabilities
        /// </remarks>
        private byte _estCapabilities;
        
        /// <summary>
        /// Latitude (WGS84), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// lat
        /// </remarks>
        private int _lat;
        
        /// <summary>
        /// Longitude (WGS84), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// lon
        /// </remarks>
        private int _lon;
        
        /// <summary>
        /// AMSL, in meters
        /// </summary>
        /// <remarks>
        /// alt
        /// </remarks>
        private float _alt;
        
        /// <summary>
        /// target velocity (0,0,0) for unknown
        /// </summary>
        /// <remarks>
        /// vel
        /// </remarks>
        private float[] _vel = new float[3];
        
        /// <summary>
        /// linear target acceleration (0,0,0) for unknown
        /// </summary>
        /// <remarks>
        /// acc
        /// </remarks>
        private float[] _acc = new float[3];
        
        /// <summary>
        /// (1 0 0 0 for unknown)
        /// </summary>
        /// <remarks>
        /// attitude_q
        /// </remarks>
        private float[] _attitudeQ = new float[4];
        
        /// <summary>
        /// (0 0 0 for unknown)
        /// </summary>
        /// <remarks>
        /// rates
        /// </remarks>
        private float[] _rates = new float[3];
        
        /// <summary>
        /// eph epv
        /// </summary>
        /// <remarks>
        /// position_cov
        /// </remarks>
        private float[] _positionCov = new float[3];
        
        /// <summary>
        /// button states or switches of a tracker device
        /// </summary>
        /// <remarks>
        /// custom_state
        /// </remarks>
        private ulong _customState;
        
        public FollowTargetMessage() : 
                base(MavLink4Net.Messages.MavMessageType.FollowTarget, 127)
        {
        }
        
        /// <summary>
        /// Timestamp in milliseconds since system boot
        /// </summary>
        public ulong Timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                this._timestamp = value;
            }
        }
        
        /// <summary>
        /// bit positions for tracker reporting capabilities (POS = 0, VEL = 1, ACCEL = 2, ATT + RATES = 3)
        /// </summary>
        public byte EstCapabilities
        {
            get
            {
                return this._estCapabilities;
            }
            set
            {
                this._estCapabilities = value;
            }
        }
        
        /// <summary>
        /// Latitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Lat
        {
            get
            {
                return this._lat;
            }
            set
            {
                this._lat = value;
            }
        }
        
        /// <summary>
        /// Longitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Lon
        {
            get
            {
                return this._lon;
            }
            set
            {
                this._lon = value;
            }
        }
        
        /// <summary>
        /// AMSL, in meters
        /// </summary>
        public float Alt
        {
            get
            {
                return this._alt;
            }
            set
            {
                this._alt = value;
            }
        }
        
        /// <summary>
        /// target velocity (0,0,0) for unknown
        /// </summary>
        public float[] Vel
        {
            get
            {
                return this._vel;
            }
            set
            {
                this._vel = value;
            }
        }
        
        /// <summary>
        /// linear target acceleration (0,0,0) for unknown
        /// </summary>
        public float[] Acc
        {
            get
            {
                return this._acc;
            }
            set
            {
                this._acc = value;
            }
        }
        
        /// <summary>
        /// (1 0 0 0 for unknown)
        /// </summary>
        public float[] AttitudeQ
        {
            get
            {
                return this._attitudeQ;
            }
            set
            {
                this._attitudeQ = value;
            }
        }
        
        /// <summary>
        /// (0 0 0 for unknown)
        /// </summary>
        public float[] Rates
        {
            get
            {
                return this._rates;
            }
            set
            {
                this._rates = value;
            }
        }
        
        /// <summary>
        /// eph epv
        /// </summary>
        public float[] PositionCov
        {
            get
            {
                return this._positionCov;
            }
            set
            {
                this._positionCov = value;
            }
        }
        
        /// <summary>
        /// button states or switches of a tracker device
        /// </summary>
        public ulong CustomState
        {
            get
            {
                return this._customState;
            }
            set
            {
                this._customState = value;
            }
        }
    }
}
