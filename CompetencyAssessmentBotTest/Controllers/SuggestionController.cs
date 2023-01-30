using CompetencyAssessmentBotTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompetencyAssessmentBotTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionRepository suggestionRepository;

        public SuggestionController(ISuggestionRepository suggestionRepository)
        {
            this.suggestionRepository = suggestionRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSuggestion()
        {
            try
            {
                return Ok(await suggestionRepository.GetSuggestion());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error retreiving data from db");
                //throw;
            }

        }

        //Added Route template with constraint
        [HttpGet("{SNO}")]
        public async Task<ActionResult<Suggestions>> GetSuggestion(int SNO)
        {
            try
            {
                var result = await suggestionRepository.GetSuggestion(SNO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error retreiving data from db");
                //throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Suggestions>> CreateSuggestion(Suggestions suggestions)
        {
            try
            {
                if (suggestions == null)
                {
                    return BadRequest();
                }

                var createdloc = await suggestionRepository.AddSuggestion(suggestions);
                //name of is used to avoid error while calling injected methods.
                return Ok(createdloc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error updating db");
                //throw;
            }
        }

        [HttpPut("{SNO}")]
        public async Task<ActionResult<Suggestions>> UpdateSuggestion(int SNO, Suggestions suggestions)
        {
            try
            {
                if (SNO != suggestions.SNo)
                {
                    return BadRequest("SNo mismatch");
                }

                var suggestionUpdate = await suggestionRepository.GetSuggestion(SNO);
                if (suggestionUpdate == null)
                {
                    return NotFound($"location with SNO {SNO} not found");
                }

                return await suggestionRepository.UpdateSuggestion(suggestions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error updating data on db");
                //throw;
            }
        }

    }
}
