using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Data
{
    public enum NamesOfTeams
    {
        Bears = 1,
        Bengals,
        Bills,
        Broncos,
        Browns,
        Buccaneers,
        Cardinals,
        Chargers,
        Chiefs,
        Colts,
        Cowboys,
        Dolphins,
        Eagles,
        Falcons,
        FortyNiners,
        Giants,
        Jaguars,
        Jets,
        Lions,
        Packers,
        Panthers,
        Patriots,
        Raiders,
        Rams,
        Ravens,
        Redskins,
        Saints,
        Seahawks,
        Steelers,
        Titans,
        Texans,
        Vikings,
    }
    public enum Conference { American = 1, National }
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public NamesOfTeams TeamName { get; set; }

        [Required]
        public string TeamCity { get; set; }

        [Required]
        public Conference TeamConference { get; set; }
    }
}
