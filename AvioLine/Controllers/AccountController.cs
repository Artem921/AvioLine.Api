using AvioLine.Clients.Services.Abstract;
using AvioLine.Domain.Entities;
using AvioLine.Domain.Models;
using AvioLine.Domain.Models.Account;
using AvioLine.Domain.Models.JWTToken;
using AvioLine.Interfaces;
using AvioLine.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AvioLine.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly ILogger<AccountController> logger;



		public AccountController(UserManager<User> UserManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
		{
			this.userManager = UserManager;
			this.signInManager = signInManager;
			this.logger = logger;
		}
		/// <summary>
		/// Регестрация пользователя
		/// </summary>
		/// <returns></returns>
		#region Register
		public IActionResult Register()=>View(new RegisterUserViewModel());

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.Email,
                Email= model.Email
                
            };

            using (logger.BeginScope("Создание нового пользователя", model.Email, DateTime.UtcNow.ToLongTimeString()))
            {
                var register_result = await userManager.CreateAsync(user, model.Password);

                if (register_result.Succeeded)
                {
                    logger.LogInformation(DateTime.UtcNow.ToLongTimeString(), model.Email, register_result.Succeeded);
                    logger.LogInformation("Пользователь успешно зарегестрирован", DateTime.UtcNow.ToLongTimeString());

                    await userManager.AddToRoleAsync(user, Role.User);

                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in register_result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                logger.LogWarning("Ошибка при реистрации",string.Join(",",register_result.Errors.Select(error => error.Description)));
            }
            return View(model);
        }

        #endregion

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        #region Login
        public IActionResult Login(string returnUrl)=>View(new LoginUserViewModel { ReturnUrl = returnUrl });
        

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {

            if (!ModelState.IsValid) return View(model);

            var login_result=await signInManager.PasswordSignInAsync(model.UserName, model.Password,model.RememberMe, false);

            if (login_result.Succeeded)
            {
              
                logger.LogInformation("Пользователь успешно вошёл", model.UserName, DateTime.UtcNow.ToLongTimeString());
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
            logger.LogWarning("Пользователь не вошёл", model.UserName, DateTime.UtcNow.ToLongTimeString());

            return View(model);
        }
        #endregion

        public async Task< IActionResult> LogOut()
        {
           await signInManager.SignOutAsync();
            logger.LogInformation("Пользователь вышел", DateTime.UtcNow.ToLongTimeString());
            return RedirectToAction("Index", "Home");
        }
    }
}
