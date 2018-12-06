using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Data
{
    public class Week
    {
        [Key]
        public int WeekId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public int SeasonNumber { get; set; }

        [Required]
        public int SeasonWeek { get; set; }

        [Required]
        public string StadiumName { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual Player User { get; set; }
    }
}
