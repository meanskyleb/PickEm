using PickEm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Models.WeekModels
{
    public class WeekListItem
    {
        public int WeekId { get; set; }
        public int SeasonNumber { get; set; }
        public int SeasonWeek { get; set; }
        public string StadiumName { get; set; }
        public virtual Player User { get; set; }

        //public override int ToInt() => SeasonWeek;
    }
}
