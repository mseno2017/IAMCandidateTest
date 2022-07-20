using IAMCandidateTestAPI_MarkSeno.Data.Interface;
using IAMCandidateTestModels_MarkSeno;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAMCandidateTestAPI_MarkSeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/xml")]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IAnimalRepo _animalRepo;

        public AnimalController(ILogger<AnimalController> logger, IAnimalRepo animalRepo)
        {
            _logger = logger;
            _animalRepo = animalRepo;
        }

        [HttpGet]
        [Route("animals")]
        [ProducesResponseType(typeof(List<Animal>), 200)]        
        public async Task<IActionResult> GetAnimals()
        {
            try
            {
                var response = await _animalRepo.GetAnimals();

                if (response == null)
                    return NotFound("No records found."); 

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Error. Class Name {0} Method Name {1} Details {2}",
                       this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);

                return BadRequest("An exception error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("animaldetail")]
        [ProducesResponseType(typeof(Animal), 200)]
        public async Task<IActionResult> GetAnimalDetails(string id)
        {
            try
            {
                var response = await _animalRepo.GetAnimalDetail(id);

                if (response == null)
                    return NotFound("No records found.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Error. Class Name {0} Method Name {1} Details {2}",
                       this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);

                return BadRequest("An exception error occurred while processing your request.");
            }
        }
    }
}
