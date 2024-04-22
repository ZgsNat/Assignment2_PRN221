using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public SignUpModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = new Account { Type = true }; // Thiết lập giá trị mặc định cho trường Type

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer c = new Customer() {
                ContactName = Account.FullName,
                Password = Account.Password,
            };
            _context.Customers.Add(c);
            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
