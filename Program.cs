using DemoDatabaseUsingEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDatabaseUsingEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStoreContext myStore = new MyStoreContext();

            var products = from p in myStore.Products select new { p.ProductName, p.CategoryId };
            
            foreach (var product in products)
            {
                Console.WriteLine($"ProductName: {product.ProductName}, CategoryID: {product.CategoryId}");
            }

            Console.WriteLine("---------------------------------------------------------------------");
            IQueryable<Category> cats = myStore.Categories.Include(c => c.Products);
            foreach (var c in cats)
            {
                Console.WriteLine($"CateforyID: {c.CategoryId} has {c.Products.Count} products.");
            }
            Console.ReadLine();
        }
    }
}