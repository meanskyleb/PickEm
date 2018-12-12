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
                    HomeTeam = model.HomeTeam,
                    AwayTeam = model.AwayTeam,
                    HomeTeamId = model.HomeTeamId,
                    AwayTeamId = model.AwayTeamId,
                    PlayerId = model.PlayerId,
                    HomeTeamWin = model.HomeTeamWin,

                    //TODO 3 - Pass the models properties(RHS) to the Game Object
                    //  For example:
                    // GameId = model.GameId
                    
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
                                    GameId = e.GameId,
                                    HomeTeam = (NamesOfTeams)e.HomeTeamId,
                                    AwayTeam = (NamesOfTeams)e.AwayTeamId,
                                    HomeTeamId = e.HomeTeamId,
                                    AwayTeamId = e.AwayTeamId,
                                    HomeTeamWin = e.HomeTeamWin,
                                    PlayerId = e.PlayerId,
                                 
                                    /*
                                  * //TODO 4
                                    HomeTeamId = e.Team.TeamId 
                                     
                                 */   
                                });
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
                        GameId = entity.GameId,
                        HomeTeam = entity.HomeTeam,
                        HomeTeamId = entity.HomeTeamId,
                        AwayTeam = entity.AwayTeam,
                        AwayTeamId = entity.AwayTeamId,
                        HomeTeamWin = entity.HomeTeamWin,
                    };
            }

        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId && e.OwnerId == _userId);

                entity.HomeTeam = model.HomeTeam;
                entity.AwayTeam = model.AwayTeam;
                entity.HomeTeamId = model.HomeTeamId;
                entity.AwayTeamId = model.AwayTeamId;
                entity.PlayerId = model.PlayerId;
                entity.HomeTeamWin = model.HomeTeamWin;

                return ctx.SaveChanges() == 1;
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
