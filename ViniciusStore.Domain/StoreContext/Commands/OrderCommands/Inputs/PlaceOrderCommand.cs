using System;
using System.Collections;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Shared.Commands;

namespace ViniciusStore.Domain.StoreContext.Commands.OrderCommands.Inputs {
    public class PlaceOrderCommand: Notifiable, ICommand {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItens { get; set; }

        public PlaceOrderCommand() {
            OrderItens = new List<OrderItemCommand>();
        }

        public bool Validate() {
            AddNotifications(new Contract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido.")
                .IsGreaterThan(OrderItens.Count, 0, "Items", "Nenhum item do pedido encontrado.")
            );
            return Valid;        }
    }


    public class OrderItemCommand {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}