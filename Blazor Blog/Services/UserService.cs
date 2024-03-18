using Blazor_Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Blog.Services
{
    public class UserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public async Task<LoggedInUser?> LoginAsync(LoginModel model)
        {
            var dbUser = await _context.Users
                            .AsNoTracking()
                            .FirstOrDefaultAsync(u => u.Email == model.UserName);
            if (dbUser is not null)
            {
                // Login success
                return new LoggedInUser(dbUser.Id, $"{dbUser.FirstName} {dbUser.LastName}".Trim());
            }
            else
            {
                // Login failed
                return null;
            }
        }
    }
}
