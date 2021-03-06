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
    /// Simulated optical flow from a flow sensor (e.g. PX4FLOW or optical mouse sensor)
    /// </summary>
    /// <remarks>
    /// HIL_OPTICAL_FLOW
    /// </remarks>
    [MessageMetadata(Type=MavLink4Net.Messages.MavMessageType.HilOpticalFlow, Name="HIL_OPTICAL_FLOW", Description="Simulated optical flow from a flow sensor (e.g. PX4FLOW or optical mouse sensor)")]
    public class HilOpticalFlowMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Timestamp (microseconds, synced to UNIX time or since system boot)
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
        /// Integration time in microseconds. Divide integrated_x and integrated_y by the integration time to obtain average flow. The integration time also indicates the.
        /// </summary>
        /// <remarks>
        /// integration_time_us
        /// </remarks>
        private uint _integrationTimeUs;
        
        /// <summary>
        /// Flow in radians around X axis (Sensor RH rotation about the X axis induces a positive flow. Sensor linear motion along the positive Y axis induces a negative flow.)
        /// </summary>
        /// <remarks>
        /// integrated_x
        /// </remarks>
        private float _integratedX;
        
        /// <summary>
        /// Flow in radians around Y axis (Sensor RH rotation about the Y axis induces a positive flow. Sensor linear motion along the positive X axis induces a positive flow.)
        /// </summary>
        /// <remarks>
        /// integrated_y
        /// </remarks>
        private float _integratedY;
        
        /// <summary>
        /// RH rotation around X axis (rad)
        /// </summary>
        /// <remarks>
        /// integrated_xgyro
        /// </remarks>
        private float _integratedXgyro;
        
        /// <summary>
        /// RH rotation around Y axis (rad)
        /// </summary>
        /// <remarks>
        /// integrated_ygyro
        /// </remarks>
        private float _integratedYgyro;
        
        /// <summary>
        /// RH rotation around Z axis (rad)
        /// </summary>
        /// <remarks>
        /// integrated_zgyro
        /// </remarks>
        private float _integratedZgyro;
        
        /// <summary>
        /// Temperature * 100 in centi-degrees Celsius
        /// </summary>
        /// <remarks>
        /// temperature
        /// </remarks>
        private short _temperature;
        
        /// <summary>
        /// Optical flow quality / confidence. 0: no valid flow, 255: maximum quality
        /// </summary>
        /// <remarks>
        /// quality
        /// </remarks>
        private byte _quality;
        
        /// <summary>
        /// Time in microseconds since the distance was sampled.
        /// </summary>
        /// <remarks>
        /// time_delta_distance_us
        /// </remarks>
        private uint _timeDeltaDistanceUs;
        
        /// <summary>
        /// Distance to the center of the flow field in meters. Positive value (including zero): distance known. Negative value: Unknown distance.
        /// </summary>
        /// <remarks>
        /// distance
        /// </remarks>
        private float _distance;
        
        public HilOpticalFlowMessage() : 
                base(MavLink4Net.Messages.MavMessageType.HilOpticalFlow)
        {
        }
        
        /// <summary>
        /// Timestamp (microseconds, synced to UNIX time or since system boot)
        /// </summary>
        [MessageFieldMetadata(Name="time_usec", Type="uint64_t", Units="us", Description="Timestamp (microseconds, synced to UNIX time or since system boot)")]
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
        /// Integration time in microseconds. Divide integrated_x and integrated_y by the integration time to obtain average flow. The integration time also indicates the.
        /// </summary>
        [MessageFieldMetadata(Name="integration_time_us", Type="uint32_t", Units="us", Description="Integration time in microseconds. Divide integrated_x and integrated_y by the int" +
            "egration time to obtain average flow. The integration time also indicates the.")]
        public uint IntegrationTimeUs
        {
            get
            {
                return this._integrationTimeUs;
            }
            set
            {
                this._integrationTimeUs = value;
            }
        }
        
        /// <summary>
        /// Flow in radians around X axis (Sensor RH rotation about the X axis induces a positive flow. Sensor linear motion along the positive Y axis induces a negative flow.)
        /// </summary>
        [MessageFieldMetadata(Name="integrated_x", Type="float", Units="rad", Description="Flow in radians around X axis (Sensor RH rotation about the X axis induces a posi" +
            "tive flow. Sensor linear motion along the positive Y axis induces a negative flo" +
            "w.)")]
        public float IntegratedX
        {
            get
            {
                return this._integratedX;
            }
            set
            {
                this._integratedX = value;
            }
        }
        
        /// <summary>
        /// Flow in radians around Y axis (Sensor RH rotation about the Y axis induces a positive flow. Sensor linear motion along the positive X axis induces a positive flow.)
        /// </summary>
        [MessageFieldMetadata(Name="integrated_y", Type="float", Units="rad", Description="Flow in radians around Y axis (Sensor RH rotation about the Y axis induces a posi" +
            "tive flow. Sensor linear motion along the positive X axis induces a positive flo" +
            "w.)")]
        public float IntegratedY
        {
            get
            {
                return this._integratedY;
            }
            set
            {
                this._integratedY = value;
            }
        }
        
        /// <summary>
        /// RH rotation around X axis (rad)
        /// </summary>
        [MessageFieldMetadata(Name="integrated_xgyro", Type="float", Units="rad", Description="RH rotation around X axis (rad)")]
        public float IntegratedXgyro
        {
            get
            {
                return this._integratedXgyro;
            }
            set
            {
                this._integratedXgyro = value;
            }
        }
        
        /// <summary>
        /// RH rotation around Y axis (rad)
        /// </summary>
        [MessageFieldMetadata(Name="integrated_ygyro", Type="float", Units="rad", Description="RH rotation around Y axis (rad)")]
        public float IntegratedYgyro
        {
            get
            {
                return this._integratedYgyro;
            }
            set
            {
                this._integratedYgyro = value;
            }
        }
        
        /// <summary>
        /// RH rotation around Z axis (rad)
        /// </summary>
        [MessageFieldMetadata(Name="integrated_zgyro", Type="float", Units="rad", Description="RH rotation around Z axis (rad)")]
        public float IntegratedZgyro
        {
            get
            {
                return this._integratedZgyro;
            }
            set
            {
                this._integratedZgyro = value;
            }
        }
        
        /// <summary>
        /// Temperature * 100 in centi-degrees Celsius
        /// </summary>
        [MessageFieldMetadata(Name="temperature", Type="int16_t", Units="cdegC", Description="Temperature * 100 in centi-degrees Celsius")]
        public short Temperature
        {
            get
            {
                return this._temperature;
            }
            set
            {
                this._temperature = value;
            }
        }
        
        /// <summary>
        /// Optical flow quality / confidence. 0: no valid flow, 255: maximum quality
        /// </summary>
        [MessageFieldMetadata(Name="quality", Type="uint8_t", Description="Optical flow quality / confidence. 0: no valid flow, 255: maximum quality")]
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
        /// Time in microseconds since the distance was sampled.
        /// </summary>
        [MessageFieldMetadata(Name="time_delta_distance_us", Type="uint32_t", Units="us", Description="Time in microseconds since the distance was sampled.")]
        public uint TimeDeltaDistanceUs
        {
            get
            {
                return this._timeDeltaDistanceUs;
            }
            set
            {
                this._timeDeltaDistanceUs = value;
            }
        }
        
        /// <summary>
        /// Distance to the center of the flow field in meters. Positive value (including zero): distance known. Negative value: Unknown distance.
        /// </summary>
        [MessageFieldMetadata(Name="distance", Type="float", Units="m", Description="Distance to the center of the flow field in meters. Positive value (including zer" +
            "o): distance known. Negative value: Unknown distance.")]
        public float Distance
        {
            get
            {
                return this._distance;
            }
            set
            {
                this._distance = value;
            }
        }
    }
}
