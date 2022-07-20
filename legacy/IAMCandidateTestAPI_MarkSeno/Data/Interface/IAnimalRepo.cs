using IAMCandidateTestModels_MarkSeno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAMCandidateTestAPI_MarkSeno.Data.Interface
{
    public interface IAnimalRepo
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimalDetail(string id);
    }
}
