
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.LocationClient
{
    public class  HttpLocationClient : ILocationClient
    {
        public string URL {get;set;}
        public HttpLocationClient(string url)
        {
            this.URL = url;   
        }

        public async Task<LocationRecord> GetLatestForMember(Guid memberId)
        {
            LocationRecord locationRecord = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

                HttpResponseMessage response = await httpClient.GetAsync(string.Format("/locations/{0}/latest", memberId));

                if(response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    locationRecord = JsonConvert.DeserializeObject<LocationRecord>(json);
                }
            }
            return locationRecord;
        }

    }
}
