using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using statlerwaldorfcorp.teamservice.Models;
using StatlerWaldorfCorp.TeamService;
using Xunit;


namespace statlerwaldorfcorp.teamservice.integration
{
    public class SimpleIntegrationTests
    {
        private readonly TestServer testServer;
        private readonly HttpClient testClient;
        private readonly Team zombieTeam;
        public SimpleIntegrationTests()
        {
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            testClient = testServer.CreateClient();

            zombieTeam = new Team(){ID = Guid.NewGuid(), Name="Zombie"};
        }

        [Fact]
        public async void TestTeamPostAndGet()
        {
            StringContent stringContent = new StringContent(
                JsonConvert.SerializeObject(zombieTeam),
                UnicodeEncoding.UTF8,"application/json");
            
            HttpResponseMessage postResponse = await testClient.PostAsync("/teams", stringContent);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await testClient.GetAsync("/teams");
            getResponse.EnsureSuccessStatusCode();

            string raw = await getResponse.Content.ReadAsStringAsync();

            List<Team> teams = JsonConvert.DeserializeObject<List<Team>>(raw);

            Assert.Equal(1, teams.Count);
            Assert.Equal("Zombie", teams[0].Name);




        }
    }
}
