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
    /// Status of simulation environment, if used
    /// </summary>
    /// <remarks>
    /// SIM_STATE
    /// </remarks>
    public class SimStateMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// True attitude quaternion component 1, w (1 in null-rotation)
        /// </summary>
        /// <remarks>
        /// q1
        /// </remarks>
        private float _q1;
        
        /// <summary>
        /// True attitude quaternion component 2, x (0 in null-rotation)
        /// </summary>
        /// <remarks>
        /// q2
        /// </remarks>
        private float _q2;
        
        /// <summary>
        /// True attitude quaternion component 3, y (0 in null-rotation)
        /// </summary>
        /// <remarks>
        /// q3
        /// </remarks>
        private float _q3;
        
        /// <summary>
        /// True attitude quaternion component 4, z (0 in null-rotation)
        /// </summary>
        /// <remarks>
        /// q4
        /// </remarks>
        private float _q4;
        
        /// <summary>
        /// Attitude roll expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        /// <remarks>
        /// roll
        /// </remarks>
        private float _roll;
        
        /// <summary>
        /// Attitude pitch expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        /// <remarks>
        /// pitch
        /// </remarks>
        private float _pitch;
        
        /// <summary>
        /// Attitude yaw expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        /// <remarks>
        /// yaw
        /// </remarks>
        private float _yaw;
        
        /// <summary>
        /// X acceleration m/s/s
        /// </summary>
        /// <remarks>
        /// xacc
        /// </remarks>
        private float _xacc;
        
        /// <summary>
        /// Y acceleration m/s/s
        /// </summary>
        /// <remarks>
        /// yacc
        /// </remarks>
        private float _yacc;
        
        /// <summary>
        /// Z acceleration m/s/s
        /// </summary>
        /// <remarks>
        /// zacc
        /// </remarks>
        private float _zacc;
        
        /// <summary>
        /// Angular speed around X axis rad/s
        /// </summary>
        /// <remarks>
        /// xgyro
        /// </remarks>
        private float _xgyro;
        
        /// <summary>
        /// Angular speed around Y axis rad/s
        /// </summary>
        /// <remarks>
        /// ygyro
        /// </remarks>
        private float _ygyro;
        
        /// <summary>
        /// Angular speed around Z axis rad/s
        /// </summary>
        /// <remarks>
        /// zgyro
        /// </remarks>
        private float _zgyro;
        
        /// <summary>
        /// Latitude in degrees
        /// </summary>
        /// <remarks>
        /// lat
        /// </remarks>
        private float _lat;
        
        /// <summary>
        /// Longitude in degrees
        /// </summary>
        /// <remarks>
        /// lon
        /// </remarks>
        private float _lon;
        
        /// <summary>
        /// Altitude in meters
        /// </summary>
        /// <remarks>
        /// alt
        /// </remarks>
        private float _alt;
        
        /// <summary>
        /// Horizontal position standard deviation
        /// </summary>
        /// <remarks>
        /// std_dev_horz
        /// </remarks>
        private float _stdDevHorz;
        
        /// <summary>
        /// Vertical position standard deviation
        /// </summary>
        /// <remarks>
        /// std_dev_vert
        /// </remarks>
        private float _stdDevVert;
        
        /// <summary>
        /// True velocity in m/s in NORTH direction in earth-fixed NED frame
        /// </summary>
        /// <remarks>
        /// vn
        /// </remarks>
        private float _vn;
        
        /// <summary>
        /// True velocity in m/s in EAST direction in earth-fixed NED frame
        /// </summary>
        /// <remarks>
        /// ve
        /// </remarks>
        private float _ve;
        
        /// <summary>
        /// True velocity in m/s in DOWN direction in earth-fixed NED frame
        /// </summary>
        /// <remarks>
        /// vd
        /// </remarks>
        private float _vd;
        
        public SimStateMessage() : 
                base(MavLink4Net.Messages.MavMessageType.SimState, 32)
        {
        }
        
        /// <summary>
        /// True attitude quaternion component 1, w (1 in null-rotation)
        /// </summary>
        public float Q1
        {
            get
            {
                return this._q1;
            }
            set
            {
                this._q1 = value;
            }
        }
        
        /// <summary>
        /// True attitude quaternion component 2, x (0 in null-rotation)
        /// </summary>
        public float Q2
        {
            get
            {
                return this._q2;
            }
            set
            {
                this._q2 = value;
            }
        }
        
        /// <summary>
        /// True attitude quaternion component 3, y (0 in null-rotation)
        /// </summary>
        public float Q3
        {
            get
            {
                return this._q3;
            }
            set
            {
                this._q3 = value;
            }
        }
        
        /// <summary>
        /// True attitude quaternion component 4, z (0 in null-rotation)
        /// </summary>
        public float Q4
        {
            get
            {
                return this._q4;
            }
            set
            {
                this._q4 = value;
            }
        }
        
        /// <summary>
        /// Attitude roll expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        public float Roll
        {
            get
            {
                return this._roll;
            }
            set
            {
                this._roll = value;
            }
        }
        
        /// <summary>
        /// Attitude pitch expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        public float Pitch
        {
            get
            {
                return this._pitch;
            }
            set
            {
                this._pitch = value;
            }
        }
        
        /// <summary>
        /// Attitude yaw expressed as Euler angles, not recommended except for human-readable outputs
        /// </summary>
        public float Yaw
        {
            get
            {
                return this._yaw;
            }
            set
            {
                this._yaw = value;
            }
        }
        
        /// <summary>
        /// X acceleration m/s/s
        /// </summary>
        public float Xacc
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
        /// Y acceleration m/s/s
        /// </summary>
        public float Yacc
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
        /// Z acceleration m/s/s
        /// </summary>
        public float Zacc
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
        /// Angular speed around X axis rad/s
        /// </summary>
        public float Xgyro
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
        /// Angular speed around Y axis rad/s
        /// </summary>
        public float Ygyro
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
        /// Angular speed around Z axis rad/s
        /// </summary>
        public float Zgyro
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
        /// Latitude in degrees
        /// </summary>
        public float Lat
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
        /// Longitude in degrees
        /// </summary>
        public float Lon
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
        /// Altitude in meters
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
        /// Horizontal position standard deviation
        /// </summary>
        public float StdDevHorz
        {
            get
            {
                return this._stdDevHorz;
            }
            set
            {
                this._stdDevHorz = value;
            }
        }
        
        /// <summary>
        /// Vertical position standard deviation
        /// </summary>
        public float StdDevVert
        {
            get
            {
                return this._stdDevVert;
            }
            set
            {
                this._stdDevVert = value;
            }
        }
        
        /// <summary>
        /// True velocity in m/s in NORTH direction in earth-fixed NED frame
        /// </summary>
        public float Vn
        {
            get
            {
                return this._vn;
            }
            set
            {
                this._vn = value;
            }
        }
        
        /// <summary>
        /// True velocity in m/s in EAST direction in earth-fixed NED frame
        /// </summary>
        public float Ve
        {
            get
            {
                return this._ve;
            }
            set
            {
                this._ve = value;
            }
        }
        
        /// <summary>
        /// True velocity in m/s in DOWN direction in earth-fixed NED frame
        /// </summary>
        public float Vd
        {
            get
            {
                return this._vd;
            }
            set
            {
                this._vd = value;
            }
        }
    }
}
