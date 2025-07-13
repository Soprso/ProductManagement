using ProductManagement.Models;
using ProductManagement.Repositories;

class Program
{
    static void Main()
    {
        var productRepo = new GenericRepository<Product>();
        productRepo.AddElements(new Product { Id = 1, Name = "Nike Air", Price = 79.99, Category = "Shoes", Description = "Running shoes with lightweight cushioning" });
        productRepo.AddElements(new Product { Id = 2, Name = "Adidas Ultraboost", Price = 99.99, Category = "Shoes", Description = "High-performance sports shoes for runners" });
        productRepo.AddElements(new Product { Id = 3, Name = "Apple Watch Series 9", Price = 399.99, Category = "Electronics", Description = "Smartwatch with fitness tracking and notifications" });
        productRepo.AddElements(new Product { Id = 4, Name = "Dell XPS 13", Price = 1299.99, Category = "Electronics", Description = "Powerful laptop with sleek design and performance" });
        productRepo.AddElements(new Product { Id = 5, Name = "Logitech MX Master 3", Price = 89.99, Category = "Accessories", Description = "Ergonomic wireless mouse with custom buttons" });
        productRepo.AddElements(new Product { Id = 6, Name = "Canon EOS M50", Price = 649.99, Category = "Cameras", Description = "Mirrorless camera with 4K video support" });
        productRepo.AddElements(new Product { Id = 7, Name = "Samsung Galaxy S24", Price = 999.99, Category = "Mobile", Description = "Latest Android smartphone with high-end specs" });
        productRepo.AddElements(new Product { Id = 8, Name = "Sony WH-1000XM5", Price = 349.99, Category = "Audio", Description = "Noise-cancelling wireless headphones" });
        productRepo.AddElements(new Product { Id = 9, Name = "The Lean Startup", Price = 19.99, Category = "Books", Description = "Book on entrepreneurship and innovation" });
        productRepo.AddElements(new Product { Id = 10, Name = "IKEA Study Table", Price = 149.99, Category = "Furniture", Description = "Wooden desk ideal for study and work from home" });

        var allProducts = productRepo.GetAll();
        System.Console.WriteLine();
        System.Console.WriteLine("All the product Details are listed below:");
        foreach (var prod in allProducts)
        {
            System.Console.WriteLine($"Name -> {prod.Name}, Price -> {prod.Price}, Category -> {prod.Category}, Description -> {prod.Description}");
        }
        var electronicProds = productRepo.GetByCondtion(e => e.Category == "Electronics");
        System.Console.WriteLine();
        System.Console.WriteLine("All electronic products are: ");
        foreach (var ep in electronicProds)
        {
            System.Console.WriteLine($"Name -> {ep.Name}, Price -> {ep.Price}, Category -> {ep.Category}, Description -> {ep.Description}");
        }
        var updateNikePrice = productRepo.GetByCondtion(e => e.Name == "Nike Air").FirstOrDefault();
        if (updateNikePrice != null)
        {
            updateNikePrice.Price = 100;
            productRepo.UpdateElement(updateNikePrice);
            System.Console.WriteLine($"Item {updateNikePrice.Name} updated successfully!!");
        }
        else
        {
            System.Console.WriteLine("Product not found!!");
        }
        var updatedAllProds = productRepo.GetAll();
        System.Console.WriteLine();
        System.Console.WriteLine("All the product Details are listed below:");
        foreach (var prod in updatedAllProds)
        {
            System.Console.WriteLine($"Name -> {prod.Name}, Price -> {prod.Price}, Category -> {prod.Category}, Description -> {prod.Description}");
        }
        var removeLastProduct = productRepo.GetAll().LastOrDefault();
        if (removeLastProduct != null)
        {
            System.Console.WriteLine($"{removeLastProduct.Name} removed successfully!!");
            productRepo.RemoveElement(removeLastProduct);
        }
        else
        {
            System.Console.WriteLine("Product Not found");
        }
        var updatedAllNewProds = productRepo.GetAll();
        System.Console.WriteLine();
        System.Console.WriteLine("All the product Details are listed below:");
         foreach (var prod in updatedAllNewProds)
        {
            System.Console.WriteLine($"Name -> {prod.Name}, Price -> {prod.Price}, Category -> {prod.Category}, Description -> {prod.Description}");
        }
    }
}