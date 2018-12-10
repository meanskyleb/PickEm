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
        public int WeekId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public bool HomeTeamWin { get; set; }
        public virtual Week Week { get; set; }
    }
}
