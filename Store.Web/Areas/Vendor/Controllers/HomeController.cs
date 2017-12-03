using Microsoft.AspNet.Identity.Owin;
using Store;
using Store.Web.Areas.Vendor.ViewModels.Home;
using System.Threading.Tasks;
using System.Web.Mvc;
using Store.Service.Vendor;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Store.Web.Areas.Vendor.Controllers
{
    [Authorize(Roles ="Vendor")]
    public class HomeController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                //return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

            }
            private set
            {
                _signInManager = value;
            }
        }
    
        public ApplicationUserManager UserManager
        {
          
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Vendor/Home
       
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendor/Home
        [AllowAnonymous]
        public ActionResult Register()
        {           
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //UserManager.UpdateSecurityStampAsync(user.Id);
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Vendor");
                    SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);


                }
               
                //Account ac = new Account();
                // ac.RegisterVendor(model.Email, model.Password);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
      
    }
}