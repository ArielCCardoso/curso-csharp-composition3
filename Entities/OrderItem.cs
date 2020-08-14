using System.Globalization;

namespace Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities
{
    class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; private set; }
        public double SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }

        public OrderItem(int quantity, Product p)
        {
            Quantity = quantity;
            Product = p;
            Price = p.Price;
        }

        public override string ToString() => $"{Product.Name}, R$ {Price.ToString("F2",CultureInfo.InvariantCulture)}, Quantity: {Quantity}, Subtotal R$ {SubTotal.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}
