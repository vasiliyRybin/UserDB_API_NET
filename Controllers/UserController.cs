using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDB_API_NET.Models;
using UserDB_API_NET.Validation;


namespace UserDB_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController(TestUserDataContext context) : ControllerBase
    {
        private readonly TestUserDataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Take(1000).ToListAsync();
        }

        /// <summary>
        /// Get user by his TaxId
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        [HttpGet("Amount/{Amount}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int Amount)
        {
            return await _context.Users.Take(Amount).ToListAsync();
        }

        [HttpGet("{TaxId}")]
        public async Task<ActionResult<User>> GetUser(long? TaxId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.TaxId == TaxId);

            if (user == null) return NotFound("No user with such TaxID"); 

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var isValid = UserValidation.CheckUserInput(user);
            if (!isValid.Key) return BadRequest(isValid.Value);

            var userRecord = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.TaxId == user.TaxId);
            if (userRecord != null) return Conflict($"User with TaxID {user.TaxId} already exists");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { user.TaxId }, user);
        }

        [HttpPut("{TaxId}")]
        public async Task<IActionResult> PutUser(long? TaxId, User user)
        {
            var isValid = UserValidation.CheckUserInput(user);
            if (!isValid.Key) return BadRequest(isValid.Value);

            var userRecord = await _context.Users.FirstOrDefaultAsync(x => x.TaxId == TaxId);
            if (userRecord == null) return NotFound($"User with TaxID {TaxId} not found");

            try
            {
                _context.Users.Remove(userRecord);
                await _context.SaveChangesAsync();

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User info updated.");
        }

        [HttpDelete("{TaxId}")]
        public async Task<IActionResult> DeleteUser(long? TaxId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.TaxId == TaxId);
            if (user == null) return NotFound("No user with such TaxID"); 

            _context.Entry(user).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return Ok($"User with TaxId {TaxId} was successfully removed");
        }
    }
}