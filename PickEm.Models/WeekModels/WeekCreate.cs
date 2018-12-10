using PickEm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.WeekModels
{
    public class WeekCreate
    {
        [Required]
        public int SeasonNumber { get; set; }

        [Required]
        public int SeasonWeek { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string StadiumName { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
