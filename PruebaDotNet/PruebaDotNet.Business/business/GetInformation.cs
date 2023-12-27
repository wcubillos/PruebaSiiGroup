using Microsoft.Extensions.Configuration;
using PruebaDotNet.Models.Entities;
using PruebaDotNet.Models.Interface;

namespace PruebaDotNet.Business.business
{
    public class GetInformation : Interoperability
    {
        private readonly IConfiguration _configuration;
        public GetInformation(IConfiguration iconfiguration)
        {
            _configuration = iconfiguration;
        }


        public async Task<List<Memployees>> Consume()
        {
            try
            {
                string apiUrl = "https://dummy.restapiexample.com/api/v1/employees";

                using (HttpClient client = new HttpClient())
                {
                    // Realiza una solicitud GET a la API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verifica si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee y procesa el contenido JSON de la respuesta
                        var responseData = await response.Content.ReadAsAsync<ApiResponse<List<Memployees>>>();

                        // devuelve los datos obtenidos
                        return responseData.Data;
                    }
                    else
                    {
                        return new List<Memployees>();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<Memployees>();
            }
        }
    }
}
