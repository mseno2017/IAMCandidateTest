using IAMCandidateTestModels_MarkSeno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAMCandidateTestAPI_MarkSeno.Data.Interface
{
    public interface IMineralRepo
    {
        Task<IEnumerable<Mineral>> GetMinerals();
        Task<Mineral> GetMineralDetail(string id);
    }
}
