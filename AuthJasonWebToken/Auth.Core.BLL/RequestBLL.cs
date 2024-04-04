using Auth.Core.Common.Entities;
using Auth.Core.Common.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace Auth.Core.BLL
{
    public class RequestBLL : IRequestBLL
    {
        //public string ServiceUrlApi { get; set; }
        public AppSettings AppSettings;

        public RequestBLL(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                //await GetUrlApi();
                //var url = $"{ServiceUrlApi}/getAllEmployees";
                var url = $"{AppSettings.SecretKey}/getAllEmployees";

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

        //public async Task GetUrlApi()
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    ServiceUrlApi = config.GetValue<string>("AppConfig:TestSolApi");
        //}
    }
}
