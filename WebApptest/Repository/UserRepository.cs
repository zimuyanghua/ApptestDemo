using WebApptest.Context.UnitOfWork;
using WebApptest.Context;

namespace WebApptest.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(WebApptestContext dbContext) : base(dbContext)
        {
        }
    }
}
