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
    public class MineralController : Controller
    {
        private readonly ILogger<MineralController> _logger;
        private readonly IMineralRepo _mineralRepo;

        public MineralController(ILogger<MineralController> logger, IMineralRepo mineralRepo)
        {
            _logger = logger;
            _mineralRepo = mineralRepo;
        }

        [HttpGet]
        [Route("minerals")]
        [ProducesResponseType(typeof(List<Mineral>), 200)]
        public async Task<IActionResult> GetMinerals()
        {
            try
            {
                var response = await _mineralRepo.GetMinerals();

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
        [Route("mineraldetail")]
        [ProducesResponseType(typeof(Mineral), 200)]
        public async Task<IActionResult> GetMineralDetails(string id)
        {
            try
            {
                var response = await _mineralRepo.GetMineralDetail(id);

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
