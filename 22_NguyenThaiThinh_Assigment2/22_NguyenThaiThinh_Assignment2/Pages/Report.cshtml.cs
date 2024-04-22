using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Pages
{
    public class ReportModel : PageModel
    {
        private readonly _22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context _context;

        public ReportModel(_22_NguyenThaiThinh_Assignment2.DataAccess.Ass2_Prn221_Bl5Context context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public IList<SalesSummary> ReportData { get; set; }
        public IList<DailyOrderSummary> DailyOrders { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (StartDate == default)
            {
                StartDate = DateTime.Parse("1/1/2024 12:00:00 AM");
            }

            if (EndDate == default)
            {
                EndDate = DateTime.Parse("12/1/2024 12:00:00 AM");
            }
            // Lấy dữ liệu tổng doanh số bán hàng theo ngày
            ReportData = await _context.Orders
    .Where(o => o.OrderDate >= StartDate && o.OrderDate <= EndDate)
    .SelectMany(o => o.OrderDetails)
    .GroupBy(od => od.Order.OrderDate.Date)
    .Select(g => new SalesSummary
    {
        Date = g.Key,
        TotalSales = g.Sum(od => od.Quantity * od.UnitPrice)
    })
    .OrderByDescending(s => s.Date)
    .ToListAsync();


            // Lấy dữ liệu các đơn hàng mỗi ngày
            DailyOrders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderDate >= StartDate && o.OrderDate <= EndDate)
                .Select(o => new DailyOrderSummary
                {
                    Date = o.OrderDate.Date,
                    Orders = o.OrderDetails.Select(od => new OrderInfo
                    {
                        OrderId = od.OrderId,
                        ProductName = od.Product.ProductName,
                        Quantity = od.Quantity,
                        TotalPrice = od.Quantity * od.UnitPrice // Tính tổng giá trị đơn hàng
                    }).ToList()
                })
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (StartDate == default)
            {
                StartDate = DateTime.Parse("1/1/2024 12:00:00 AM");
            }

            if (EndDate == default)
            {
                EndDate = DateTime.Parse("12/1/2024 12:00:00 AM");
            }
            // Lấy dữ liệu tổng doanh số bán hàng theo ngày
            ReportData = await _context.Orders
    .Where(o => o.OrderDate >= StartDate && o.OrderDate <= EndDate)
    .SelectMany(o => o.OrderDetails)
    .GroupBy(od => od.Order.OrderDate.Date)
    .Select(g => new SalesSummary
    {
        Date = g.Key,
        TotalSales = g.Sum(od => od.Quantity * od.UnitPrice)
    })
    .OrderByDescending(s => s.Date)
    .ToListAsync();


            // Lấy dữ liệu các đơn hàng mỗi ngày
            // Lấy dữ liệu các đơn hàng mỗi ngày
            DailyOrders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderDate >= StartDate && o.OrderDate <= EndDate)
                .Select(o => new DailyOrderSummary
                {
                    Date = o.OrderDate.Date,
                    Orders = o.OrderDetails.Select(od => new OrderInfo
                    {
                        OrderId = od.OrderId,
                        ProductName = od.Product.ProductName,
                        Quantity = od.Quantity,
                        TotalPrice = od.Quantity * od.UnitPrice // Tính tổng giá trị đơn hàng
                    }).ToList()
                })
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return Page();
        }
    }

    public class SalesSummary
    {
        public DateTime Date { get; set; }
        public double TotalSales { get; set; }
    }

    public class DailyOrderSummary
    {
        public DateTime Date { get; set; }
        public IList<OrderInfo> Orders { get; set; }
    }

    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
    
}
