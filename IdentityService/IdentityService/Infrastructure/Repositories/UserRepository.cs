using IdentityService.ApplicationService.DTOs;
using IdentityService.Domain.Entities;
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

            return _dbContext.Users.Any(u => u.Email == email && u.PasswordHash == password);

        }


        public string RegisterUser(RegisterDTo registerRequest)
        {
            UsersEntity usersEntity = new UsersEntity();
            usersEntity.Email = registerRequest.Email;
            usersEntity.PasswordHash = registerRequest.PasswordHash;
            usersEntity.FirstName = registerRequest.FirstName;
            usersEntity.LastName = registerRequest.LastName;

            _dbContext.Users.Add(usersEntity);
            _dbContext.SaveChanges();

            return "User registered successfully";
        }

        public string ForgotPassword(string email)
        {
            bool ischeckemail = _dbContext.Users.Any(u => u.Email == email);
            if (ischeckemail)
                return "mail sent successfully";
            else
                return "email not found";
        }

        public string ChangePassword(Changepassword changepassword)
        {
            UsersEntity usersEntity = _dbContext.Users.FirstOrDefault(a => a.Email.Equals(changepassword.Email, StringComparison.OrdinalIgnoreCase)) ?? null;
            if (usersEntity != null)
            {
                usersEntity.PasswordHash = changepassword.NewPassword;
                _dbContext.Users.Update(usersEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                return "Email not found";
            }
            return "password changed sucessfully";

        }
    }
}
