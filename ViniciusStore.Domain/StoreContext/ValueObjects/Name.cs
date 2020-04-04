using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViniciusStore.Domain.StoreContext.ValueObjects {
    public class Name : Notifiable, IValidatable {

        public Name(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;

            Validate();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public void Validate() {
            AddNotifications(new Contract()
               .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter no mínimo 3 caracteres.")
               .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres.")
               .HasMinLen(LastName, 3, "LastName", "O nome deve conter no mínimo 3 caracteres.")
               .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 40 caracteres."));
        }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
