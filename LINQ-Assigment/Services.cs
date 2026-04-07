using LINQ_Assigment.Models;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Assigment
{
    internal class Services
    {

        //Sorting electronics products from high to low
        public void GetElectronicsProducts()
        {
            using var context = new OnlineStoreContext();

            var products = context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Electronics")
                .OrderByDescending(p => p.Price)
                .ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price} kr");
            } 
        }

        //get suppliers with products  under 10 in stock
        public void GetSuppliersLowStock()
        {
            using var context = new OnlineStoreContext();

            var suppliers = context.Suppliers
                .Include(s => s.Products)
                .Where(s => s.Products.Any(p => p.StockQuantity < 10))
                .ToList();

            foreach (var s in suppliers)
            {
                Console.WriteLine($"{s.Name}");
            }
        }

        //Ordervalue last month
        public void GetTotalLastMonth()
        {
            using var context = new OnlineStoreContext();

            var lastMonth = DateTime.Now.AddMonths(-1);

            var total = context.Orders
                .Where(o => o.OrderDate >= lastMonth)
                .Sum(o => o.TotalAmount);

            Console.WriteLine($"Totalt ordervärde föregående månad:{total} kr");
        }

        //Three best sold products.
        public void GetTopProducts()
        {

        }

    }
}
