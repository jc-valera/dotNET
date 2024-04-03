using Auth.Core.Common.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Auth.Core.BLL
{
    public class RequestBLL
    {
        public string ServiceUrlApi { get; set; }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                await GetUrlApi();
                var url = $"{ServiceUrlApi}/getAllEmployees";

                HttpResponseMessage response;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                    response = await client.GetAsync(url).ConfigureAwait(false);

                    employees = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener la lista de los empleados, intentelo más tarde.");
            }


            return employees;
        }

        public async Task GetUrlApi()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ServiceUrlApi = config.GetValue<string>("AppConfig:TestSolApi");
        }
    }
}
