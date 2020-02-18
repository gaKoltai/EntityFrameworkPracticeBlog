using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkPracticeBlog.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersAndPosts()
        {
            var users = await _context.Users.Include(user => user.Posts).ToArrayAsync();
            var response = users.Select(user => new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                posts = user.Posts.Select(post => post.Content)
            });

            return Ok(response);
        }
    }
}