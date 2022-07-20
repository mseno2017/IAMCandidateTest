using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using IAMCandidateTest.ClientService.Interface;
using IAMCandidateTest.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IAMCandidateTestUI_MarkSeno.ClientService
{
    public class AnimalSvc : IAnimalSvc
    {
        private readonly string _baseUri;
        HttpClient client;

        public AnimalSvc()
        {
            _baseUri = WebConfigurationManager.AppSettings["baseUri"];
            client = new HttpClient();
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            try
            {
                using (var apiresp = await client.GetAsync(_baseUri + $"animal/animals"))
                {

                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Animal>>(response);

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Animal> GetAnimalDetail(string id)
        {
            try
            {
                using (var apiresp = await client.GetAsync(_baseUri + $"animal/animaldetail?id={id}"))
                {

                    string response = await apiresp.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Animal>(response);

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
