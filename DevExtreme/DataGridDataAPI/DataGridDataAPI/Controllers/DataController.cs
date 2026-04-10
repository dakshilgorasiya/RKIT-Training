using DataGridDataAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace DataGridDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private static List<Post> posts = new PostRepository().posts;

        [HttpGet("GetAllPost")]
        public IActionResult GetAllPosts()
        {
            return Ok(posts);
        }

        [HttpGet("GetPostsWithPage")]
        public IActionResult GetPostsWithPage([FromQuery] int take, [FromQuery] int skip)
        {
            PaginationResponse res = new PaginationResponse()
            {
                TotalCount = posts.Count(),
                Data = posts.Skip(skip).Take(take)
            };

            return Ok(res);
        }

        [HttpGet("GetPostById")]
        public IActionResult GetPostById(int id)
        {
            Post res = posts.Where(p => p.id == id).FirstOrDefault();
            return Ok(res);
        }

        [HttpPost("AddRow")]
        public IActionResult AddRow([FromBody]Post post)
        {
            int idToAdd = posts[posts.Count - 1].id + 1;
            Post postToAdd = new Post();
            postToAdd.id = idToAdd;
            postToAdd.userId = post.userId;
            postToAdd.title = post.title;
            postToAdd.body = post.body;
            posts.Add(postToAdd);
            return Ok();
        }

        [HttpDelete("DeleteRow")]
        public IActionResult DeleteRow([FromQuery] int id)
        {
            posts = posts.Where(p => p.id != id).ToList();
            return Ok();
        }

        [HttpPut("UpdateRow")]
        public IActionResult UpdateRow([FromBody] Post post)
        {
            Post? existing = posts.Where(p => p.id == post.id).FirstOrDefault();

            if (existing == null)
            {
                return NotFound();
            }

            if (post.title != null)
                existing.title = post.title;

            if (post.body != null)
                existing.body = post.body;

            return Ok();
        }
    }
    public class PaginationResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<Post> Data { get; set; }
    }
}
