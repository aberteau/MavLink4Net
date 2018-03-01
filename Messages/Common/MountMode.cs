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
    /// Enumeration of possible mount operation modes
    /// </summary>
    /// <remarks>
    /// MAV_MOUNT_MODE
    /// </remarks>
    public enum MountMode
    {
        
        /// <summary>
        /// Load and keep safe position (Roll,Pitch,Yaw) from permant memory and stop stabilization
        /// </summary>
        /// <remarks>
        /// MAV_MOUNT_MODE_RETRACT
        /// </remarks>
        [Description("Load and keep safe position (Roll,Pitch,Yaw) from permant memory and stop stabili" +
            "zation")]
        Retract = 0,
        
        /// <summary>
        /// Load and keep neutral position (Roll,Pitch,Yaw) from permanent memory.
        /// </summary>
        /// <remarks>
        /// MAV_MOUNT_MODE_NEUTRAL
        /// </remarks>
        [Description("Load and keep neutral position (Roll,Pitch,Yaw) from permanent memory.")]
        Neutral = 1,
        
        /// <summary>
        /// Load neutral position and start MAVLink Roll,Pitch,Yaw control with stabilization
        /// </summary>
        /// <remarks>
        /// MAV_MOUNT_MODE_MAVLINK_TARGETING
        /// </remarks>
        [Description("Load neutral position and start MAVLink Roll,Pitch,Yaw control with stabilization" +
            "")]
        MavlinkTargeting = 2,
        
        /// <summary>
        /// Load neutral position and start RC Roll,Pitch,Yaw control with stabilization
        /// </summary>
        /// <remarks>
        /// MAV_MOUNT_MODE_RC_TARGETING
        /// </remarks>
        [Description("Load neutral position and start RC Roll,Pitch,Yaw control with stabilization")]
        RcTargeting = 3,
        
        /// <summary>
        /// Load neutral position and start to point to Lat,Lon,Alt
        /// </summary>
        /// <remarks>
        /// MAV_MOUNT_MODE_GPS_POINT
        /// </remarks>
        [Description("Load neutral position and start to point to Lat,Lon,Alt")]
        GpsPoint = 4,
    }
}
