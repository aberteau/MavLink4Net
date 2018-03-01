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
    /// Once the MAV sets a new GPS-Local correspondence, this message announces the origin (0,0,0) position
    /// </summary>
    /// <remarks>
    /// GPS_GLOBAL_ORIGIN
    /// </remarks>
    public class GpsGlobalOriginMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Latitude (WGS84), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// latitude
        /// </remarks>
        private int _latitude;
        
        /// <summary>
        /// Longitude (WGS84), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// longitude
        /// </remarks>
        private int _longitude;
        
        /// <summary>
        /// Altitude (AMSL), in meters * 1000 (positive for up)
        /// </summary>
        /// <remarks>
        /// altitude
        /// </remarks>
        private int _altitude;
        
        /// <summary>
        /// Timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        /// <remarks>
        /// time_usec
        /// </remarks>
        private ulong _timeUsec;
        
        public GpsGlobalOriginMessage() : 
                base(MavLink4Net.Messages.MavMessageType.GpsGlobalOrigin, 95)
        {
        }
        
        /// <summary>
        /// Latitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Latitude
        {
            get
            {
                return this._latitude;
            }
            set
            {
                this._latitude = value;
            }
        }
        
        /// <summary>
        /// Longitude (WGS84), in degrees * 1E7
        /// </summary>
        public int Longitude
        {
            get
            {
                return this._longitude;
            }
            set
            {
                this._longitude = value;
            }
        }
        
        /// <summary>
        /// Altitude (AMSL), in meters * 1000 (positive for up)
        /// </summary>
        public int Altitude
        {
            get
            {
                return this._altitude;
            }
            set
            {
                this._altitude = value;
            }
        }
        
        /// <summary>
        /// Timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        public ulong TimeUsec
        {
            get
            {
                return this._timeUsec;
            }
            set
            {
                this._timeUsec = value;
            }
        }
    }
}
