using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResfulAPI.Models;

namespace ResfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly database_SWP391_Auto99_version31Context _context;

        public BlogController(database_SWP391_Auto99_version31Context context)
        {
            _context =context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            Blog? blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound($"Blog {id} has not existed");
            }

            return blog;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> PutBlog(int id, Blog updatedBlog)
        {
            if (id != updatedBlog.BlogId)
            {
                return BadRequest($"Blog {updatedBlog.BlogId} doesn't match with id");
            }

            _context.Entry(updatedBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetBlog), new {id = updatedBlog.BlogId }, updatedBlog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound($"Blog {id} doesn't existed");
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return $"Blog with id {id} has been deleted";
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
