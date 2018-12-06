using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Data
{
    public enum Conference { American = 1, National }
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string TeamCity { get; set; }

        [Required]
        public Conference TeamConference { get; set; }
    }
}
