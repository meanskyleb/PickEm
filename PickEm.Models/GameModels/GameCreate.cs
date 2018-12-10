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
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string HomeTeam { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string AwayTeam { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
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
