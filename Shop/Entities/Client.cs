using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class Client
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public List<Order> Orders { get; private set; }

        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Orders = new List<Order>();
        }

        public void NewOrder(Order order)
        {
            if (!Orders.Contains(order))
                Orders.Add(order);
        }
    }
}
