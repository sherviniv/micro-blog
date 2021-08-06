using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Tags.Queries.GetTag
{
    public class GetTagQuery : IRequest<TagVM>
    {
        public int Id { get; set; }

        public GetTagQuery(int id)
        {
            Id = id;
        }
    }
}
