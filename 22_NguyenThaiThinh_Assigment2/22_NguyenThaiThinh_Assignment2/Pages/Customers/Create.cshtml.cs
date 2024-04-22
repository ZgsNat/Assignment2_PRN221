using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public CreateModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Accounts == null || Account == null)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
