using System;
using System.Collections.Generic;
using Shop.Entities.Enums;

namespace Shop.Entities
{
    public class Order
    {
        private static int totalIDs = 1;

        public int ID { get; set; }
        public Client Owner { get; private set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Itens { get; private set; }

        
        public Order (Client client)
        {
            this.ID = totalIDs;
            totalIDs++;

            this.Owner = client;
            this.Moment = DateTime.Now;
            this.Status = OrderStatus.PendingPayment;
            this.Itens = new List<OrderItem>();
            client.NewOrder(this);
        }
        
        public Order(Client client, OrderStatus orderStatus) : this(client)
        {
            this.Status = orderStatus;
        }

        public override string ToString()
        {
            string text = "ORDER SUMARY:\n";
            text += string.Format("Order Moment: {0}\n", this.Moment);
            text += string.Format("Order Status: {0}\n", this.Status);
            text += string.Format("Client: {0} ({1}/{2}/{3}) - {4}\n",
                Owner.Name, Owner.BirthDate.Day, Owner.BirthDate.Month,
                Owner.BirthDate.Year, Owner.Email);
            text += "Order itens:\n";
            
            foreach(OrderItem oi in Itens)
            {
                text += oi.ToString() + "\n";
            }

            text += string.Format("Total price: {0}", Total().ToString("n2"));

            return text;
        }

        public void AddItem(OrderItem item)
        {
            if (!Itens.Contains(item))
                Itens.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            if (Itens.Contains(item))
                Itens.Remove(item);
        }

        public double Total()
        {
            double total = 0.00d;

            if(Itens.Count > 0)
            {
                foreach(OrderItem item in Itens)
                {
                    total += item.SubTotal();
                }
            }

            return total;
        }
    }
}
