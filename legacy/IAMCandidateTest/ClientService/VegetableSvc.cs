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
    public class VegetableSvc: IVegetableSvc
    {
        private readonly string _baseUri;
        HttpClient client;

        public VegetableSvc()
        {
            _baseUri = WebConfigurationManager.AppSettings["baseUri"];
            client = new HttpClient();
        }

        public async Task<IEnumerable<Vegetable>> GetVegetables()
        {
            using (var apiresp = await client.GetAsync(_baseUri + $"vegetable/vegetables"))
            {
                try
                {
                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Vegetable>>(response);

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<Vegetable> GetVegetableDetail(string id)
        {
            try
            {
                using (var apiresp = await client.GetAsync(_baseUri + $"vegetable/vegetabledetail?id={id}"))
                {

                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Vegetable>(response);

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
