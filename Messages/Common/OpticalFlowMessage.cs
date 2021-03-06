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
    /// Optical flow from a flow sensor (e.g. optical mouse sensor)
    /// </summary>
    /// <remarks>
    /// OPTICAL_FLOW
    /// </remarks>
    [MessageMetadata(Type=MavLink4Net.Messages.MavMessageType.OpticalFlow, Name="OPTICAL_FLOW", Description="Optical flow from a flow sensor (e.g. optical mouse sensor)")]
    public class OpticalFlowMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (UNIX)
        /// </summary>
        /// <remarks>
        /// time_usec
        /// </remarks>
        private ulong _timeUsec;
        
        /// <summary>
        /// Sensor ID
        /// </summary>
        /// <remarks>
        /// sensor_id
        /// </remarks>
        private byte _sensorId;
        
        /// <summary>
        /// Flow in pixels * 10 in x-sensor direction (dezi-pixels)
        /// </summary>
        /// <remarks>
        /// flow_x
        /// </remarks>
        private short _flowX;
        
        /// <summary>
        /// Flow in pixels * 10 in y-sensor direction (dezi-pixels)
        /// </summary>
        /// <remarks>
        /// flow_y
        /// </remarks>
        private short _flowY;
        
        /// <summary>
        /// Flow in meters in x-sensor direction, angular-speed compensated
        /// </summary>
        /// <remarks>
        /// flow_comp_m_x
        /// </remarks>
        private float _flowCompMX;
        
        /// <summary>
        /// Flow in meters in y-sensor direction, angular-speed compensated
        /// </summary>
        /// <remarks>
        /// flow_comp_m_y
        /// </remarks>
        private float _flowCompMY;
        
        /// <summary>
        /// Optical flow quality / confidence. 0: bad, 255: maximum quality
        /// </summary>
        /// <remarks>
        /// quality
        /// </remarks>
        private byte _quality;
        
        /// <summary>
        /// Ground distance in meters. Positive value: distance known. Negative value: Unknown distance
        /// </summary>
        /// <remarks>
        /// ground_distance
        /// </remarks>
        private float _groundDistance;
        
        public OpticalFlowMessage() : 
                base(MavLink4Net.Messages.MavMessageType.OpticalFlow)
        {
        }
        
        /// <summary>
        /// Timestamp (UNIX)
        /// </summary>
        [MessageFieldMetadata(Name="time_usec", Type="uint64_t", Units="us", Description="Timestamp (UNIX)")]
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
        /// Sensor ID
        /// </summary>
        [MessageFieldMetadata(Name="sensor_id", Type="uint8_t", Description="Sensor ID")]
        public byte SensorId
        {
            get
            {
                return this._sensorId;
            }
            set
            {
                this._sensorId = value;
            }
        }
        
        /// <summary>
        /// Flow in pixels * 10 in x-sensor direction (dezi-pixels)
        /// </summary>
        [MessageFieldMetadata(Name="flow_x", Type="int16_t", Units="dpixels", Description="Flow in pixels * 10 in x-sensor direction (dezi-pixels)")]
        public short FlowX
        {
            get
            {
                return this._flowX;
            }
            set
            {
                this._flowX = value;
            }
        }
        
        /// <summary>
        /// Flow in pixels * 10 in y-sensor direction (dezi-pixels)
        /// </summary>
        [MessageFieldMetadata(Name="flow_y", Type="int16_t", Units="dpixels", Description="Flow in pixels * 10 in y-sensor direction (dezi-pixels)")]
        public short FlowY
        {
            get
            {
                return this._flowY;
            }
            set
            {
                this._flowY = value;
            }
        }
        
        /// <summary>
        /// Flow in meters in x-sensor direction, angular-speed compensated
        /// </summary>
        [MessageFieldMetadata(Name="flow_comp_m_x", Type="float", Units="m", Description="Flow in meters in x-sensor direction, angular-speed compensated")]
        public float FlowCompMX
        {
            get
            {
                return this._flowCompMX;
            }
            set
            {
                this._flowCompMX = value;
            }
        }
        
        /// <summary>
        /// Flow in meters in y-sensor direction, angular-speed compensated
        /// </summary>
        [MessageFieldMetadata(Name="flow_comp_m_y", Type="float", Units="m", Description="Flow in meters in y-sensor direction, angular-speed compensated")]
        public float FlowCompMY
        {
            get
            {
                return this._flowCompMY;
            }
            set
            {
                this._flowCompMY = value;
            }
        }
        
        /// <summary>
        /// Optical flow quality / confidence. 0: bad, 255: maximum quality
        /// </summary>
        [MessageFieldMetadata(Name="quality", Type="uint8_t", Description="Optical flow quality / confidence. 0: bad, 255: maximum quality")]
        public byte Quality
        {
            get
            {
                return this._quality;
            }
            set
            {
                this._quality = value;
            }
        }
        
        /// <summary>
        /// Ground distance in meters. Positive value: distance known. Negative value: Unknown distance
        /// </summary>
        [MessageFieldMetadata(Name="ground_distance", Type="float", Units="m", Description="Ground distance in meters. Positive value: distance known. Negative value: Unknow" +
            "n distance")]
        public float GroundDistance
        {
            get
            {
                return this._groundDistance;
            }
            set
            {
                this._groundDistance = value;
            }
        }
    }
}
