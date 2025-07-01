using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
    public class GameScoreClass
    {
        //경기정보
        [Key]
        public int? IDX { get; set; } = 0;
        public string? REF_IDX { get; set; } = "";
        public string? TEAM { get; set; } = "";
        public int? S1 { get; set; } = 0;
        public int? S2 { get; set; } = 0;
        public int? S3 { get; set; } = 0;
        public int? S4 { get; set; } = 0;
        public int? S5 { get; set; } = 0;
        public int? S6 { get; set; } = 0;
        public int? S7 { get; set; } = 0;
        public int? S8 { get; set; } = 0;
        public int? S9 { get; set; } = 0;
        public int? S10 { get; set; } = 0;
        public int? S11 { get; set; } = 0;
        public int? S12 { get; set; } = 0;
        public int? S13 { get; set; } = 0;
        public int? S14 { get; set; } = 0;
        public int? S15 { get; set; } = 0;
        public int? RUNS { get; set; } = 0;
        public int? HITS { get; set; } = 0;
        public int? ERRORS { get; set; } = 0;
        public int? BALLS { get; set; } = 0;
        public DateTime? REG_DATE { get; set; }
        public List<int?> InningScores => new()
        {
            S1, S2, S3, S4, S5, S6, S7, S8, S9,
            S10, S11, S12
        };
        //public bool UPDATE { get; set; } = false; 
        [NotMapped]
        public bool UPDATE { get; set; } = false;//기본 FALSE
    }
}
