namespace PickEm.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PickEm.WebMVC.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PickEm.WebMVC.Data.ApplicationDbContext context)
        {
            var teams = new List<Team>
            {
                new Team { TeamId = 1, TeamName= NamesOfTeams.Bears, TeamConference = Conference.National, TeamLocation ="Chicago" },
                new Team { TeamId = 2, TeamName = NamesOfTeams.Bengals, TeamConference = Conference.American, TeamLocation = "Cincinnati" },
                new Team { TeamId = 3, TeamName = NamesOfTeams.Bills, TeamConference = Conference.American, TeamLocation = "Buffalo" },
                new Team { TeamId = 4, TeamName = NamesOfTeams.Broncos, TeamConference = Conference.American, TeamLocation = "Denver" },
                new Team { TeamId = 5, TeamName = NamesOfTeams.Browns, TeamConference = Conference.American, TeamLocation = "Cleveland" },
                new Team { TeamId = 6, TeamName = NamesOfTeams.Buccaneers, TeamConference = Conference.National, TeamLocation = "Tampa Bay" },
                new Team { TeamId = 7, TeamName = NamesOfTeams.Cardinals, TeamConference = Conference.National, TeamLocation = "Arizona" },
                new Team { TeamId = 8, TeamName = NamesOfTeams.Chargers, TeamConference = Conference.American, TeamLocation = "San Diego" },
                new Team { TeamId = 9, TeamName = NamesOfTeams.Chiefs, TeamConference = Conference.American, TeamLocation = "Kansas City" },
                new Team { TeamId = 10, TeamName = NamesOfTeams.Colts, TeamConference = Conference.American, TeamLocation = "Indianapolis" },
                new Team { TeamId = 11, TeamName = NamesOfTeams.Cowboys, TeamConference = Conference.National, TeamLocation = "Dallas" },
                new Team { TeamId = 12, TeamName = NamesOfTeams.Dolphins, TeamConference = Conference.American, TeamLocation = "Miami" },
                new Team { TeamId = 13, TeamName = NamesOfTeams.Eagles, TeamConference = Conference.National, TeamLocation = "Philidelphia" },
                new Team { TeamId = 14, TeamName = NamesOfTeams.Falcons, TeamConference = Conference.National, TeamLocation = "Atlanta" },
                new Team { TeamId = 15, TeamName = NamesOfTeams.FortyNiners, TeamConference = Conference.National, TeamLocation = "San Francisco" },
                new Team { TeamId = 16, TeamName = NamesOfTeams.Giants, TeamConference = Conference.National, TeamLocation = "New York" },
                new Team { TeamId = 17, TeamName = NamesOfTeams.Jaguars, TeamConference = Conference.American, TeamLocation = "Jacksonville" },
                new Team { TeamId = 18, TeamName = NamesOfTeams.Jets, TeamConference = Conference.American, TeamLocation = "New York" },
                new Team { TeamId = 19, TeamName = NamesOfTeams.Lions, TeamConference = Conference.National, TeamLocation = "Detroit" },
                new Team { TeamId = 20, TeamName = NamesOfTeams.Packers, TeamConference = Conference.National, TeamLocation = "Green Bay" },
                new Team { TeamId = 21, TeamName = NamesOfTeams.Panthers, TeamConference = Conference.National, TeamLocation = "Carolina" },
                new Team { TeamId = 22, TeamName = NamesOfTeams.Patriots, TeamConference = Conference.American, TeamLocation = "New England" },
                new Team { TeamId = 23, TeamName = NamesOfTeams.Raiders, TeamConference = Conference.American, TeamLocation = "Oakland" },
                new Team { TeamId = 24, TeamName = NamesOfTeams.Rams, TeamConference = Conference.National, TeamLocation = "Los Angeles" },
                new Team { TeamId = 25, TeamName = NamesOfTeams.Ravens, TeamConference = Conference.American, TeamLocation = "Baltimore" },
                new Team { TeamId = 26, TeamName = NamesOfTeams.Redskins, TeamConference = Conference.National, TeamLocation = "Washington" },
                new Team { TeamId = 27, TeamName = NamesOfTeams.Saints, TeamConference = Conference.National, TeamLocation = "New Orleans" },
                new Team { TeamId = 28, TeamName = NamesOfTeams.Seahawks, TeamConference = Conference.National, TeamLocation = "Seattle" },
                new Team { TeamId = 29, TeamName = NamesOfTeams.Steelers, TeamConference = Conference.American, TeamLocation = "Pittsburgh" },
                new Team { TeamId = 30, TeamName = NamesOfTeams.Texans, TeamConference = Conference.American, TeamLocation = "Houston" },
                new Team { TeamId = 31, TeamName = NamesOfTeams.Titans, TeamConference = Conference.American, TeamLocation = "Tennessee" },
                new Team { TeamId = 32, TeamName = NamesOfTeams.Vikings, TeamConference = Conference.National, TeamLocation = "Minnesota" },
            };

            teams.ForEach(t => context.Teams.AddOrUpdate(p => p.TeamName, t));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
