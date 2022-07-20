using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAMCandidateTestAPI_MarkSeno.Data.Interface;
using IAMCandidateTestModels_MarkSeno;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IAMCandidateTestAPI_MarkSeno.Data
{
    public class AnimalRepo: IAnimalRepo
    {
        private readonly IAMCandidateDbContext _dbContext;
        private readonly ILogger<MineralRepo> _logger;

        public AnimalRepo(ILogger<MineralRepo> logger, IAMCandidateDbContext dbContext)
        {            
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// List of Animals
        /// </summary>
        /// <returns>IEnumerable<Animal></returns>
        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            try
            {
                return await _dbContext.Animals.OrderBy(a => a.CommonName).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message,
                   this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);
            }

            return null;
        }

        /// <summary>
        /// Animal Detail
        /// </summary>
        /// <param name="id">parameter id</param>
        /// <returns>Animal</returns>
        public async Task<Animal> GetAnimalDetail(string id)
        {
            try
            {
                return await _dbContext.Animals.FirstOrDefaultAsync(x=> x.ID.ToString() == id);
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
