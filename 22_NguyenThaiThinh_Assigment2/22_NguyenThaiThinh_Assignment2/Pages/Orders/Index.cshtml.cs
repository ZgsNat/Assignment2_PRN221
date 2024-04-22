using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public IndexModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync(int? ok)
        {
            if (_context.Orders != null && ok==null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
            }
            if(_context.Orders != null && ok != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).OrderBy(o=>o.OrderDate).ToListAsync();
            }
        }
    }
}
