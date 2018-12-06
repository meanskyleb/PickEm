using PickEm.Data;
using PickEm.Models;
using PickEm.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    GroupName = model.GroupName,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlayerListItem
                                {
                                    PlayerId = e.PlayerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    GroupName = e.GroupName,
                                    CreatedUtc = e.CreatedUtc
                                }
                                );
                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerById(int id)
        {
             using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == id && e.OwnerId == _userId);
                return
                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        GroupName = entity.GroupName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
           
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.GroupName = model.GroupName;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(int playerid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerid && e.OwnerId == _userId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
