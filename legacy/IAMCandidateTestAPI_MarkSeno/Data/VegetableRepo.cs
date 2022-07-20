using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAMCandidateTestAPI_MarkSeno.Data.Interface;
using IAMCandidateTestModels_MarkSeno;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IAMCandidateTestAPI_MarkSeno.Data
{
    public class VegetableRepo: IVegetableRepo
    {
        private readonly IAMCandidateDbContext _dbContext;
        private readonly ILogger<MineralRepo> _logger;

        public VegetableRepo(ILogger<MineralRepo> logger, IAMCandidateDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// List of Vegetables
        /// </summary>
        /// <returns>IEnumerable<Vegetable></returns>
        public async Task<IEnumerable<Vegetable>> GetVegetables()
        {
            try
            {
                return await _dbContext.Vegetables.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);

                throw ex;
            }
        }

        /// <summary>
        /// Vegetable Detail
        /// </summary>
        /// <param name="id">parameter id</param>
        /// <returns>Vegetable</returns>
        public async Task<Vegetable> GetVegetableDetail(string id)
        {
            try
            {
                return await _dbContext.Vegetables.FirstOrDefaultAsync(x => x.ID.ToString() == id);
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
