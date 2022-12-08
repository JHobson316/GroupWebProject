using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Data;
using GroupWebProject.Models.Interfaces;

namespace GroupWebProject.Models
{
    public class Users : IUser
    {
        private readonly GroupContext _context;

        public Users(GroupContext context)
        {
            _context = context;
        }

        public ICollection<AppUser> GetUsers()
        {
            return _context.Users.ToList();
        }
        public AppUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
