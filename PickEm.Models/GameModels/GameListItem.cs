using PickEm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.GameModels
{
    public class GameListItem
    {
        [Display(Name = "Game Id")]
        public int GameId { get; set; }

        [Display(Name = "Home Team")]
        public NamesOfTeams HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public NamesOfTeams AwayTeam { get; set; }

        [Display(Name = "Home Team Id")]
        public int HomeTeamId { get; set; }

        [Display(Name = "Away Team Id")]
        public int AwayTeamId { get; set; }

        [Display(Name = "Player")]
        public int PlayerId { get; set; }

        [Display(Name = "Home Team Win")]
        public bool HomeTeamWin { get; set; }

        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }

        //public int WeekId { get; set; }
        //public virtual Week Week { get; set; }

    }
}
