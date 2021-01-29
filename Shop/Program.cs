using System;
using System.Collections.Generic;
using System.Globalization;
using Shop.Entities;
using Shop.Entities.Enums;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Client cl1 = NewClient();
            Order o1 = NewOrder(cl1);

            Console.WriteLine();
            Console.WriteLine(o1.ToString());
        }

        private static Client NewClient()
        {
            Console.WriteLine("Enter the client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birthday (DD/MM/YYYY): ");
            DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return new Client(name, email, birthday);
        }

        private static Order NewOrder(Client client)
        {
            Console.WriteLine("Enter order data:");
            Console.WriteLine("Status: ");
            Console.WriteLine("(PendingPayment, Processing, Shipped, Delivered)");
            Console.Write("-> ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("How many itens in the order? ");
            int numItens = int.Parse(Console.ReadLine());

            List<OrderItem> itens = new List<OrderItem>(); 

            for(int i = 0; i < numItens; i++)
            {
                Console.WriteLine("Enter #{0} item data", i + 1);
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int prodQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, prodPrice);
                OrderItem ordItem = new OrderItem(product, prodQuantity);

                itens.Add(ordItem);
            }

            Order order = new Order(client, orderStatus);
            
            foreach (OrderItem oi in itens)
                order.AddItem(oi);

            return order;
        }
    }
}
