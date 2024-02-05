// using Random.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Random.Controllers;
//
// public class UserController : Controller
// {
//     private readonly ILogger<UserController> _logger;
//     private MyContext _context;
//
//     public UserController(ILogger<UserController> logger, MyContext context)
//     {
//         _logger = logger;
//         _context = context;
//     }
//
//
//     [HttpGet("")]
//     public IActionResult LogReg()
//     {
//         LogRegView logRegModels = new LogRegView()
//         {
//             NewUser = new User(),
//             NewLogin = new LoginUser()
//         };
//         return View("LogReg", logRegModels);
//     }
//
//
//     [HttpPost("users/create")]
//     public IActionResult Register(User newUser)
//     {
//         if (ModelState.IsValid)
//         {
//             PasswordHasher<User> hasher = new PasswordHasher<User>();
//             newUser.Password = hasher.HashPassword(newUser, newUser.Password);
//             _context.Add(newUser);
//             _context.SaveChanges();
//             HttpContext.Session.SetInt32("UserId", newUser.UserId);
//             HttpContext.Session.SetString("FirstName", newUser.FirstName);
//             return RedirectToAction("AllProjects", "Project");
//         }
//
//         LogRegView logRegModels = new LogRegView()
//         {
//             NewUser = newUser,
//             NewLogin = new LoginUser()
//         };
//         return View("LogReg", logRegModels);
//     }
//
//
//     [HttpPost("users/login")]
//     public IActionResult Login(LoginUser newLogin)
//     {
//         if (ModelState.IsValid)
//         {
//             User? userInDb = _context.Users.FirstOrDefault(u => u.Email == newLogin.LoginEmail);
//             if (userInDb == null)
//             {
//                 ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
//                 LogRegView logRegModels = new LogRegView()
//                 {
//                     NewUser = new User(),
//                     NewLogin = newLogin
//                 };
//                 return View("LogReg", logRegModels);
//             }
//
//             PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
//             var result =
//                 hasher.VerifyHashedPassword(newLogin, userInDb.Password,
//                     newLogin.LoginPassword);
//             if (result == 0)
//             {
//                 ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
//                 LogRegView logRegModels = new LogRegView()
//                 {
//                     NewUser = new User(),
//                     NewLogin = newLogin
//                 };
//                 return View("LogReg", logRegModels);
//             }
//
//             HttpContext.Session.SetInt32("UserId", userInDb.UserId);
//             HttpContext.Session.SetString("FirstName", userInDb.FirstName);
//             Console.WriteLine($"Userid before login redirect: {userInDb.UserId}");
//             return RedirectToAction("AllProjects", "Project");
//         }
//         else
//         {
//             ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
//             LogRegView logRegModels = new LogRegView()
//             {
//                 NewUser = new User(),
//                 NewLogin = newLogin
//             };
//             return View("LogReg", logRegModels);
//         }
//     }
//
//
//     [HttpPost("ProcessLogout")]
//     public IActionResult ProcessLogout()
//     {
//         HttpContext.Session.Clear();
//         return RedirectToAction("LogReg");
//     }
// }