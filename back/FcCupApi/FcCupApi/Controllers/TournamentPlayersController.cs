using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FcCupApi.Contexts;
using FcCupApi.Models;

namespace FcCupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentPlayersController : ControllerBase
    {
        private readonly FcCupDbContext _context;

        public TournamentPlayersController(FcCupDbContext context)
        {
            _context = context;
        }

        // GET: api/TournamentPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentPlayer>>> GetTournamentPlayers()
        {
            return await _context.TournamentPlayers.ToListAsync();
        }

        // GET: api/TournamentPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentPlayer>> GetTournamentPlayer(int id)
        {
            var tournamentPlayer = await _context.TournamentPlayers.FindAsync(id);

            if (tournamentPlayer == null)
            {
                return NotFound();
            }

            return tournamentPlayer;
        }

        // PUT: api/TournamentPlayers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentPlayer(int id, TournamentPlayer tournamentPlayer)
        {
            if (id != tournamentPlayer.TournamentId)
            {
                return BadRequest();
            }

            _context.Entry(tournamentPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentPlayerExists(id))
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

        // POST: api/TournamentPlayers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentPlayer>> PostTournamentPlayer(TournamentPlayer tournamentPlayer)
        {
            _context.TournamentPlayers.Add(tournamentPlayer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TournamentPlayerExists(tournamentPlayer.TournamentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTournamentPlayer", new { id = tournamentPlayer.TournamentId }, tournamentPlayer);
        }

        // DELETE: api/TournamentPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentPlayer(int id)
        {
            var tournamentPlayer = await _context.TournamentPlayers.FindAsync(id);
            if (tournamentPlayer == null)
            {
                return NotFound();
            }

            _context.TournamentPlayers.Remove(tournamentPlayer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentPlayerExists(int id)
        {
            return _context.TournamentPlayers.Any(e => e.TournamentId == id);
        }
    }
}
