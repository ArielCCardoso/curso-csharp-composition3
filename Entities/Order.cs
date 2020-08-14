using Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Curso.Udemy.CSharpCompleto2020.Capitulo9.Composition3.Entities
{
    class Order
    {
        public Client Client { get; set; }
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();
        public double TotalValue
        {
            get
            {
                double t = 0;
                foreach (OrderItem i in Itens )
                { t += i.SubTotal; }
                return t;
            }
        }

        public Order(Client client, DateTime moment, OrderStatus status)
        {
            Client = client;
            Moment = moment;
            Status = status;
        }

        public void AddItem(OrderItem item)
        {
            Itens.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Itens.Remove(item);
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder($"Order Moment: {Moment.ToLocalTime():dd/MM/yyyy HH:mm:ss} [Moment ISO8601: Local => {Moment.ToLocalTime():o} | UTC => {Moment.ToUniversalTime():o} ]\n"); // o = yyyy-MM-ddTHH:mm:ss.fffffffK = yyyy-MM-ddTHH:mm:ss.fffffffzzz
            s.AppendLine($"Order Status: {Status}\nClient: {Client}\nOrder Items:");
            foreach(OrderItem o in Itens)
            {
                s.AppendLine(o.ToString());
            }
            s.AppendLine($"Total Price: R$ {TotalValue.ToString("F2", CultureInfo.InvariantCulture)}");
            return s.ToString();
        }
    }
}
