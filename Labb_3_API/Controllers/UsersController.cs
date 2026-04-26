using Labb_3_API.DTO;
using Labb_3_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext _ctx;

        public UsersController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserInformation>>> GetAllUsers()
        {
            var users = await _ctx.Users.Select(u => new GetUserInformation
            (
                u.FirstName,
                u.LastName,
                u.PhoneNumber,
                u.Email
            )).ToListAsync();

            return Ok(users);

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserInterests>> GetUsersIntrestsById(int id)
        {

            var user = await _ctx.Users.Where(u => u.Id == id).Select(u => new GetUserInterests(
                u.FirstName,
                u.LastName,
                u.PhoneNumber,
                u.Email,
                u.UserInterests.Select(ui => ui.Interest.Title)
                )).FirstOrDefaultAsync();

            if(user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
          
        }

        [HttpGet("{id}/links")]
        public async Task<ActionResult<UserLinks>> GetUsersLinksById(int id)
        {
            var user = await _ctx.Users
        .Where(u => u.Id == id)
        .Select(u => new UserLinks(
            u.FirstName,
            u.LastName,
            u.Links.Select(l => new GetLinks(
                l.Url,
                l.Interest.Title
            ))
        ))
        .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);

            
        }

        [HttpPost("{userId}/Interests")]
        public async Task<IActionResult> AddInterestToUserWithId(int userId,AddInterestToUser dto)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(p => p.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            var interest = await _ctx.Interests.FirstOrDefaultAsync(i => i.Id == dto.interestId);
            if(interest == null)
            {
                return NotFound("Interest not found");
            }

            var checkUserInterest = await _ctx.UserInterests.AnyAsync(ui => ui.UserId == userId && ui.InterestId == dto.interestId);
            if (checkUserInterest)
            {
                return Conflict("User already have this interest");
            }

            var userInterst = new UserInterest
            {
                UserId = userId,
                InterestId = dto.interestId
            };

            await _ctx.UserInterests.AddAsync(userInterst);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

       

        [HttpPost("{id}/links")]
        public async Task<IActionResult>AddInterestLinkToUser(int id,AddLinkToUser dto)
        {
            var link = new Link
            {
                UserId = id,
                Url = dto.url,
                InterestId = dto.InterestID
            };

            await _ctx.Links.AddAsync(link);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsersLinksById), new { id = id }, link);
            


        }

    }
}
