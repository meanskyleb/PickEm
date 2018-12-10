using PickEm.Data;
using PickEm.Models.TeamModels;
using PickEm.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickEm.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    OwnerId = _userId,
                    TeamName = model.TeamName,
                    TeamCity = model.TeamCity,
                    TeamConference = model.TeamConference
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
                                    TeamCity = e.TeamCity,
                                    TeamConference = e.TeamConference,
                                }
                                );
                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        TeamCity = entity.TeamCity,
                        TeamConference = entity.TeamConference
                    };
            }
        }

        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);

                entity.TeamName = model.TeamName;
                entity.TeamCity = model.TeamCity;
                entity.TeamConference = model.TeamConference;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int teamid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == teamid && e.OwnerId == _userId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
