
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using statlerwaldorfcorp.teamservice.controllers;
using statlerwaldorfcorp.teamservice.Models;
using StatlerWaldorfCorp.TeamService.Persistence;
using Xunit;

namespace statlerwaldorfcorp.teamservice.tests
{
    public class TeamsControllerTests
    {
        

        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            TeamsController controller = new TeamsController(new MemoryTeamRepository());
            var teams = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult).Value;
            var rawTeams = new List<Team>(teams);
            Assert.Equal(2, rawTeams.Count);
        }

        [Fact]
        public async void CreateTeamAddsTeamToList()
        {
            TeamsController controller = new TeamsController(new MemoryTeamRepository());

            var teams = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sample");
            var result = controller.CreateTeam(t);

            var newTeamsRaw = (IEnumerable<Team>) (controller.GetAllTeams() as ObjectResult).Value;

            List<Team> newTeams = new List<Team>(newTeamsRaw);

            Assert.Equal(newTeams.Count, original.Count +1);
            var sampleTeam = newTeams.FirstOrDefault(target => target.Name == "sample");
            Assert.NotNull(sampleTeam);
        }
    }
}