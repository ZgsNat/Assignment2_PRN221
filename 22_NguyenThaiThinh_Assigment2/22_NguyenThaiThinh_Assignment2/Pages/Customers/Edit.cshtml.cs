using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _22_NguyenThaiThinh_Assignment2.DataAccess;
using Newtonsoft.Json;

namespace _22_NguyenThaiThinh_Assignment2.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public EditModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, bool? ok)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account =  await _context.Accounts.FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            Account = account;
            if (ok != null)
            {
                return new JsonResult(account);
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.AccountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync(string? accountData)
        {
            
            if (accountData == null)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(Account).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(Account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./Index");
            }
            // Phân tích dữ liệu JSON từ chuỗi dữ liệu đã gửi
            var account = JsonConvert.DeserializeObject<Account[]>(accountData);

            if (account == null || !ModelState.IsValid)
            {
                return Page();
            }

            // Thực hiện các thao tác cần thiết để cập nhật thông tin tài khoản trong cơ sở dữ liệu
            try
            {
                // Ví dụ:
                foreach (var acc in account)
                {
                    _context.Attach(acc).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.AccountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
