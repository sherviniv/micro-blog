using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.API.Base;
using Post.Application.BlogPosts.Commands.CreatePost;
using System.Threading.Tasks;

namespace Post.API.Controllers
{
    public class PostController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePostCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
