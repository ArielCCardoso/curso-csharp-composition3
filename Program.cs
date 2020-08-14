using System;
using System.Globalization;
using Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities;
using Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities.Enums;

namespace Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Enter client data --- ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (Format -> DD/MM/YYYY): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());

            Console.Write("Order status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birth);
            Order order = new Order(client, DateTime.UtcNow, status);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item ordem:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, product);

                order.AddItem(orderItem);
            }

            Console.Clear();
            Console.WriteLine($"--- Order Summary ---\n{order}");
        }
    }
}
