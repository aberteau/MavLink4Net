//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MavLink4Net.Messages.Metadata;
using System;
using System.ComponentModel;


namespace MavLink4Net.Messages.Common
{
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// VISION_POSITION_ESTIMATE
    /// </remarks>
    [MessageMetadata(Type=MavLink4Net.Messages.MavMessageType.VisionPositionEstimate, Name="VISION_POSITION_ESTIMATE", Description=null)]
    public class VisionPositionEstimateMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (microseconds, synced to UNIX time or since system boot)
        /// </summary>
        /// <remarks>
        /// usec
        /// </remarks>
        private ulong _usec;
        
        /// <summary>
        /// Global X position
        /// </summary>
        /// <remarks>
        /// x
        /// </remarks>
        private float _x;
        
        /// <summary>
        /// Global Y position
        /// </summary>
        /// <remarks>
        /// y
        /// </remarks>
        private float _y;
        
        /// <summary>
        /// Global Z position
        /// </summary>
        /// <remarks>
        /// z
        /// </remarks>
        private float _z;
        
        /// <summary>
        /// Roll angle in rad
        /// </summary>
        /// <remarks>
        /// roll
        /// </remarks>
        private float _roll;
        
        /// <summary>
        /// Pitch angle in rad
        /// </summary>
        /// <remarks>
        /// pitch
        /// </remarks>
        private float _pitch;
        
        /// <summary>
        /// Yaw angle in rad
        /// </summary>
        /// <remarks>
        /// yaw
        /// </remarks>
        private float _yaw;
        
        public VisionPositionEstimateMessage() : 
                base(MavLink4Net.Messages.MavMessageType.VisionPositionEstimate)
        {
        }
        
        /// <summary>
        /// Timestamp (microseconds, synced to UNIX time or since system boot)
        /// </summary>
        [MessageFieldMetadata(Name="usec", Type="uint64_t", Units="us", Description="Timestamp (microseconds, synced to UNIX time or since system boot)")]
        public ulong Usec
        {
            get
            {
                return this._usec;
            }
            set
            {
                this._usec = value;
            }
        }
        
        /// <summary>
        /// Global X position
        /// </summary>
        [MessageFieldMetadata(Name="x", Type="float", Units="m", Description="Global X position")]
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
        /// Global Y position
        /// </summary>
        [MessageFieldMetadata(Name="y", Type="float", Units="m", Description="Global Y position")]
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
        /// Global Z position
        /// </summary>
        [MessageFieldMetadata(Name="z", Type="float", Units="m", Description="Global Z position")]
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
        /// Roll angle in rad
        /// </summary>
        [MessageFieldMetadata(Name="roll", Type="float", Units="rad", Description="Roll angle in rad")]
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
        /// Pitch angle in rad
        /// </summary>
        [MessageFieldMetadata(Name="pitch", Type="float", Units="rad", Description="Pitch angle in rad")]
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
        /// Yaw angle in rad
        /// </summary>
        [MessageFieldMetadata(Name="yaw", Type="float", Units="rad", Description="Yaw angle in rad")]
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
    }
}
