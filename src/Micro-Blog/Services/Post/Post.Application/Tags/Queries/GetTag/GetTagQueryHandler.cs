using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.BlogPosts.Queries.GetPost;
using Post.Application.BlogPosts.Queries.GetPostsList;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.Tags.Queries.GetTag
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, TagVM>
    {
        private readonly IMapper _mapper;
        private readonly IPostDbContext _context;

        public GetTagQueryHandler(
            IPostDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TagVM> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("tag_not_found",
                   $"tag with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            return _mapper.Map<TagVM>(entity);
        }
    }
}
