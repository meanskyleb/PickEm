using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public int WeekId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public NamesOfTeams HomeTeam { get; set; }

        [Required]
        public NamesOfTeams AwayTeam { get; set; }

        [Required]
        public bool HomeTeamWin { get; set; }


        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
        
        //public virtual Week Week { get; set; }
        // TODO 1
        // Add FK IDs of HomeTeamId & AwayTeamId
        // Add virtual property for Team
        // Add FK ID for Player
        // Add virtual property for Player
        // Do a migration
    }
}
