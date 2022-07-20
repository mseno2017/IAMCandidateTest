using Dapper;
using IAMCandidateTestModels_MarkSeno;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IAMCandidateTestAPI_MarkSeno.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IAMCandidateTestAPI_MarkSeno.Data
{
    public class MineralRepo: IMineralRepo
    {
        private readonly IAMCandidateDbContext _dbContext;
        private readonly ILogger<MineralRepo> _logger;

        public MineralRepo(ILogger<MineralRepo> logger, IAMCandidateDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// List of Minirals
        /// </summary>
        /// <returns>IEnumerable<Mineral></returns>
        public async Task<IEnumerable<Mineral>> GetMinerals()
        {
            try
            {
                return await _dbContext.Minerals.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                     this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);

                throw ex;
            }
        }

        /// <summary>
        /// Mineral Detail
        /// </summary>
        /// <param name="id">parameter id</param>
        /// <returns>Mineral</returns>
        public async Task<Mineral> GetMineralDetail(string id)
        {
            try
            {
                return await _dbContext.Minerals.FirstOrDefaultAsync(x => x.ID.ToString() == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                   this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);
            }

            return null;
        }
    }
}
