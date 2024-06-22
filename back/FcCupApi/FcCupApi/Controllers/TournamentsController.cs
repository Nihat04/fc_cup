using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FcCupApi.Contexts;
using FcCupApi.Models;
using FcCupApi.DBO;

namespace FcCupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly FcCupDbContext _context;

        public TournamentsController(FcCupDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortTournament>>> GetTournaments()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return tournaments.ConvertAll<ShortTournament>(tournament => new ShortTournament(tournament));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        [HttpPut("{id}")]
        private async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        private async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.Id == id);
        }
    }
}
