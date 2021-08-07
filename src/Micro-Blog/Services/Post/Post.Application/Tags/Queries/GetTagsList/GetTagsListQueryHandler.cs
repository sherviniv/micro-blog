using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Post.Application.Tags.Queries.GetTag;

namespace Post.Application.Tags.Queries.GetTagsList
{
    public class GetTagsListQueryHandler : IRequestHandler<GetTagsListQuery, TagsVM>
    {
        private readonly IMapper _mapper;
        private readonly IPostDbContext _context;

        public GetTagsListQueryHandler(
            IPostDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TagsVM> Handle(GetTagsListQuery request, CancellationToken cancellationToken)
        {
            TagsVM vm = default;
            var result = _context.Tags.AsQueryable();

            var search = request.SearchTerm;
            if (string.IsNullOrEmpty(search))
            {
                result = result.Where(t => t.Title.Contains(search)
                                        || t.Description.Contains(search));
            }
            vm = new(
                await result.ProjectTo<TagVM>(_mapper.ConfigurationProvider)
                            .ToListAsync());

            return vm;
        }
    }
}
