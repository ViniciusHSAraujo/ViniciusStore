using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using ViniciusStore.Domain.StoreContext.Handlers;
using ViniciusStore.Tests.Mocks;

namespace ViniciusStore.Tests.Handlers {
    [TestClass]
    public class CustomerHandlerTests {
        [TestMethod]
        public void DeveRegistrarUmCustomerQuandoOCommandForValido() {
            var command = new CreateCustomerCommand() {
                FirstName = "Vinicius",
                LastName = "Araujo",
                Document = "528.946.920-64",
                Email = "test@test.com",
                Phone = "(11) 1111-1111"
            };
            Assert.AreEqual(true, command.Validate());
            
            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);
            
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}