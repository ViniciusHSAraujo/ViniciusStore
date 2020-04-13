using System;
using Flunt.Notifications;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Domain.StoreContext.Repositories;
using ViniciusStore.Domain.StoreContext.Services;
using ViniciusStore.Domain.StoreContext.ValueObjects;
using ViniciusStore.Shared.Commands;

namespace ViniciusStore.Domain.StoreContext.Handlers {
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand> {
        private readonly ICustomeRepository _customeRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomeRepository customeRepository, IEmailService emailService) {
            _customeRepository = customeRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command) {
            //TODO - Verificar se o CPF existe na base..
            if (_customeRepository.CheckDocument(command.Document)) {
                AddNotification("Document", "Este CPF já está em uso.");
            }

            //TODO - Verificar se o e-mail existe na base..
            if (_customeRepository.CheckEmail(command.Email)) {
                AddNotification("Email", "Este e-mail já está em uso.");
            }

            // Criar os VO's:
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var phone = new Phone(command.Phone);

            // Criar a entidade:
            var customer = new Customer(name, document, email, phone);

            // Validar entidade e VO's:
            AddNotifications(name, document, email, phone, customer);

            if (Invalid) {
                return null;
            }

            // Persistir o cliente..
            _customeRepository.Save(customer);
            // Enviar um e-mail de boas vindas..
            _emailService.Send(email.Address, "contato@viniciusstore.com", "Bem vindo!",
                "Seja bem vindo à Vinicius Store!");
            // Retornar o resultado para a tela:
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command) {
            throw new System.NotImplementedException();
        }
    }
}