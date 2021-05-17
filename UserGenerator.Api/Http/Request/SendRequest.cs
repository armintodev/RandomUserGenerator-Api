using System.Threading.Tasks;
using UserGenerator.Api.DTOs;

namespace UserGenerator.Api.Http.Request
{
    public class SendRequest
    {
        private readonly IClientHelper _client;
        private readonly string BaseAddress = "https://randomuser.me";
        private string _requestUri = "/api";

        public SendRequest()
        {
            _client = new ClientHelper(BaseAddress);
        }

        public async Task<CreateUserResult> SendAsync()
        {
            return await _client.Detail<CreateUserResult>(_requestUri);
        }

        public async Task<CreateUserResult> SendAsync(string param)
        {
            return await _client.Detail<CreateUserResult>(_requestUri += param);
        }
    }
}
