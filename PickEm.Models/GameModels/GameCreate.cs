using PickEm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        [Display(Name = "Home Team")]
        public NamesOfTeams HomeTeam { get; set; }

        [Required]
        [Display(Name = "Away Team")]
        public NamesOfTeams AwayTeam { get; set; }

        [Required]
        [Display(Name = "Away Team Id")]
        public int AwayTeamId { get; set; }

        [Required]
        [Display(Name = "Home Team Id")]
        public int HomeTeamId { get; set; }

        [Required]
        [Display(Name = "Player")]
        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Home Team Win")]
        public bool HomeTeamWin { get; set; }


        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }

        //[Required]
        //public int WeekId { get; set; }
        //public virtual Week Week { get; set; }


        // TODO #2
        // Need int properties for Home & Away teams
        // Need int properties for Player

       
    }
}
