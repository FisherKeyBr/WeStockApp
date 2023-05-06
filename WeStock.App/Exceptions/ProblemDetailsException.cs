using System.Net;

namespace WeStock.App.Exceptions
{
    public class ProblemDetailsException : Exception
    {
        public HttpStatusCode HttpStatus { get; }

        public ProblemDetailsException(string message, HttpStatusCode httpStatus) 
            : base(message)
        {
            HttpStatus = httpStatus;
        }

        public ProblemDetailsException(string message, Exception inner, HttpStatusCode httpStatus)
            : base(message, inner)
        {
            HttpStatus = httpStatus;
        }

        public static string GetHttpDescriptionBy(HttpStatusCode status)
        {
            if (HttpErrorMessages.Messages.TryGetValue(status, out var title))
            {
                return title;
            }

            return Enum.GetName(typeof(HttpStatusCode), status) 
                ?? HttpErrorMessages.HttpStatusNotFound;
        }
    }
}
