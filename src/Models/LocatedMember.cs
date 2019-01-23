
using System;

namespace StatlerWaldorfCorp.TeamService.Models
{
    public class LocatedMember
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LocationRecord LastLocation { get; set; }
    }
}