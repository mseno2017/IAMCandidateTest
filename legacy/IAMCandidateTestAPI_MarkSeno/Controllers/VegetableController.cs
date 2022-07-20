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
    public class VegetableController : Controller
    {
        private readonly ILogger<VegetableController> _logger;
        private readonly IVegetableRepo _vegetableRepo;

        public VegetableController(ILogger<VegetableController> logger, IVegetableRepo vegetableRepo)
        {
            _logger = logger;
            _vegetableRepo = vegetableRepo;
        }

        [HttpGet]
        [Route("vegetables")]
        [ProducesResponseType(typeof(List<Vegetable>), 200)]
        public async Task<IActionResult> GetVegetables()
        {
            try
            {
                var response = await _vegetableRepo.GetVegetables();

                if (response == null)
                {
                    return NotFound("No records found.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Error. Class Name {0} Method Name {1}",
                       this.GetType()?.Name, System.Reflection.MethodBase.GetCurrentMethod()?.ReflectedType?.Name);

                return BadRequest("Error occured.");
            }
        }

        [HttpGet]
        [Route("vegetabledetail")]
        [ProducesResponseType(typeof(Vegetable), 200)]
        public async Task<IActionResult> GetVegetableDetail(string id)
        {
            try
            {
                var response = await _vegetableRepo.GetVegetableDetail(id);

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
