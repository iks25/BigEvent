using System.Collections.Generic;
using System.Linq;
using BigEvent.Data;
using BigEvent.Models;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {

        private readonly ApplicationDbContext _dbContext;


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MessagesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET
        public IActionResult Index()
        {
            var identityHelper = new UserIdentityHelper(_dbContext, _userManager, User);


            if (identityHelper.isBasicUser())
            {

                var currentUserId = identityHelper.BasicUser.BasicUserId;


                var messagesList =
                    _dbContext.UserMessages
                        .Include(userMessage => userMessage.Message)
                        .Where(userMessage => userMessage.BasicUserId == currentUserId);


                var fakeMessageList = new List<UserMessage>()
                {
                    //new UserMessage()
                    //{
                    //    Id = 1,
                    //    Message = new Message() {Content = "event was edited"},
                    //},
                    //new UserMessage()
                    //{
                    //    Id = 2,
                    //    Message = new Message() {Content = "opopopopop"}
                    //},
                    //new UserMessage()
                    //{
                    //    Id = 3,
                    //    Message = new Message() {Content = "dupa jasoi fsijoj dijo jojo"},
                    //    HasBeenRead = true
                    //}
                };
                return View(fakeMessageList);

                //todo check this

            }

            var message = "you can not use that side";
            return RedirectToAction(
                "ExpectedError",
                "Home",
                new { message = message });
        }
        
        
        public IActionResult Notification()
        {
            var identityHelper = new UserIdentityHelper(_dbContext, _userManager, User);


            if (identityHelper.isBasicUser())
            {

                var currentUserId = identityHelper.BasicUser.BasicUserId;


                var messagesList =
                    _dbContext.UserMessages
                        .Include(userMessage => userMessage.Message)
                        .ThenInclude(m=>m.Event)
                        .Where(userMessage => userMessage.BasicUserId == currentUserId)
                        .ToList();

                var messagesListVm = new List<NotificationViewModel>();
                foreach (var userMessage in messagesList)
                {
                    messagesListVm.Add
                    (
                        new NotificationViewModel(userMessage)
                    );
                }

                
                return View(messagesListVm);

                //todo check this

            }

            var message = "you can not use that side";
            return RedirectToAction(
                "ExpectedError",
                "Home",
                new { message = message });
        }


        [HttpDelete]
        public IActionResult Delete(int messageId)
        {
            var identityHelper = new UserIdentityHelper(_dbContext, _userManager, User);

            if (!identityHelper.isBasicUser()) return BadRequest();

            var currentUserId = identityHelper.BasicUser.BasicUserId;
            //todo handle deleteMessage                

            return Ok();

        }

        [HttpPut]
        public IActionResult HasBeenRead(int messageId)
        {
            var identityHelper = new UserIdentityHelper(_dbContext, _userManager, User);

            if (!identityHelper.isBasicUser()) return BadRequest();

            var currentUserId = identityHelper.BasicUser.BasicUserId;
            //todo handle hasBeenRead                

            return Ok();

        }
    }
}
