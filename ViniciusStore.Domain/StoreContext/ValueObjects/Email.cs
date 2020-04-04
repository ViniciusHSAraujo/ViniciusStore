using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViniciusStore.Domain.StoreContext.ValueObjects {
    public class Email : Notifiable, IValidatable {



        public Email(string address) {
            Address = address;

            Validate();
        }

        public string Address { get; set; }

        public override string ToString() {
            return Address;
        }

        public void Validate() {
            AddNotifications(new Contract()
                .IsEmail(Address, "Address", "O e-mail é inválido."));
        }
    }
}
