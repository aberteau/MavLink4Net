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
    /// Camera capability flags (Bitmap).
    /// </summary>
    /// <remarks>
    /// CAMERA_CAP_FLAGS
    /// </remarks>
    public enum CameraCapFlags
    {
        
        /// <summary>
        /// Camera is able to record video.
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_CAPTURE_VIDEO
        /// </remarks>
        [Description("Camera is able to record video.")]
        CaptureVideo = 1,
        
        /// <summary>
        /// Camera is able to capture images.
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_CAPTURE_IMAGE
        /// </remarks>
        [Description("Camera is able to capture images.")]
        CaptureImage = 2,
        
        /// <summary>
        /// Camera has separate Video and Image/Photo modes (MAV_CMD_SET_CAMERA_MODE)
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_HAS_MODES
        /// </remarks>
        [Description("Camera has separate Video and Image/Photo modes (MAV_CMD_SET_CAMERA_MODE)")]
        HasModes = 4,
        
        /// <summary>
        /// Camera can capture images while in video mode
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_CAN_CAPTURE_IMAGE_IN_VIDEO_MODE
        /// </remarks>
        [Description("Camera can capture images while in video mode")]
        CanCaptureImageInVideoMode = 8,
        
        /// <summary>
        /// Camera can capture videos while in Photo/Image mode
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_CAN_CAPTURE_VIDEO_IN_IMAGE_MODE
        /// </remarks>
        [Description("Camera can capture videos while in Photo/Image mode")]
        CanCaptureVideoInImageMode = 16,
        
        /// <summary>
        /// Camera has image survey mode (MAV_CMD_SET_CAMERA_MODE)
        /// </summary>
        /// <remarks>
        /// CAMERA_CAP_FLAGS_HAS_IMAGE_SURVEY_MODE
        /// </remarks>
        [Description("Camera has image survey mode (MAV_CMD_SET_CAMERA_MODE)")]
        HasImageSurveyMode = 32,
    }
}
