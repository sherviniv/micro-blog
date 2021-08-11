using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.API.Base;
using Post.Application.Tags.Commands.AssignTag;
using Post.Application.Tags.Commands.CreateTag;
using Post.Application.Tags.Commands.DeleteTag;
using Post.Application.Tags.Commands.UpdateTag;
using Post.Application.Tags.Queries.GetTag;
using Post.Application.Tags.Queries.GetTagsList;
using System.Threading.Tasks;

namespace Post.API.Controllers
{
    public class TagsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagVM>> GetTag(int id)
        {
            return Ok(await _mediator.Send(new GetTagQuery(id)));
        }

        [HttpGet("[action]", Name = "GetTags")]
        public async Task<ActionResult<TagsVM>> GetTags(string search)
        {
            return Ok(await _mediator.Send(new GetTagsListQuery(search)));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create([FromBody] CreateTagCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateTagCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}", Name = "Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteTagCommand(id)));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> UpdatePostTags([FromBody] AssignTagCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
