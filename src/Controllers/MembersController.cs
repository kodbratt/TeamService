
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statlerwaldorfcorp.teamservice.Models;
using StatlerWaldorfCorp.TeamService.LocationClient;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService.Controllers
{
    public class MembersController : Controller
    {
        private ITeamRepository repository;
        private ILocationClient locationClient;

        public MembersController(ITeamRepository repo, ILocationClient client) 
        {
            repository = repo;
            locationClient = client;
        }

        [HttpGet]
        [Route("/teams/{teamId}/[controller]/{memberId}")]
        public async virtual Task<IActionResult> GetMember(Guid teamId, Guid memberId)
        {
            Team team = repository.GetTeam(teamId);

            if(team == null)
            {
                return this.NotFound();
            }else
            {
                var q = team.Members.Where(m => m.ID == memberId);
                if(q.Count() < 1)
                {
                    return this.NotFound();
                }else{
                    Member member = (Member)q.First();

                    return this.Ok(new LocatedMember
                    {
                        ID = member.ID,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        LastLocation = await this.locationClient.GetLatestForMember(memberId)
                    });
                }

            }
                


         }
    }
}