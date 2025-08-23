using CursoNetMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

namespace CursoNetMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {

            if (ModelState.IsValid)
            {
                var result = await signInManager
                    .PasswordSignInAsync(model.Email, model.Password, false,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Redirect(returnUrl ?? "/");
                }

                ModelState.AddModelError("", "Intento de login no valido");

            }
            return View();

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }

            return View(model);

        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                    return View();
                }
                ModelState.AddModelError("", "El rol ya existe");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Assign()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(string userName, string roleName) 
        {

            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                ModelState.AddModelError("", "Usuario no encontrado");
                return View();
            }

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                ModelState.AddModelError("", "El rol no existe");
                return View();
            }

            var result = await userManager.AddToRoleAsync(user, roleName);

            return View();

            // --> lista de roles  roleManager.Roles.ToList();
            
            /// --> valida que el usuario este en ese rol userManager.IsInRoleAsync(
            
            // --> lista de usuarios userManager.Users.ToList()

            // -> crear un rol roleManager.CreateAsync(new IdentityRole("Role"))

           // --> userManager.GetUsersInRoleAsync("Admin")
            
        }



        /* Practica
         * 
         *  @if (User.IsInRole("Admin"))
                        {
                            
                        }
        *
         *  1.- mostrar u ocultar una opcion en el menu llamada Admin roles esta opcion solamente la puden ver
         *  los usuarios con el Rol de Admin usar fucnion de arriba 
         *  
         *  2.- una vez entrando ahi nos mostrara la lista de roles que tenemos
         *  
         *  3.- crear vista detalle de los roles y en esta vista poder agregar un usuario a ese rol
         *  (Tomar en cuenta validaciones de que el usuario exista, no este ya en ese rol y que el rol exista)
         * 
         *  4.- crear funcionalidad para poder agregar roles
         * 
         *  5.- en la vista de editar el rol ver una lista
         *  de los usuarios en el rol
         * 
         * 
         * 
         * 
         */





    }
}
