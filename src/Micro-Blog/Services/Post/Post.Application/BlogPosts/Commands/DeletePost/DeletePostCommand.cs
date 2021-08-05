using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.BlogPosts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }

        protected DeletePostCommand()
        {
        }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
