using CONNEX.ClassLibraries.Responses;

namespace CONNEX.ClassLibraries.Services
{
    public interface IApiService
    {
        Task<ActionResponse<T>> PostAsync<T, Y>(
            string urlBase,
            Y model);

        Task<ActionResponse<T>> GetAsync<T>(
            string urlBase);
    }
}
