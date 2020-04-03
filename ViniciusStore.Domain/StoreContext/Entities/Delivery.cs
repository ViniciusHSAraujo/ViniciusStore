using System;
using ViniciusStore.Domain.StoreContext.Enums;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class Delivery {
        
        public Delivery(DateTime estimatedDeliveryTime) {
            CreateDate = DateTime.Now;
            EstimatedDeliveryTime = estimatedDeliveryTime;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }

        public DateTime EstimatedDeliveryTime { get; private set; }

        public EDeliveryStatus Status { get; private set; }
    }
}