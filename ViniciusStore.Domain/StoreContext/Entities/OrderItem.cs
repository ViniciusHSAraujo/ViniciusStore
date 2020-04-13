﻿using Flunt.Notifications;
using System.Collections.Generic;
using ViniciusStore.Shared.Entities;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class OrderItem : Entity {
        public OrderItem(Product product, decimal quantity) {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.Quantity < quantity) {
                AddNotification("Quantity", "Produto fora de estoque.");
            }

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal Price { get; private set; }
    }
}