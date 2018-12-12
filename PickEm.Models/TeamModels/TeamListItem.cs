using PickEm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.TeamModels
{
    public class TeamListItem
    {
        [Display(Name = "Team Id")]
        public int TeamId { get; set; }

        [Display(Name = "Team Name")]
        public NamesOfTeams TeamName { get; set; }

        [Display(Name = "Team Location")]
        public string TeamLocation { get; set; }

        [Display(Name = "Team Conference")]
        public Conference TeamConference { get; set; }
    }
}
