using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBallApp.Shared.Models
{
    public class GameWithScores
    {
        //경기정보
        public GameClass Game { get; set; }
        //점수
        public List<GameScoreClass> Scores { get; set; } = new();

    }
}
