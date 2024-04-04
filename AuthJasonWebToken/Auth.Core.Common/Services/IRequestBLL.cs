using Auth.Core.Common.Entities;

namespace Auth.Core.Common.Services
{
    public interface IRequestBLL
    {
        Task<List<Employee>> GetAllEmployees();
    }
}
