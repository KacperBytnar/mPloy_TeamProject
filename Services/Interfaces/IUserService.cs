using mPloy_TeamProjectG5.Models;

namespace mPloy_TeamProjectG5.Services.Interfaces
{
    public interface IUserService
    {
        public List<AppUser> GetAllUsers();
        //public void CreateUser(AppUser user);
        public AppUser GetUserById(int id);
        public void EditUser(AppUser user);




    }
}
