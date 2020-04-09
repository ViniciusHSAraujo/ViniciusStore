using Flunt.Notifications;
using Flunt.Validations;
using ViniciusStore.Shared.Commands;

namespace ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Inputs {
    public class CreateCustomerCommand : Notifiable, ICommand {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Validate() {
            AddNotifications(new Contract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter no mínimo 3 caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O nome deve conter no mínimo 3 caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 40 caracteres.")
                .IsEmail(Email, "Address", "O e-mail é inválido.")
                .HasLen(Document, 11, "Document", "CPF inválido.")
            );
            return Valid;
        }
    }
}