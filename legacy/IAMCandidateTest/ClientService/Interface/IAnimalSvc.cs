using IAMCandidateTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAMCandidateTest.ClientService.Interface
{
    public interface IAnimalSvc
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimalDetail(string id);
    }
}
