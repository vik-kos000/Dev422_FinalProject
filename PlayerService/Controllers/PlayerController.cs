using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerService.Data;
using PlayerService.Model;

namespace PlayerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext context;

        public PlayerController(PlayerContext context)
        {
            this.context = context;
        }

        //retrieve al list of players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            return await context.Players.ToListAsync();
        }

        //Retrieve details for a specific player
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = await context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }
            return player;
        }


        //Draft a player to a team (teamId)
        [HttpPut("{id}/draft/{teamId}")]
        public async Task<ActionResult<Player>> Draft(int id, int teamId )
        {
            var player = await context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound($"Player with ID {id} not found!");
            }
            if (player.IsDrafted)
            {
                return Conflict($"Player {id} is already dreagted by team {player.TeamId}");
            }

            player.IsDrafted = true;
            player.TeamId = teamId;

            await context.SaveChangesAsync();
            return Ok(player);
        }

        //Release a player from team is dreafted = false and teamId = null
        [HttpPut("{id}/release")]
        public async Task<ActionResult<Player>> Release(int id)
        {
            var player = await context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound($"Player with ID {id} not found!");
            }

            if (!player.IsDrafted)
            {
                return BadRequest($"Player {id} is not currently drafted!");
            }
            player.IsDrafted = false;
            player.TeamId = null;

            await context.SaveChangesAsync();
            return Ok(player);
        }
    }
}
