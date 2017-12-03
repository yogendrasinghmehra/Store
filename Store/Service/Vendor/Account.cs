using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Security;
using Store.Web;
using System.Web;

namespace Store.Service.Vendor
{
  public class Account
    {
        

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public Account()
        {
        }

        public Account(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                //return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
                
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public bool  RegisterVendor(string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
             //UserManager.UpdateSecurityStampAsync(user.Id);
            var result = UserManager.Create(user, password);
            if (result.Succeeded)
            {
                SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

               
            }   
            return true;
        }

    }

    
}
