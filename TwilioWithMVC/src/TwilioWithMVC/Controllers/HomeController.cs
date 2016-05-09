using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TwilioWithMVC.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace TwilioWithMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetMessages()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            //var allMessages = Message.GetMessages();
            return View(_db.Messages.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            message.User = currentUser;
            message.Send();
            _db.Messages.Add(message);
            _db.SaveChanges();
            return Json(message);
        }

        public async Task<IActionResult> GetContacts()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Contacts.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            contact.User = currentUser;
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return Json(contact);
        }
    }
}
