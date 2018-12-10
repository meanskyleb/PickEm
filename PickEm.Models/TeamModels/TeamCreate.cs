using PickEm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.TeamModels
{
    public class TeamCreate
    {
        [Required]
        public NamesOfTeams TeamName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string TeamCity { get; set; }

        [Required]
        public Conference TeamConference { get; set; }

        public override string ToString() => TeamCity;
    }
}
