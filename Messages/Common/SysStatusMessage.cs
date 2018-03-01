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
    /// The general system state. If the system is following the MAVLink standard, the system state is mainly defined by three orthogonal states/modes: The system mode, which is either LOCKED (motors shut down and locked), MANUAL (system under RC control), GUIDED (system with autonomous position control, position setpoint controlled manually) or AUTO (system guided by path/waypoint planner). The NAV_MODE defined the current flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR. This represents the internal navigation state machine. The system status shows whether the system is currently active or not and if an emergency occured. During the CRITICAL and EMERGENCY states the MAV is still considered to be active, but should start emergency procedures autonomously. After a failure occured it should first move from active to critical to allow manual intervention and then move to emergency after a certain timeout.
    /// </summary>
    /// <remarks>
    /// SYS_STATUS
    /// </remarks>
    public class SysStatusMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are present. Value of 0: not present. Value of 1: present. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        /// <remarks>
        /// onboard_control_sensors_present
        /// </remarks>
        private SysStatusSensor _onboardControlSensorsPresent;
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are enabled:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        /// <remarks>
        /// onboard_control_sensors_enabled
        /// </remarks>
        private SysStatusSensor _onboardControlSensorsEnabled;
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are operational or have an error:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        /// <remarks>
        /// onboard_control_sensors_health
        /// </remarks>
        private SysStatusSensor _onboardControlSensorsHealth;
        
        /// <summary>
        /// Maximum usage in percent of the mainloop time, (0%: 0, 100%: 1000) should be always below 1000
        /// </summary>
        /// <remarks>
        /// load
        /// </remarks>
        private ushort _load;
        
        /// <summary>
        /// Battery voltage, in millivolts (1 = 1 millivolt)
        /// </summary>
        /// <remarks>
        /// voltage_battery
        /// </remarks>
        private ushort _voltageBattery;
        
        /// <summary>
        /// Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current
        /// </summary>
        /// <remarks>
        /// current_battery
        /// </remarks>
        private short _currentBattery;
        
        /// <summary>
        /// Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot estimate the remaining battery
        /// </summary>
        /// <remarks>
        /// battery_remaining
        /// </remarks>
        private sbyte _batteryRemaining;
        
        /// <summary>
        /// Communication drops in percent, (0%: 0, 100%: 10'000), (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        /// <remarks>
        /// drop_rate_comm
        /// </remarks>
        private ushort _dropRateComm;
        
        /// <summary>
        /// Communication errors (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        /// <remarks>
        /// errors_comm
        /// </remarks>
        private ushort _errorsComm;
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        /// <remarks>
        /// errors_count1
        /// </remarks>
        private ushort _errorsCount1;
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        /// <remarks>
        /// errors_count2
        /// </remarks>
        private ushort _errorsCount2;
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        /// <remarks>
        /// errors_count3
        /// </remarks>
        private ushort _errorsCount3;
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        /// <remarks>
        /// errors_count4
        /// </remarks>
        private ushort _errorsCount4;
        
        public SysStatusMessage() : 
                base(MavLink4Net.Messages.MavMessageType.SysStatus, 124)
        {
        }
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are present. Value of 0: not present. Value of 1: present. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        public SysStatusSensor OnboardControlSensorsPresent
        {
            get
            {
                return this._onboardControlSensorsPresent;
            }
            set
            {
                this._onboardControlSensorsPresent = value;
            }
        }
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are enabled:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        public SysStatusSensor OnboardControlSensorsEnabled
        {
            get
            {
                return this._onboardControlSensorsEnabled;
            }
            set
            {
                this._onboardControlSensorsEnabled = value;
            }
        }
        
        /// <summary>
        /// Bitmask showing which onboard controllers and sensors are operational or have an error:  Value of 0: not enabled. Value of 1: enabled. Indices defined by ENUM MAV_SYS_STATUS_SENSOR
        /// </summary>
        public SysStatusSensor OnboardControlSensorsHealth
        {
            get
            {
                return this._onboardControlSensorsHealth;
            }
            set
            {
                this._onboardControlSensorsHealth = value;
            }
        }
        
        /// <summary>
        /// Maximum usage in percent of the mainloop time, (0%: 0, 100%: 1000) should be always below 1000
        /// </summary>
        public ushort Load
        {
            get
            {
                return this._load;
            }
            set
            {
                this._load = value;
            }
        }
        
        /// <summary>
        /// Battery voltage, in millivolts (1 = 1 millivolt)
        /// </summary>
        public ushort VoltageBattery
        {
            get
            {
                return this._voltageBattery;
            }
            set
            {
                this._voltageBattery = value;
            }
        }
        
        /// <summary>
        /// Battery current, in 10*milliamperes (1 = 10 milliampere), -1: autopilot does not measure the current
        /// </summary>
        public short CurrentBattery
        {
            get
            {
                return this._currentBattery;
            }
            set
            {
                this._currentBattery = value;
            }
        }
        
        /// <summary>
        /// Remaining battery energy: (0%: 0, 100%: 100), -1: autopilot estimate the remaining battery
        /// </summary>
        public sbyte BatteryRemaining
        {
            get
            {
                return this._batteryRemaining;
            }
            set
            {
                this._batteryRemaining = value;
            }
        }
        
        /// <summary>
        /// Communication drops in percent, (0%: 0, 100%: 10'000), (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        public ushort DropRateComm
        {
            get
            {
                return this._dropRateComm;
            }
            set
            {
                this._dropRateComm = value;
            }
        }
        
        /// <summary>
        /// Communication errors (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)
        /// </summary>
        public ushort ErrorsComm
        {
            get
            {
                return this._errorsComm;
            }
            set
            {
                this._errorsComm = value;
            }
        }
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        public ushort ErrorsCount1
        {
            get
            {
                return this._errorsCount1;
            }
            set
            {
                this._errorsCount1 = value;
            }
        }
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        public ushort ErrorsCount2
        {
            get
            {
                return this._errorsCount2;
            }
            set
            {
                this._errorsCount2 = value;
            }
        }
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        public ushort ErrorsCount3
        {
            get
            {
                return this._errorsCount3;
            }
            set
            {
                this._errorsCount3 = value;
            }
        }
        
        /// <summary>
        /// Autopilot-specific errors
        /// </summary>
        public ushort ErrorsCount4
        {
            get
            {
                return this._errorsCount4;
            }
            set
            {
                this._errorsCount4 = value;
            }
        }
    }
}