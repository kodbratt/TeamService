
using System;
using System.Collections.Generic;
using statlerwaldorfcorp.teamservice.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(Guid teamId);
        void AddTeam(Team team);
    }
}