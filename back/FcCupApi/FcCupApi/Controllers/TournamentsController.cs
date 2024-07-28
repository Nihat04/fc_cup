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
using FcCupApi.DTO;

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
        public async Task<ActionResult<IEnumerable<ShortTournamentDTO>>> GetTournaments()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return tournaments.ConvertAll<ShortTournamentDTO>(tournament => new ShortTournamentDTO(tournament));
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
        public async Task<ActionResult<Tournament>> PostTournament(TournamentDTO tournament)
        {
            var newTournament = new Tournament { Name = tournament.Name, ImageUrl = tournament.ImageUrl, BannerImage = tournament.BannerImage, StartDate = tournament.StartDate, EndDate = tournament.EndDate };

            _context.Tournaments.Add(newTournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournament", new { id = newTournament.Id }, newTournament);
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

        [HttpPost("{id}@playerId={playerId}&clubId={clubId}")]
        public async Task<ActionResult<Tournament>> PostTournamentPlayer(int id, int playerId, int clubId)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound("Tournament doesn't exist");
            }

            var player = await _context.Players.FindAsync(playerId);

            if (player == null) 
            {
                return NotFound("Player doesn't exist");
            }

            var club = await _context.Clubs.FindAsync(clubId);

            if(club == null)
            {
                return NotFound("Club doesn't exist");
            }

            if (tournament.Players == null)
            {
                tournament.Players = new List<TournamentPlayer>();
            }

            if (player.Tournaments == null)
            {
                player.Tournaments = new List<TournamentPlayer>();
            }

            if( club.Tournaments == null)
            {
                club.Tournaments = new List<TournamentPlayer>();
            }

            var newTournamentPlayer = new TournamentPlayer() { Player = player, Tournament = tournament, Club = club };
            var tournamentPlayer = _context.TournamentPlayers.Add(newTournamentPlayer);
            await _context.SaveChangesAsync();

            tournament.Players.Add(tournamentPlayer.Entity);
            player.Tournaments.Add(tournamentPlayer.Entity);
            club.Tournaments.Add(tournamentPlayer.Entity);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
