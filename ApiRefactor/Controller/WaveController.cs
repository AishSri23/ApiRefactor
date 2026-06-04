using ApiRefactor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRefactor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaveController : ControllerBase
    {
        [HttpGet(Name = "GetWaves")]
        public ActionResult<object> Get()
        {
            var waves = new Waves();
            return Ok(new { items = waves.Items });
        }


        [HttpGet("{id:guid}", Name = "GetWaveById")]
        public ActionResult<Wave> GetWaveById(Guid id)
        {
            var wave = new Wave(id);
            if (wave.Name == null)
            {
                return NotFound();
            }

            return Ok(wave);
        }

        [HttpPut(Name = "UpsertWave")]
        public ActionResult<Wave> UpsertWave([FromBody] Wave wave)
        {
            if (wave == null)
            {
                return BadRequest();
            }

            wave.Save();
            return Ok();

            //return CreatedAtRoute("GetWaveById", new { id = wave.Id }, wave);
        }



    }
}
