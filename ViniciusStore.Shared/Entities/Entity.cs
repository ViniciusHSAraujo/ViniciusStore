using System;
using Flunt.Notifications;

namespace ViniciusStore.Shared.Entities {
    public abstract class Entity : Notifiable  {

        public Entity() {
            Id = new Guid();
        }
        
        public Guid Id { get; set; }
    }
}