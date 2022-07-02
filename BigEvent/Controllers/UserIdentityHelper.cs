using BigEvent.Data;
using BigEvent.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BigEvent.Controllers
{
    public class UserIdentityHelper
    {
        private ApplicationDbContext _dbContext;

        private UserManager<ApplicationUser> UserManager;
        private readonly ClaimsPrincipal _currentUser;

        public UserIdentityHelper
        (ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            ClaimsPrincipal currentUser)
        {
            _dbContext = dbContext;
            UserManager = userManager;
            _currentUser = currentUser;
        }

        public ApplicationUser ApplicationUser { get { return UserManager.GetUserAsync(_currentUser).Result; } }

        public int BasicUserId
        {
            get
            {
                return _dbContext.BasicUsers
                    .FirstOrDefault(u => u.ApplicationDbContextId.Equals(ApplicationUser.Id)).BasicUserId;
            }
        }

        public BasicUser BasicUser
        {
            get
            {
                return _dbContext.BasicUsers
                    .FirstOrDefault(u => u.ApplicationDbContextId.Equals(ApplicationUser.Id));
            }
        }

        public bool isBasicUser()
        {
            return (ApplicationUser.Type == UserType.BasicUser);
        }



        //TODO add
    }
}
