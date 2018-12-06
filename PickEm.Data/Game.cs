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
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public bool HomeTeamWin { get; set; }

        public virtual Week Week { get; set; }
    }
}
