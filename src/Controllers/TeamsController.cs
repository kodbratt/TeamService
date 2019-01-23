
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statlerwaldorfcorp.teamservice.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace statlerwaldorfcorp.teamservice.controllers
{
    public class TeamsController : Controller
    {
        ITeamRepository repository;
        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public virtual IActionResult GetAllTeams()
        {
            return this.Ok(repository.GetTeams());
        }

        public Task CreateTeam(Team t)
        {
            throw new NotImplementedException();
        }
    }
}