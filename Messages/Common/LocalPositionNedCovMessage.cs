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
    /// The filtered local position (e.g. fused computer vision and accelerometers). Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)
    /// </summary>
    /// <remarks>
    /// LOCAL_POSITION_NED_COV
    /// </remarks>
    public class LocalPositionNedCovMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (microseconds since system boot or since UNIX epoch)
        /// </summary>
        /// <remarks>
        /// time_usec
        /// </remarks>
        private ulong _timeUsec;
        
        /// <summary>
        /// Class id of the estimator this estimate originated from.
        /// </summary>
        /// <remarks>
        /// estimator_type
        /// </remarks>
        private EstimatorType _estimatorType;
        
        /// <summary>
        /// X Position
        /// </summary>
        /// <remarks>
        /// x
        /// </remarks>
        private float _x;
        
        /// <summary>
        /// Y Position
        /// </summary>
        /// <remarks>
        /// y
        /// </remarks>
        private float _y;
        
        /// <summary>
        /// Z Position
        /// </summary>
        /// <remarks>
        /// z
        /// </remarks>
        private float _z;
        
        /// <summary>
        /// X Speed (m/s)
        /// </summary>
        /// <remarks>
        /// vx
        /// </remarks>
        private float _vx;
        
        /// <summary>
        /// Y Speed (m/s)
        /// </summary>
        /// <remarks>
        /// vy
        /// </remarks>
        private float _vy;
        
        /// <summary>
        /// Z Speed (m/s)
        /// </summary>
        /// <remarks>
        /// vz
        /// </remarks>
        private float _vz;
        
        /// <summary>
        /// X Acceleration (m/s^2)
        /// </summary>
        /// <remarks>
        /// ax
        /// </remarks>
        private float _ax;
        
        /// <summary>
        /// Y Acceleration (m/s^2)
        /// </summary>
        /// <remarks>
        /// ay
        /// </remarks>
        private float _ay;
        
        /// <summary>
        /// Z Acceleration (m/s^2)
        /// </summary>
        /// <remarks>
        /// az
        /// </remarks>
        private float _az;
        
        /// <summary>
        /// Covariance matrix upper right triangular (first nine entries are the first ROW, next eight entries are the second row, etc.)
        /// </summary>
        /// <remarks>
        /// covariance
        /// </remarks>
        private float[] _covariance = new float[45];
        
        public LocalPositionNedCovMessage() : 
                base(MavLink4Net.Messages.MavMessageType.LocalPositionNedCov, 191)
        {
        }
        
        /// <summary>
        /// Timestamp (microseconds since system boot or since UNIX epoch)
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
        /// Class id of the estimator this estimate originated from.
        /// </summary>
        public EstimatorType EstimatorType
        {
            get
            {
                return this._estimatorType;
            }
            set
            {
                this._estimatorType = value;
            }
        }
        
        /// <summary>
        /// X Position
        /// </summary>
        public float X
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
        /// Y Position
        /// </summary>
        public float Y
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
        /// Z Position
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
        /// X Speed (m/s)
        /// </summary>
        public float Vx
        {
            get
            {
                return this._vx;
            }
            set
            {
                this._vx = value;
            }
        }
        
        /// <summary>
        /// Y Speed (m/s)
        /// </summary>
        public float Vy
        {
            get
            {
                return this._vy;
            }
            set
            {
                this._vy = value;
            }
        }
        
        /// <summary>
        /// Z Speed (m/s)
        /// </summary>
        public float Vz
        {
            get
            {
                return this._vz;
            }
            set
            {
                this._vz = value;
            }
        }
        
        /// <summary>
        /// X Acceleration (m/s^2)
        /// </summary>
        public float Ax
        {
            get
            {
                return this._ax;
            }
            set
            {
                this._ax = value;
            }
        }
        
        /// <summary>
        /// Y Acceleration (m/s^2)
        /// </summary>
        public float Ay
        {
            get
            {
                return this._ay;
            }
            set
            {
                this._ay = value;
            }
        }
        
        /// <summary>
        /// Z Acceleration (m/s^2)
        /// </summary>
        public float Az
        {
            get
            {
                return this._az;
            }
            set
            {
                this._az = value;
            }
        }
        
        /// <summary>
        /// Covariance matrix upper right triangular (first nine entries are the first ROW, next eight entries are the second row, etc.)
        /// </summary>
        public float[] Covariance
        {
            get
            {
                return this._covariance;
            }
            set
            {
                this._covariance = value;
            }
        }
    }
}
