using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.API.Base;
using Post.Application.BlogPosts.Commands.CreatePost;
using Post.Application.BlogPosts.Commands.DeletePost;
using Post.Application.BlogPosts.Commands.UpdatePost;
using Post.Application.BlogPosts.Queries.GetPost;
using Post.Application.BlogPosts.Queries.GetPostsByTag;
using Post.Application.BlogPosts.Queries.GetPostsList;
using System.Threading.Tasks;

namespace Post.API.Controllers
{
    public class PostsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> GetPost(int id)
        {
            return Ok(await _mediator.Send(new GetPostQuery(id)));
        }

        [HttpGet("[action]", Name = "GetPosts")]
        public async Task<ActionResult<PostsVM>> GetPosts(string search = null)
        {
            return Ok(await _mediator.Send(new GetPostsListQuery(search)));
        }

        [HttpGet("[action]/{id}", Name = "GetPostsByTagId")]
        public async Task<ActionResult<PostsVM>> GetPostsByTagId(int id)
        {
            return Ok(await _mediator.Send(new GetPostsByTagQuery(id)));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePostCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePostCommand(id)));
        }
    }
}
