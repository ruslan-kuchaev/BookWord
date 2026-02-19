using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using wood.Data;
using wood.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace wood.Pages.Admin
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Index(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public int TotalBooksCount { get; set; }
        public int TotalUsersCount { get; set; }
        public int TodayOrdersCount { get; set; }
        public decimal TodayRevenue { get; set; }

        public int NewBooksCount { get; set; }
        public int NewUsersCount { get; set; }
        public int PendingOrdersCount { get; set; }
        public int NewReviewsCount { get; set; }

        public IdentityUser CurrentUser { get; set; }
        
        public List<OrderViewModel> RecentOrders { get; set; }
        
        public SalesData SalesData { get; set; }
        public string CategoryLabels { get; set; }
        public string CategoryData { get; set; }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            CurrentUser = user ?? new IdentityUser { UserName = "Admin", Email = "admin@bookstore.ru" };
            
            TotalBooksCount = _context.Books.Count();
            TotalUsersCount = _context.Users.Count();
            TodayOrdersCount = _context.Orders.Count(o => o.OrderDate.Date == DateTime.Today);
            TodayRevenue = _context.Orders
                .Where(o => o.OrderDate.Date == DateTime.Today)
                .Sum(o => (decimal?)o.OrderTotalAmount) ?? 0;

            NewBooksCount = _context.Books.Count();
            NewUsersCount = _context.Users.Count();
            PendingOrdersCount = _context.Orders.Count();

            RecentOrders = _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    CustomerName = o.User.UserName ?? "Руслан",
                    TotalAmount = o.OrderTotalAmount,
                    Status = o.OrderStatus.ToString(),
                    OrderDate = o.OrderDate
                })
                .ToList();

            SalesData = new SalesData();
            var weekDays = Enumerable.Range(0, 7).Select(i => DateTime.Today.AddDays(-i)).Reverse();
            int index = 0;
            foreach (var day in weekDays)
            {
                var daySales = _context.Orders
                    .Where(o => o.OrderDate.Date == day.Date)
                    .Sum(o => (decimal?)o.OrderTotalAmount) ?? 0;
                
                switch (index)
                {
                    case 0: SalesData.Monday = (int)daySales; break;
                    case 1: SalesData.Tuesday = (int)daySales; break;
                    case 2: SalesData.Wednesday = (int)daySales; break;
                    case 3: SalesData.Thursday = (int)daySales; break;
                    case 4: SalesData.Friday = (int)daySales; break;
                    case 5: SalesData.Saturday = (int)daySales; break;
                    case 6: SalesData.Sunday = (int)daySales; break;
                }
                index++;
            }

            var categories = _context.Categories
                .Select(c => new { 
                    c.Name, 
                    Count = _context.Books.Count(b => b.CategoryId == c.Id) 
                })
                .OrderByDescending(c => c.Count)
                .Take(5)
                .ToList();

            CategoryLabels = string.Join(",", categories.Select(c => $"\"{c.Name}\""));
            CategoryData = string.Join(",", categories.Select(c => c.Count));
        }
    }
    
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class SalesData
    {
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
    }
}