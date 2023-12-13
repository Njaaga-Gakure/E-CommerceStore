using System.Net;

namespace E_CommerceStore.Models.DTOS
{
    public class ResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = string.Empty;
        public object Response { get; set; } = default!;   

    }
}
