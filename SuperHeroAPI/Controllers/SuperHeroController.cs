//using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services;
using SuperHeroAPI.Models;
//using Microsoft.EntityFrameworkCore;
//using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SuperHeroController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public SuperHeroController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Superhero>> GetSuperHeroes()
        {
            return await _mongoDBService.GetSuperheroesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHero(string id)
        {
            var dbHero = await _mongoDBService.GetSuperheroAsync(id);
            if (dbHero == null)
            {
                return NotFound();
            }
            return dbHero;
        }

        //todo add get for single superhero

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero([FromBody] Superhero superhero)
        {
            await _mongoDBService.CreateSuperHeroAsync(superhero);
            //return 201 status code response
            return CreatedAtAction(nameof(GetSuperHeroes), new { id = superhero.Id }, superhero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(string id, Superhero updatedSuperhero)
        {
            //find whether hero exists in database already
            //var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            var dbHero = await _mongoDBService.GetSuperheroAsync(id);
            if(dbHero == null) {
                //return BadRequest("Hero not found.");
                return NotFound();
            }
            
            updatedSuperhero.Id = dbHero.Id;

            await _mongoDBService.UpdateSuperheroAsync(id, updatedSuperhero);

            //return Ok(await _context.SuperHeroes.ToListAsync());
            return NoContent();
        }


        [HttpDelete("{id}")]
        //[Route("...")]
        public async Task<IActionResult> DeleteSuperHero(string id)
        {
            var dbHero = await _mongoDBService.GetSuperheroAsync(id);
            if (dbHero == null)
            {
                return NotFound();
            }

            await _mongoDBService.DeleteSuperHeroAsync(id);

            return NoContent();
        }
    }
}
