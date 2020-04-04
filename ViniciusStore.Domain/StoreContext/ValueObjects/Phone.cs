using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViniciusStore.Domain.StoreContext.ValueObjects {
    public class Phone : Notifiable, IValidatable {
        public Phone(string number) {
            Number = number;

            Validate();
        }

        public string Number { get; private set; }

        public void Validate() {
            AddNotifications(new Contract()
                .HasMinLen(Number, 13, "Number", "Número inválido, experimente utilizar o padrão (XX) XXXXX - XXXX"));
        }
    }
}