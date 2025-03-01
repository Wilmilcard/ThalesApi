using ThalesApi.Domain.Models;
using ThalesApi.Domain.Repository;

namespace ThalesApi.Interfaces
{
    public interface IUserServices : IRepository<User>
    {
    }
}
