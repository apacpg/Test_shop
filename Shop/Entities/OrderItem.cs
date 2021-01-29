using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get { return Product.Price; } }

        public OrderItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, Quantity: {2}, Subtotal: ${3}", 
                Product.Name, Product.Price, Quantity, SubTotal());
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }
    }
}
