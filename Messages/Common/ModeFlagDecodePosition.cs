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
    /// These values encode the bit positions of the decode position. These values can be used to read the value of a flag bit by combining the base_mode variable with AND with the flag position value. The result will be either 0 or 1, depending on if the flag is set or not.
    /// </summary>
    /// <remarks>
    /// MAV_MODE_FLAG_DECODE_POSITION
    /// </remarks>
    public enum ModeFlagDecodePosition
    {
        
        /// <summary>
        /// First bit:  10000000
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_SAFETY
        /// </remarks>
        [Description("First bit:  10000000")]
        Safety = 128,
        
        /// <summary>
        /// Second bit: 01000000
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_MANUAL
        /// </remarks>
        [Description("Second bit: 01000000")]
        Manual = 64,
        
        /// <summary>
        /// Third bit:  00100000
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_HIL
        /// </remarks>
        [Description("Third bit:  00100000")]
        Hil = 32,
        
        /// <summary>
        /// Fourth bit: 00010000
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_STABILIZE
        /// </remarks>
        [Description("Fourth bit: 00010000")]
        Stabilize = 16,
        
        /// <summary>
        /// Fifth bit:  00001000
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_GUIDED
        /// </remarks>
        [Description("Fifth bit:  00001000")]
        Guided = 8,
        
        /// <summary>
        /// Sixt bit:   00000100
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_AUTO
        /// </remarks>
        [Description("Sixt bit:   00000100")]
        Auto = 4,
        
        /// <summary>
        /// Seventh bit: 00000010
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_TEST
        /// </remarks>
        [Description("Seventh bit: 00000010")]
        Test = 2,
        
        /// <summary>
        /// Eighth bit: 00000001
        /// </summary>
        /// <remarks>
        /// MAV_MODE_FLAG_DECODE_POSITION_CUSTOM_MODE
        /// </remarks>
        [Description("Eighth bit: 00000001")]
        CustomMode = 1,
    }
}
