using System;
using Flunt.Notifications;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Domain.StoreContext.ValueObjects;
using ViniciusStore.Shared.Commands;

namespace ViniciusStore.Domain.StoreContext.Handlers {
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand> {
        public ICommandResult Handle(CreateCustomerCommand command) {
            //TODO - Verificar se o CPF existe na base..

            //TODO - Verificar se o e-mail existe na base..

            // Criar os VO's:
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);

            // Criar a entidade:
            var customer = new Customer(name, document, email, phone);

            // Validar entidade e VO's:
            AddNotifications(name, document, email, phone, customer);

            // TODO - Persistir o cliente..

            // TODO - Enviar um e-mail de boas vindas..

            // TODO -  Retornar o resultado para a tela:
            return new CreateCustomerCommandResult(Guid.Empty, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command) {
            throw new System.NotImplementedException();
        }
    }
}