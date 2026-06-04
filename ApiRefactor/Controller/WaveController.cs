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

        [HttpGet(Name = "GetWaves")]
         public async Task<ActionResult<object>> Get()
         {
            _logger.LogInformation("Retrieving wave details");
            var waves = await _waveService.GetAllWavesAsync();            
            return Ok(new { items = waves });

        }

      /*  [HttpGet(Name = "GetWaves")]
        [Authorize]
        public ActionResult<Wave> GetAllWaves([FromQuery] int pageSize = 1, [FromQuery] int PageNumber = 1)
        {
            var waves = new Waves();
            _logger.LogInformation("Retrieving wave details");
            var waveItems = waves.Items
                                .Skip((PageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return Ok(new { items = waveItems });
        }*/


       /*[HttpGet("{id:guid}", Name = "GetWaveById")]
        [Authorize]
        public ActionResult<Wave> GetWaveById(Guid id)
        {
            var wave = new Wave(id);
            _logger.LogInformation("Retrieving wave details by id");           

            return Ok(wave);
        }

        [HttpPut(Name = "UpsertWave")]
        [Authorize(Policy = "Write")]
        public ActionResult<Wave> UpsertWave([FromBody] Wave wave)
        {
            if (wave == null)
            {
                _logger.LogInformation("Request doesnt have wave details");
                throw new ValidationException();                
            }

            wave.Save();
            _logger.LogInformation("Wave details saved successfully");
            return Ok();

            //return CreatedAtRoute("GetWaveById", new { id = wave.Id }, wave);
        }
       */

        

    }
}
