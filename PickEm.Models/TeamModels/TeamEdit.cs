using PickEm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.TeamModels
{
    public class TeamEdit
    {
        public int TeamId { get; set; }
        public NamesOfTeams TeamName { get; set; }
        public string TeamCity { get; set; }
        public Conference TeamConference { get; set; }
    }
}
