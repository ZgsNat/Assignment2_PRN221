using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _22_NguyenThaiThinh_Assignment2.DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public IndexModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Product product { get; set; } = default!;
        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            
            if (_context.Products != null)
            {
                Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
            }
        }
    }
}
