using System.Net;

namespace CatalogService.WebApi.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
