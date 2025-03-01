using ThalesApi.Domain.Models;
using ThalesApi.Domain.Repository;
using ThalesApi.Interfaces;

namespace ThalesApi.Services
{
    public class UserServices : BaseRepository<User>, IUserServices
    {
        public UserServices(IRepository<User> repository) : base(repository)
        {
        }
    }
}
