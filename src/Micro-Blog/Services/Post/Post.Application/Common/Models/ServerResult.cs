using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Common.Models
{
    public class ServerResult
    {
        public ServerResult()
        {
        }

        public ServerResult(string message = "")
        {
            Message = message;
        }

        public static ServerResult Exception(string message, string status = "exception", IDictionary<string, string[]> errors = default)
        {
            return new()
            {
                Message = message,
                Status = status,
                Errors = errors
            };
        }

        protected string Status { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }

}
