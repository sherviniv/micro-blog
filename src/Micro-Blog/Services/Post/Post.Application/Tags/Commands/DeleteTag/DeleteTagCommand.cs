using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest
    {
        public int Id { get; set; }

        protected DeleteTagCommand()
        {
        }

        public DeleteTagCommand(int id)
        {
            Id = id;
        }
    }
}
