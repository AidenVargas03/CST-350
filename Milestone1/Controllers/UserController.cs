using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Filters;
using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Controllers
{
    public class UserController : Controller
    {
        static UserCollection users = new UserCollection();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(string Username, string password)
        {

            int userId = users.CheckCredentials(Username, password);

            if (userId > 0)
            {
                UserModel userData = users.GetUserById(userId);

                string userJson = ServiceStack.Text.JsonSerializer.SerializeToString(userData);
                HttpContext.Session.SetString("User", userJson);

                return View("LoginSuccess", userData);
            }
            else
            {
                UserModel userData = new UserModel { Username = Username };
                return View("LoginFailure", userData);
            }
        }

  

        [SessionCheckFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return View("Index");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        public IActionResult ProcessRegister(RegisterViewModel registerViewModel)
        {
            UserModel user = new UserModel();
            user.Username = registerViewModel.Username;
            user.SetPassword(registerViewModel.Password);
            user.Groups = "";
            foreach (var group in registerViewModel.Groups)
            {
                if (group.IsSelected)
                {
                    user.Groups += group.GroupName + ",";
                }
            }
            user.Groups = user.Groups.TrimEnd(',');
            users.AddUser(user);
            return View("Index");
        }

        public IActionResult StartGame()
        {
            return View(); 
        }

    }
}
