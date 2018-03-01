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
    /// RTK GPS data. Gives information on the relative baseline calculation the GPS is reporting
    /// </summary>
    /// <remarks>
    /// GPS2_RTK
    /// </remarks>
    public class Gps2RtkMessage : MavLink4Net.Messages.Message
    {
        
        /// <summary>
        /// Time since boot of last baseline message received in ms.
        /// </summary>
        /// <remarks>
        /// time_last_baseline_ms
        /// </remarks>
        private uint _timeLastBaselineMs;
        
        /// <summary>
        /// Identification of connected RTK receiver.
        /// </summary>
        /// <remarks>
        /// rtk_receiver_id
        /// </remarks>
        private byte _rtkReceiverId;
        
        /// <summary>
        /// GPS Week Number of last baseline
        /// </summary>
        /// <remarks>
        /// wn
        /// </remarks>
        private ushort _wn;
        
        /// <summary>
        /// GPS Time of Week of last baseline
        /// </summary>
        /// <remarks>
        /// tow
        /// </remarks>
        private uint _tow;
        
        /// <summary>
        /// GPS-specific health report for RTK data.
        /// </summary>
        /// <remarks>
        /// rtk_health
        /// </remarks>
        private byte _rtkHealth;
        
        /// <summary>
        /// Rate of baseline messages being received by GPS, in HZ
        /// </summary>
        /// <remarks>
        /// rtk_rate
        /// </remarks>
        private byte _rtkRate;
        
        /// <summary>
        /// Current number of sats used for RTK calculation.
        /// </summary>
        /// <remarks>
        /// nsats
        /// </remarks>
        private byte _nsats;
        
        /// <summary>
        /// Coordinate system of baseline
        /// </summary>
        /// <remarks>
        /// baseline_coords_type
        /// </remarks>
        private RtkBaselineCoordinateSystem _baselineCoordsType;
        
        /// <summary>
        /// Current baseline in ECEF x or NED north component in mm.
        /// </summary>
        /// <remarks>
        /// baseline_a_mm
        /// </remarks>
        private int _baselineAMm;
        
        /// <summary>
        /// Current baseline in ECEF y or NED east component in mm.
        /// </summary>
        /// <remarks>
        /// baseline_b_mm
        /// </remarks>
        private int _baselineBMm;
        
        /// <summary>
        /// Current baseline in ECEF z or NED down component in mm.
        /// </summary>
        /// <remarks>
        /// baseline_c_mm
        /// </remarks>
        private int _baselineCMm;
        
        /// <summary>
        /// Current estimate of baseline accuracy.
        /// </summary>
        /// <remarks>
        /// accuracy
        /// </remarks>
        private uint _accuracy;
        
        /// <summary>
        /// Current number of integer ambiguity hypotheses.
        /// </summary>
        /// <remarks>
        /// iar_num_hypotheses
        /// </remarks>
        private int _iarNumHypotheses;
        
        public Gps2RtkMessage() : 
                base(MavLink4Net.Messages.MavMessageType.Gps2Rtk, 226)
        {
        }
        
        /// <summary>
        /// Time since boot of last baseline message received in ms.
        /// </summary>
        public uint TimeLastBaselineMs
        {
            get
            {
                return this._timeLastBaselineMs;
            }
            set
            {
                this._timeLastBaselineMs = value;
            }
        }
        
        /// <summary>
        /// Identification of connected RTK receiver.
        /// </summary>
        public byte RtkReceiverId
        {
            get
            {
                return this._rtkReceiverId;
            }
            set
            {
                this._rtkReceiverId = value;
            }
        }
        
        /// <summary>
        /// GPS Week Number of last baseline
        /// </summary>
        public ushort Wn
        {
            get
            {
                return this._wn;
            }
            set
            {
                this._wn = value;
            }
        }
        
        /// <summary>
        /// GPS Time of Week of last baseline
        /// </summary>
        public uint Tow
        {
            get
            {
                return this._tow;
            }
            set
            {
                this._tow = value;
            }
        }
        
        /// <summary>
        /// GPS-specific health report for RTK data.
        /// </summary>
        public byte RtkHealth
        {
            get
            {
                return this._rtkHealth;
            }
            set
            {
                this._rtkHealth = value;
            }
        }
        
        /// <summary>
        /// Rate of baseline messages being received by GPS, in HZ
        /// </summary>
        public byte RtkRate
        {
            get
            {
                return this._rtkRate;
            }
            set
            {
                this._rtkRate = value;
            }
        }
        
        /// <summary>
        /// Current number of sats used for RTK calculation.
        /// </summary>
        public byte Nsats
        {
            get
            {
                return this._nsats;
            }
            set
            {
                this._nsats = value;
            }
        }
        
        /// <summary>
        /// Coordinate system of baseline
        /// </summary>
        public RtkBaselineCoordinateSystem BaselineCoordsType
        {
            get
            {
                return this._baselineCoordsType;
            }
            set
            {
                this._baselineCoordsType = value;
            }
        }
        
        /// <summary>
        /// Current baseline in ECEF x or NED north component in mm.
        /// </summary>
        public int BaselineAMm
        {
            get
            {
                return this._baselineAMm;
            }
            set
            {
                this._baselineAMm = value;
            }
        }
        
        /// <summary>
        /// Current baseline in ECEF y or NED east component in mm.
        /// </summary>
        public int BaselineBMm
        {
            get
            {
                return this._baselineBMm;
            }
            set
            {
                this._baselineBMm = value;
            }
        }
        
        /// <summary>
        /// Current baseline in ECEF z or NED down component in mm.
        /// </summary>
        public int BaselineCMm
        {
            get
            {
                return this._baselineCMm;
            }
            set
            {
                this._baselineCMm = value;
            }
        }
        
        /// <summary>
        /// Current estimate of baseline accuracy.
        /// </summary>
        public uint Accuracy
        {
            get
            {
                return this._accuracy;
            }
            set
            {
                this._accuracy = value;
            }
        }
        
        /// <summary>
        /// Current number of integer ambiguity hypotheses.
        /// </summary>
        public int IarNumHypotheses
        {
            get
            {
                return this._iarNumHypotheses;
            }
            set
            {
                this._iarNumHypotheses = value;
            }
        }
    }
}
