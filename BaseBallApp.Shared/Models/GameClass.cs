using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
    public class GameClass
    {
        //경기정보
        [Key]
        public int? IDX { get; set; } = 0;
        public string? HOMETEAM { get; set; }
        public string? AWAYTEAM { get; set; }
        public int? STATUS { get; set; } //0:예정, 1:승리, 2:패배, 3:무승부, 4:경기취소
        public string? PLACE { get; set; }
        public string? CATEGORY { get; set; }
        public DateTime? STARTTIME { get; set; }
        //[NotMapped]
        public string? HomeTeamFile { get; set; }
        //[NotMapped]
        public string? AwayTeamFile { get; set; }

        public List<OptionItem> Options = new List<OptionItem>
        {
            new OptionItem{ Value = 0 ,Text = "경기예정"},
            new OptionItem{ Value = 1 ,Text = "승리"},
            new OptionItem{ Value = 2 ,Text = "패배"},
            new OptionItem{ Value = 3 ,Text = "무승부"},
            new OptionItem{ Value = 4 ,Text = "경기취소"}
        };
    }
    public class OptionItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
