using CONNEX.ClassLibraries.Responses;
using CONNEX.Data.Services;
using Newtonsoft.Json;
using System.Text;

namespace CONNEX.ClassLibraries.Services
{
    public class ApiService : IApiService
    {
        public async Task<ActionResponse<T>> PostAsync<T, Y>(
            string urlBase,
            Y model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8,
                    "application/json");
                var client = new HttpClient();
                client.DefaultRequestHeaders.TransferEncodingChunked = false;
                var response = await client.PostAsync(urlBase, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new ActionResponse<T>
                    {
                        WasSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Message = "Correcto",
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ActionResponse<T>> GetAsync<T>(
            string urlBase)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.TransferEncodingChunked = false;
                var response = await client.GetAsync(urlBase);

                if (!response.IsSuccessStatusCode)
                {
                    return new ActionResponse<T>
                    {
                        WasSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Message = "Correcto",
                    Result = newRecord,
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
