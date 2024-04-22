using _22_NguyenThaiThinh_Assignment2.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Orders
{
    public class ClientOrderModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public ClientOrderModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        public IList<Order> Orders { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Orders = await _context.Orders
                .Where(o => o.CustomerId == id)
                .ToListAsync();

            return Page();
        }
    }
}
