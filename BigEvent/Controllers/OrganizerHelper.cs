using BigEvent.Data;
using BigEvent.Models;
using System.Linq;
using System.Security.Claims;

namespace BigEvent.Controllers
{
    public class OrganizerHelper
    {


        public static Organizer GetCurrnetOrganizer(ClaimsPrincipal currentUser, ApplicationDbContext dbContext)
        {
            var userId = currentUser.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId    

            var organize = dbContext.Organizers.Single(user => user.ApplicationDbContextId == userId);
            return organize;
        }
    }
}
