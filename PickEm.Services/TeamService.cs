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

        public IEnumerable<TeamListItem> GetTeams()
        {
            var parsedGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.OwnerId == _userId || e.OwnerId == parsedGuid)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
                                    TeamLocation = e.TeamLocation,
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
                        TeamLocation = entity.TeamLocation,
                        TeamConference = entity.TeamConference
                    };
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
