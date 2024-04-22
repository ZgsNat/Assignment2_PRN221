using _22_NguyenThaiThinh_Assignment2.DataAccess;
using _22_NguyenThaiThinh_Assignment2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace _22_NguyenThaiThinh_Assignment2.Pages
{
    public class SignInModel : PageModel
    {
        private AccountRepository accountRepository = new AccountRepository();
        public string Error = string.Empty;
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.Clear();
                return new RedirectToPageResult("/Index");
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPost() 
        {
            Account user = null;
            try
            {
                user = accountRepository.GetAccount(Request.Form["txtusername"].ToString(), Request.Form["txtpassword"].ToString());
                if (user == null)
                {
                    throw new Exception("Swrong password!");
                }
                else
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    HttpContext.Session.SetString("Type", user.Type.ToString());
                    HttpContext.Session.SetString("id", user.AccountId.ToString());
                }
            }catch (Exception ex)
            {
               Error =ex.Message;
                return Page();
            }
            return new RedirectToPageResult("/Index");
        }
    }
}
