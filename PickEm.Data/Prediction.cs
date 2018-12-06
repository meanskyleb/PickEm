using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Data
{
    public class Prediction
    {
        [Key]
        public int PredictionId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool PredictedHomeWin { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player User { get; set; }
    }
}
