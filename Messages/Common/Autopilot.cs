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
    /// Micro air vehicle / autopilot classes. This identifies the individual model.
    /// </summary>
    /// <remarks>
    /// MAV_AUTOPILOT
    /// </remarks>
    public enum Autopilot
    {
        
        /// <summary>
        /// Generic autopilot, full support for everything
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_GENERIC
        /// </remarks>
        [Description("Generic autopilot, full support for everything")]
        Generic = 0,
        
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_RESERVED
        /// </remarks>
        [Description("Reserved for future use.")]
        Reserved = 1,
        
        /// <summary>
        /// SLUGS autopilot, http://slugsuav.soe.ucsc.edu
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_SLUGS
        /// </remarks>
        [Description("SLUGS autopilot, http://slugsuav.soe.ucsc.edu")]
        Slugs = 2,
        
        /// <summary>
        /// ArduPilotMega / ArduCopter, http://diydrones.com
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_ARDUPILOTMEGA
        /// </remarks>
        [Description("ArduPilotMega / ArduCopter, http://diydrones.com")]
        Ardupilotmega = 3,
        
        /// <summary>
        /// OpenPilot, http://openpilot.org
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_OPENPILOT
        /// </remarks>
        [Description("OpenPilot, http://openpilot.org")]
        Openpilot = 4,
        
        /// <summary>
        /// Generic autopilot only supporting simple waypoints
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_GENERIC_WAYPOINTS_ONLY
        /// </remarks>
        [Description("Generic autopilot only supporting simple waypoints")]
        GenericWaypointsOnly = 5,
        
        /// <summary>
        /// Generic autopilot supporting waypoints and other simple navigation commands
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_GENERIC_WAYPOINTS_AND_SIMPLE_NAVIGATION_ONLY
        /// </remarks>
        [Description("Generic autopilot supporting waypoints and other simple navigation commands")]
        GenericWaypointsAndSimpleNavigationOnly = 6,
        
        /// <summary>
        /// Generic autopilot supporting the full mission command set
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_GENERIC_MISSION_FULL
        /// </remarks>
        [Description("Generic autopilot supporting the full mission command set")]
        GenericMissionFull = 7,
        
        /// <summary>
        /// No valid autopilot, e.g. a GCS or other MAVLink component
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_INVALID
        /// </remarks>
        [Description("No valid autopilot, e.g. a GCS or other MAVLink component")]
        Invalid = 8,
        
        /// <summary>
        /// PPZ UAV - http://nongnu.org/paparazzi
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_PPZ
        /// </remarks>
        [Description("PPZ UAV - http://nongnu.org/paparazzi")]
        Ppz = 9,
        
        /// <summary>
        /// UAV Dev Board
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_UDB
        /// </remarks>
        [Description("UAV Dev Board")]
        Udb = 10,
        
        /// <summary>
        /// FlexiPilot
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_FP
        /// </remarks>
        [Description("FlexiPilot")]
        Fp = 11,
        
        /// <summary>
        /// PX4 Autopilot - http://pixhawk.ethz.ch/px4/
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_PX4
        /// </remarks>
        [Description("PX4 Autopilot - http://pixhawk.ethz.ch/px4/")]
        Px4 = 12,
        
        /// <summary>
        /// SMACCMPilot - http://smaccmpilot.org
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_SMACCMPILOT
        /// </remarks>
        [Description("SMACCMPilot - http://smaccmpilot.org")]
        Smaccmpilot = 13,
        
        /// <summary>
        /// AutoQuad -- http://autoquad.org
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_AUTOQUAD
        /// </remarks>
        [Description("AutoQuad -- http://autoquad.org")]
        Autoquad = 14,
        
        /// <summary>
        /// Armazila -- http://armazila.com
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_ARMAZILA
        /// </remarks>
        [Description("Armazila -- http://armazila.com")]
        Armazila = 15,
        
        /// <summary>
        /// Aerob -- http://aerob.ru
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_AEROB
        /// </remarks>
        [Description("Aerob -- http://aerob.ru")]
        Aerob = 16,
        
        /// <summary>
        /// ASLUAV autopilot -- http://www.asl.ethz.ch
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_ASLUAV
        /// </remarks>
        [Description("ASLUAV autopilot -- http://www.asl.ethz.ch")]
        Asluav = 17,
        
        /// <summary>
        /// SmartAP Autopilot - http://sky-drones.com
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_SMARTAP
        /// </remarks>
        [Description("SmartAP Autopilot - http://sky-drones.com")]
        Smartap = 18,
        
        /// <summary>
        /// AirRails - http://uaventure.com
        /// </summary>
        /// <remarks>
        /// MAV_AUTOPILOT_AIRRAILS
        /// </remarks>
        [Description("AirRails - http://uaventure.com")]
        Airrails = 19,
    }
}