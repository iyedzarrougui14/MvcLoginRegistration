using Microsoft.AspNetCore.Mvc;
using MvcLoginRegistration.Models;
using XAct.Library.Settings;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        private readonly OurDbContext _dbContext;

        public object UserId { get; private set; }

        public AccountController(OurDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var userAccounts = _dbContext.userAccount.ToList();
            return View(userAccounts);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                _dbContext.userAccount.Add(account);
                _dbContext.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var usr = _dbContext.userAccount.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (usr != null)
            {
                usr.Email = user.Email;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.Password = user.Password;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "username or password is wrong.");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (UserId != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Login");

            }
        }
    }
}