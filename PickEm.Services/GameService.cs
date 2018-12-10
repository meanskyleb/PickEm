using PickEm.Data;
using PickEm.Models.GameModels;
using PickEm.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    
                                }
                                );
                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id && e.OwnerId == _userId);
                return
                    new GameDetail
                    {
                        WeekId = entity.WeekId,
                        HomeTeam = entity.HomeTeam,
                        AwayTeam = entity.AwayTeam,
                        HomeTeamWin = entity.HomeTeamWin,
                    };
            }

        }

        

        public bool DeleteGame(int gameid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameid && e.OwnerId == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
