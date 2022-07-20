using IAMCandidateTest.ClientService.Interface;
using IAMCandidateTest.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace IAMCandidateTestUI_MarkSeno.ClientService
{
    public class MineralSvc: IMineralSvc
    {
        private readonly string _baseUri;
        HttpClient client;

        public MineralSvc()
        {
            _baseUri = WebConfigurationManager.AppSettings["baseUri"];
            client = new HttpClient();
        }

        public async Task<IEnumerable<Mineral>> GetMinerals()
        {
            using (var apiresp = await client.GetAsync(_baseUri + $"mineral/minerals"))
            {
                try
                {
                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Mineral>>(response);

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<Mineral> GetMineralDetail(string id)
        {
            try
            {
                using (var apiresp = await client.GetAsync(_baseUri + $"mineral/mineraldetail?id={id}"))
                {

                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Mineral>(response);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
