using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public IndexModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }
        public Account account { get; set; } = default!;
        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts.ToListAsync();
            }
        }
    }
}
