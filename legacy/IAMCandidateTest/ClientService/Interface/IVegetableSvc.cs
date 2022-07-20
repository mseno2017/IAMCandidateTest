using IAMCandidateTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAMCandidateTest.ClientService.Interface
{
    public interface IVegetableSvc
    {
        Task<IEnumerable<Vegetable>> GetVegetables();
        Task<Vegetable> GetVegetableDetail(string id);
    }
}
