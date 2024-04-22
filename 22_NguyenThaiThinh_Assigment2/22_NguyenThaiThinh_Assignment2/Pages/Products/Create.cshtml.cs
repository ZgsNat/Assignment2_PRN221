using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _22_NguyenThaiThinh_Assignment2.DataAccess;
using _22_NguyenThaiThinh_Assignment2.Repository;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Products
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
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public Product product { get; set; } = default!;
        private ProductRepository productRepository = new ProductRepository();
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            productRepository.Add(Product);

            return RedirectToPage("./Index");
        }
    }
}
