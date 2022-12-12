using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Data;
using Microsoft.AspNetCore.Identity;

namespace GroupWebProject.Models.Interfaces
{
    public interface IUser
    {
        ICollection<AppUser> GetUsers();
        AppUser GetUser(string id);
    }
}
