using System;
using System.Collections;
using System.Collections.Generic;
using ViniciusStore.Domain.StoreContext.Entities;

namespace ViniciusStore.Domain.StoreContext.Commands.OrderCommands.Inputs {
    public class PlaceOrderCommand {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItens { get; set; }
    }


    public class OrderItemCommand {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}