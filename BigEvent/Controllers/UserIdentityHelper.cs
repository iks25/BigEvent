using BigEvent.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BigEvent.Controllers
{
    public class UserIdentityHelper
    {
        private ApplicationDbContext _dbContext;

        private UserManager<ApplicationUser> UserManager;
        private readonly ClaimsPrincipal _currentUser;

        public UserIdentityHelper(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, ClaimsPrincipal currentUser)
        {
            _dbContext = dbContext;
            UserManager = userManager;
            _currentUser = currentUser;
        }

        public ApplicationUser ApplicationUser { get { return UserManager.GetUserAsync(_currentUser).Result; } }

        public bool isBasicUser()
        {
            return (ApplicationUser.Type == UserType.BasicUser);

        }

        //TODO add
    }
}
