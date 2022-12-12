using GroupWebProject.Models.Interfaces;

namespace GroupWebProject.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUser User {get;}
        public UnitOfWork(IUser user)
        {
            User = user;
        }
    }
}
