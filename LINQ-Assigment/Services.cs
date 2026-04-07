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

            var today = DateTime.Now;
            var firstDayThisMonth = new DateTime(today.Year, today.Month, 1);
            var firstDayLastMonth = firstDayThisMonth.AddMonths(-1);

            var total = context.Orders
                .Where(o => o.OrderDate >= firstDayLastMonth && o.OrderDate < firstDayThisMonth)
                .Sum(o => o.TotalAmount);

            Console.WriteLine($"Totalt ordervärde föregående månad:{total} kr");
        }

        //Three best sold products.
        public void GetTopProducts()
        {
            using var context = new OnlineStoreContext();

            var topProducts = context.OrderDetails
                .Include(od => od.Product)
                .GroupBy(od => od.Product.Name)
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalSold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(3)
                .ToList();

            foreach (var p in topProducts)
            {
                Console.WriteLine($"Produkt: {p.ProductName}, Sålda enheter: {p.TotalSold}");
            }
        }


        //Total products in each category

        public void GetProductsPerCategory()
        {
            using var context = new OnlineStoreContext();
            var categoryCounts = context.Products
                .Include(p => p.Category)
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count()
                })
                .ToList();

            foreach (var c in categoryCounts)
            {
                Console.WriteLine($"Kategori: {c.CategoryName}, Antal produkter: {c.ProductCount}");
            }
        }

        //Customers with orders over 1000 kr with customer and details

        public void GetOrdersOver1000()
        {
            using var context = new OnlineStoreContext();
            var orders = context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.TotalAmount > 1000)
                .ToList();

            foreach (var o in orders)
            {
                Console.WriteLine($"Kund: {o.Customer.Name}\n" +
                    $" Datum: {o.OrderDate}\n" +
                    $"Total summa: {o.TotalAmount} kr");

                foreach (var od in o.OrderDetails)
                {
                    Console.WriteLine($"\tProdukter: {od.Product.Name}, Antal: {od.Quantity}");
                }
            }
        }
    }
}
