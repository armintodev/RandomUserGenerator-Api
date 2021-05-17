using System.Threading.Tasks;

namespace UserGenerator.Api.Http
{
    public interface IClientHelper
    {
        Task<TEntity> Detail<TEntity>(string requestUri);
    }
}
