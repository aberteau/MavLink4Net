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
    /// The global position, as returned by the Global Positioning System (GPS). This is
    ///                NOT the global position estimate of the system, but rather a RAW sensor value. See message GLOBAL_POSITION for the global position estimate. Coordinate frame is right-handed, Z-axis up (GPS frame).
    /// </summary>
    /// <remarks>
    /// GPS_RAW_INT
    /// </remarks>
    public class GpsRawIntMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (microseconds since UNIX epoch or microseconds since system boot)
        /// </summary>
        /// <remarks>
        /// time_usec
        /// </remarks>
        private ulong _timeUsec;
        
        /// <summary>
        /// See the GPS_FIX_TYPE enum.
        /// </summary>
        /// <remarks>
        /// fix_type
        /// </remarks>
        private GpsFixType _fixType;
        
        /// <summary>
        /// Latitude (WGS84, EGM96 ellipsoid), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// lat
        /// </remarks>
        private int _lat;
        
        /// <summary>
        /// Longitude (WGS84, EGM96 ellipsoid), in degrees * 1E7
        /// </summary>
        /// <remarks>
        /// lon
        /// </remarks>
        private int _lon;
        
        /// <summary>
        /// Altitude (AMSL, NOT WGS84), in meters * 1000 (positive for up). Note that virtually all GPS modules provide the AMSL altitude in addition to the WGS84 altitude.
        /// </summary>
        /// <remarks>
        /// alt
        /// </remarks>
        private int _alt;
        
        /// <summary>
        /// GPS HDOP horizontal dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        /// <remarks>
        /// eph
        /// </remarks>
        private ushort _eph;
        
        /// <summary>
        /// GPS VDOP vertical dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        /// <remarks>
        /// epv
        /// </remarks>
        private ushort _epv;
        
        /// <summary>
        /// GPS ground speed (m/s * 100). If unknown, set to: UINT16_MAX
        /// </summary>
        /// <remarks>
        /// vel
        /// </remarks>
        private ushort _vel;
        
        /// <summary>
        /// Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX
        /// </summary>
        /// <remarks>
        /// cog
        /// </remarks>
        private ushort _cog;
        
        /// <summary>
        /// Number of satellites visible. If unknown, set to 255
        /// </summary>
        /// <remarks>
        /// satellites_visible
        /// </remarks>
        private byte _satellitesVisible;
        
        /// <summary>
        /// Altitude (above WGS84, EGM96 ellipsoid), in meters * 1000 (positive for up).
        /// </summary>
        /// <remarks>
        /// alt_ellipsoid
        /// </remarks>
        private int _altEllipsoid;
        
        /// <summary>
        /// Position uncertainty in meters * 1000 (positive for up).
        /// </summary>
        /// <remarks>
        /// h_acc
        /// </remarks>
        private uint _hAcc;
        
        /// <summary>
        /// Altitude uncertainty in meters * 1000 (positive for up).
        /// </summary>
        /// <remarks>
        /// v_acc
        /// </remarks>
        private uint _vAcc;
        
        /// <summary>
        /// Speed uncertainty in meters * 1000 (positive for up).
        /// </summary>
        /// <remarks>
        /// vel_acc
        /// </remarks>
        private uint _velAcc;
        
        /// <summary>
        /// Heading / track uncertainty in degrees * 1e5.
        /// </summary>
        /// <remarks>
        /// hdg_acc
        /// </remarks>
        private uint _hdgAcc;
        
        public GpsRawIntMessage() : 
                base(MavLink4Net.Messages.MavMessageType.GpsRawInt, 111)
        {
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
        
        /// <summary>
        /// See the GPS_FIX_TYPE enum.
        /// </summary>
        public GpsFixType FixType
        {
            get
            {
                return this._fixType;
            }
            set
            {
                this._fixType = value;
            }
        }
        
        /// <summary>
        /// Latitude (WGS84, EGM96 ellipsoid), in degrees * 1E7
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
        /// Longitude (WGS84, EGM96 ellipsoid), in degrees * 1E7
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
        /// Altitude (AMSL, NOT WGS84), in meters * 1000 (positive for up). Note that virtually all GPS modules provide the AMSL altitude in addition to the WGS84 altitude.
        /// </summary>
        public int Alt
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
        /// GPS HDOP horizontal dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Eph
        {
            get
            {
                return this._eph;
            }
            set
            {
                this._eph = value;
            }
        }
        
        /// <summary>
        /// GPS VDOP vertical dilution of position (unitless). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Epv
        {
            get
            {
                return this._epv;
            }
            set
            {
                this._epv = value;
            }
        }
        
        /// <summary>
        /// GPS ground speed (m/s * 100). If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Vel
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
        /// Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX
        /// </summary>
        public ushort Cog
        {
            get
            {
                return this._cog;
            }
            set
            {
                this._cog = value;
            }
        }
        
        /// <summary>
        /// Number of satellites visible. If unknown, set to 255
        /// </summary>
        public byte SatellitesVisible
        {
            get
            {
                return this._satellitesVisible;
            }
            set
            {
                this._satellitesVisible = value;
            }
        }
        
        /// <summary>
        /// Altitude (above WGS84, EGM96 ellipsoid), in meters * 1000 (positive for up).
        /// </summary>
        public int AltEllipsoid
        {
            get
            {
                return this._altEllipsoid;
            }
            set
            {
                this._altEllipsoid = value;
            }
        }
        
        /// <summary>
        /// Position uncertainty in meters * 1000 (positive for up).
        /// </summary>
        public uint HAcc
        {
            get
            {
                return this._hAcc;
            }
            set
            {
                this._hAcc = value;
            }
        }
        
        /// <summary>
        /// Altitude uncertainty in meters * 1000 (positive for up).
        /// </summary>
        public uint VAcc
        {
            get
            {
                return this._vAcc;
            }
            set
            {
                this._vAcc = value;
            }
        }
        
        /// <summary>
        /// Speed uncertainty in meters * 1000 (positive for up).
        /// </summary>
        public uint VelAcc
        {
            get
            {
                return this._velAcc;
            }
            set
            {
                this._velAcc = value;
            }
        }
        
        /// <summary>
        /// Heading / track uncertainty in degrees * 1e5.
        /// </summary>
        public uint HdgAcc
        {
            get
            {
                return this._hdgAcc;
            }
            set
            {
                this._hdgAcc = value;
            }
        }
    }
}
