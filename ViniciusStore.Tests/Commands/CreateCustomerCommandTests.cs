using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace ViniciusStore.Tests.Commands {
    [TestClass]
    public class CreateCustomerCommandTests {
        private readonly CreateCustomerCommand validCommand;
        private readonly CreateCustomerCommand invalidCommand;

        public CreateCustomerCommandTests() {
            validCommand = new CreateCustomerCommand() {
                FirstName = "Vinicius",
                LastName = "Araujo",
                Document = "528.946.920-64",
                Email = "test@test.com",
                Phone = "(11) 1111-1111"
            };
            invalidCommand = new CreateCustomerCommand() {
                FirstName = "",
                LastName = "",
                Document = "",
                Email = "",
                Phone = ""
            };
        }

        [TestMethod]
        public void DeveRetornarNotificacaoQuandoODocumentoNaoForValido() {
            Assert.AreEqual(false, invalidCommand.Validate());
            Assert.IsTrue(invalidCommand.Notifications.Count >= 1);
        }

        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoODocumentoForValido() {
            Assert.AreEqual(true, validCommand.Validate());
            Assert.AreEqual(0, validCommand.Notifications.Count);
        }
    }
}