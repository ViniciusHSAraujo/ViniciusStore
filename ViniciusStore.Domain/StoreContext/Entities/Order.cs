using Flunt.Notifications;
using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ViniciusStore.Domain.StoreContext.Enums;
using ViniciusStore.Shared.Entities;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class Order : Entity {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer) {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }

        public string Number { get; private set; }

        public DateTime CreateDate { get; private set; }

        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity) {
            //TODO - Valida o item..
            if (quantity > product.Quantity) {
                AddNotification("OrderItem", $"O produto {product.Title} não tem {product.Quantity} itens em estoque.");
            }

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //To place a order
        public void Place() {
            // TODO- Validar
            if (_items.Count() == 0) {
                AddNotification("Order", "Esse pedido não possui ítens");
            }

            // Gera o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        public void Pay() {
            Status = EOrderStatus.Paid;
        }

        public void Ship() {
            //Cada 5 produtos, é uma entrega diferente.
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 0;
            foreach (var item in _items) {
                if (count == 5) {
                    count = 0;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            //Envia todas as entregas;
            deliveries.ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel() {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}