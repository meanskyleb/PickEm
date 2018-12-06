using PickEm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.TeamModels
{
    public class TeamListItem
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public Conference TeamConference { get; set; }

        public override string ToString() => TeamName;
    }
}
