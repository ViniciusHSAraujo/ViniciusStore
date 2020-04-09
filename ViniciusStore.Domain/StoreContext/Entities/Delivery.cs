using System;
using Flunt.Notifications;
using ViniciusStore.Domain.StoreContext.Enums;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class Delivery : Notifiable {
        public Delivery(DateTime estimatedDeliveryTime) {
            CreateDate = DateTime.Now;
            EstimatedDeliveryTime = estimatedDeliveryTime;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }

        public DateTime EstimatedDeliveryTime { get; private set; }

        public EDeliveryStatus Status { get; private set; }

        public void Ship() {
            //TODO - Se a data estimada de entrega for no passado, não entregar.
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel() {
            //Se o status já estiver como entregue, não pode cancelar.
            Status = EDeliveryStatus.Canceled;
        }
    }
}