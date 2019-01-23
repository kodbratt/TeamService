using System;
using System.Collections.Generic;
using System.Linq;
using statlerwaldorfcorp.teamservice.Models;


namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            if(teams == null)
            {
                teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> teamss)
        {
            teams = teamss;
        }
        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public Team GetTeam(Guid teamId)
        {
            return teams.Where(t => t.ID == teamId).First();
        }

        public IEnumerable<Team> GetTeams()
        {
           return teams;
        }
    }
}