using ApiRefactor.Models;
using ApiRefactor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiRefactor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaveController(ILogger<WaveController> logger, WaveService waveService) : ControllerBase
    {

        private readonly ILogger<WaveController> _logger = logger;

        private readonly WaveService _waveService = waveService;

       /* [HttpGet(Name = "GetWaves")]
         public async Task<ActionResult<object>> Get()
         {
            _logger.LogInformation("Retrieving wave details");
            var waves = await _waveService.GetAllWavesAsync();            
            return Ok(new { items = waves });

        }
       */

       [HttpGet(Name = "GetWaves")]
       [Authorize]
        public async Task<ActionResult<Wave>> GetAllWaves([FromQuery] int pageSize = 1, [FromQuery] int pageNumber = 1)
        {
            
            _logger.LogInformation("Retrieving wave details");
            var waves = await _waveService.GetAllWavesAsync(pageSize, pageNumber);
            return Ok(new { items = waves });
        }


      [HttpGet("{Id:guid}", Name = "GetWaveById")]
      [Authorize]
        public async Task<ActionResult<Wave>> GetWaveById(Guid Id)
        {
            
            _logger.LogInformation("Retrieving wave details by id");
            var wave = await _waveService.GetWavesByIdAsync(Id);           

            return Ok(wave);
        }

        [HttpPut(Name = "UpsertWave")]
       [Authorize(Policy = "Write")]
        public async Task<ActionResult> UpsertWave([FromBody] Wave wave)
        {
            if (wave == null)
            {
                _logger.LogInformation("Request doesnt have wave details");
                throw new ValidationException();                
            }

            var result = await _waveService.SaveWaveAsync(wave);
            if (result == Guid.Empty)
            {
                _logger.LogInformation("Wave details save is not successful");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("Wave details saved successfully");
                return Ok();
            }
            
        }
      

        

    }
}
