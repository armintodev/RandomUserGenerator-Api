using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UserGenerator.Api.Http
{
    internal class ClientHelper : IClientHelper
    {
        private readonly string _baseAddress;
        public ClientHelper(string baseAddress)
        {
            _baseAddress = baseAddress;
        }
        public async Task<TEntity> Detail<TEntity>(string requestUri)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var detail = await client.GetFromJsonAsync<TEntity>(requestUri).ConfigureAwait(false);
            return detail;
        }
    }
}
