using Entities;
using Logic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UI_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserLogic _userLogic;

        public AccountController()
        {
            _userLogic = new UserLogic();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        private User GetGoogleProfile()
        {
            var identity = HttpContext.GetOwinContext().Authentication.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie).Result;

            if (identity == null || identity.Claims == null)
            {
                return null;
            }

            var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var givenNameClaim = identity.Claims.FirstOrDefault(c => c.Type == "urn:google:name");
            var familyNameClaim = identity.Claims.FirstOrDefault(c => c.Type == "urn:google:surname");
            var idClaim = identity.Claims.FirstOrDefault(c => c.Type == "urn:google:id");
            var phoneNumberClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone);

            if (emailClaim == null || givenNameClaim == null || familyNameClaim == null || idClaim == null)
            {
                return null;
            }

            var googleProfile = new User
            {
                Email = emailClaim.Value,
                Firstname = givenNameClaim.Value,
                Lastname = familyNameClaim.Value,
                Uid = idClaim.Value,
                Phone = phoneNumberClaim != null ? phoneNumberClaim.Value : null
            };

            return googleProfile;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginCallback()
        {
            // Obtener el perfil del usuario de Google
            var googleProfile = GetGoogleProfile();

            if (googleProfile != null)
            {
                // Verificar si el usuario ya existe en tu base de datos
                var user = _userLogic.GetUserByEmail(googleProfile.Email);

                if (user == null)
                {
                    // Si el usuario no existe, crea una nueva cuenta en tu sistema
                    var newUser = new User
                    {
                        Uid = googleProfile.Uid,
                        Firstname = googleProfile.Firstname,
                        Lastname = googleProfile.Lastname,
                        Email = googleProfile.Email,
                        Phone = googleProfile.Phone,
                        Role = "Usuario", // Asigna un rol predeterminado o el que corresponda
                        Active = true // Define el estado del usuario como activo o inactivo
                    };

                    _userLogic.Add(newUser);
                }

                // Autenticar al usuario en tu aplicación
                FormsAuthentication.SetAuthCookie(googleProfile.Email, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Error al autenticar con Google. Inténtalo nuevamente.");
                return View("Login");
            }
        }
    }
}
