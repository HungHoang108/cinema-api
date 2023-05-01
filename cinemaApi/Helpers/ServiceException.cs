using System.Net;

namespace cinemaApi.Helpers
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public override string Message { get; }

        public ServiceException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static ServiceException NotFound(string message = "Item with provided Id is not found")
        {
            return new ServiceException(HttpStatusCode.NotFound, message);
        }

        public static ServiceException CreationError(string message = "Failed to create entity")
        {
            return new ServiceException(HttpStatusCode.UnprocessableEntity, message);
        }

    }
}