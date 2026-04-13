using IdentityService.Infrastructure.DBContext;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _dbContext;
        public UserRepository(IdentityDbContext dbContext)

        {
            _dbContext = dbContext;
        }

        public bool AuthriseUser(string email, string password)
        {
            var connected = _dbContext.Database.CanConnect();
            if (connected)
                return _dbContext.Users.Any(u => u.Email == email && u.PasswordHash == password);
            else
                throw new Exception("Database connection failed");
        }
    }
}
