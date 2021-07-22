using System;
using System.Net;

namespace Post.Application.Common.Exceptions
{
    public class MicroBlogException : Exception
    {
        public string Code { get; }
        public HttpStatusCode StatusCode { get; set; }
        public MicroBlogException()
        {
        }

        public MicroBlogException(string code)
        {
            Code = code;
        }

        public MicroBlogException(string message, HttpStatusCode httpStatusCode, params object[] args) : this(string.Empty, message, httpStatusCode, args)
        {
        }

        public MicroBlogException(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, params object[] args) : this(null, code, message, args)
        {
            StatusCode = httpStatusCode;
        }

        public MicroBlogException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public MicroBlogException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
