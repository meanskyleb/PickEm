using PickEm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.GameModels
{
    public class GameEdit
    {
        public readonly int GameId;

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int PlayerId { get; set; }
        public bool HomeTeamWin { get; set; }

        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
        
        //public int WeekId { get; set; }
        //public virtual Week Week { get; set; }



    }
}
