
// TODO: Create a shopping cart where users can add, remove, and view items, along with calculating the total price

using System;

class Product
{
    public string Name{get; set;}
    public decimal Price{get; set;}
    public int Quantity{get; set;}

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class ShoppingCart
{
    private List<Product> cart = new List<Product>();

    // Add a product to the cart
    public void AddProduct(string name, decimal price, int quantity)
    {
        var existingProduct = cart.Find(p => p.Name == name);
        if (existingProduct != null)
        {
            existingProduct.Quantity += quantity;  // Update quantity if the product already exists
        }
        else
        {
            cart.Add(new Product(name, price, quantity));
        }
        Console.WriteLine($"{quantity} {name}(s) added to the cart.");
    }

    // Remove a product from the cart
    public void RemoveProduct(string name)
    {
        var product = cart.Find(p => p.Name == name);
        if (product != null)
        {
            cart.Remove(product);
            Console.WriteLine($"{name} removed from the cart.");
        }
        else
        {
            Console.WriteLine($"{name} not found in the cart.");
        }
    }

    // View cart contents
    public void ViewCart()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine("\nItems in your cart:");
        foreach (var product in cart)
        {
            Console.WriteLine($"{product.Name} - ${product.Price} x {product.Quantity}");
        }
    }

    // Calculate total cost
    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in cart)
        {
            total += product.Price * product.Quantity;
        }
        return total;
    }

    // Checkout process
    public void Checkout()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty. Add items before checking out.");
            return;
        }

        decimal total = CalculateTotal();
        Console.WriteLine($"\nYour total is: ${total}");
        Console.WriteLine("Thank you for shopping with us!\n");
        cart.Clear();  // Clear the cart after checkout
    }
}

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        bool shopping = true;

        while (shopping)
        {
            Console.WriteLine("\nShopping Cart Menu:");
            Console.WriteLine("1. Add product to cart");
            Console.WriteLine("2. Remove product from cart");
            Console.WriteLine("3. View cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    cart.AddProduct(name, price, quantity);
                    break;

                case 2:
                    Console.Write("Enter product name to remove: ");
                    name = Console.ReadLine();
                    cart.RemoveProduct(name);
                    break;

                case 3:
                    cart.ViewCart();
                    break;

                case 4:
                    cart.Checkout();
                    break;

                case 5:
                    shopping = false;
                    Console.WriteLine("Thank you for visiting!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}