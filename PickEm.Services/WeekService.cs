using PickEm.Data;
using PickEm.Models.WeekModels;
using PickEm.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Services
{
    public class WeekService
    {
        private readonly Guid _userId;

        public WeekService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWeek(WeekCreate model)
        {
            var entity =
                new Week()
                {
                    OwnerId = _userId,
                    SeasonNumber = model.SeasonNumber,
                    SeasonWeek = model.SeasonWeek,
                    StadiumName = model.StadiumName,
                    PlayerId = model.PlayerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Weeks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WeekListItem> GetWeeks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weeks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new WeekListItem
                                {
                                    WeekId = e.WeekId,
                                    SeasonNumber = e.SeasonNumber,
                                    SeasonWeek = e.SeasonWeek,
                                    StadiumName = e.StadiumName,
                                    PlayerId = e.PlayerId,
                                }
                                );
                return query.ToArray();
            }
        }

        public WeekDetail GetWeekById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Weeks
                        .Single(e => e.WeekId == id && e.OwnerId == _userId);
                return
                    new WeekDetail
                    {
                        WeekId = entity.WeekId,
                        SeasonNumber = entity.SeasonNumber,
                        SeasonWeek = entity.SeasonWeek,
                        StadiumName = entity.StadiumName,
                        PlayerId = entity.PlayerId,
                    };
            }

        }

        public bool UpdateWeek(WeekEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Weeks
                        .Single(e => e.WeekId == model.WeekId && e.OwnerId == _userId);

                entity.SeasonNumber = model.SeasonNumber;
                entity.SeasonWeek = model.SeasonWeek;
                entity.StadiumName = model.StadiumName;
                entity.PlayerId = model.PlayerId; 

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWeek(int weekid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Weeks
                        .Single(e => e.WeekId == weekid && e.OwnerId == _userId);

                ctx.Weeks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
