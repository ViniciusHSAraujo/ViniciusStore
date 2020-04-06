using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Tests.ValueObjects {
    [TestClass]
    public class EmailTests {

        private Email validEmail;
        private Email invalidEmail;
        
        public EmailTests() {
            validEmail = new Email("test@test.com");
            invalidEmail = new Email("test");
        }
        
        [TestMethod]
        public void DeveRetornarNotificacaoQuandoONomeNaoForValido() {
            Assert.AreEqual(true, invalidEmail.Invalid);
            Assert.IsTrue(invalidEmail.Notifications.Count >= 1);
        }
        
        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoONomeForValido() {
            Assert.AreEqual(true, validEmail.Valid);
            Assert.AreEqual(0, validEmail.Notifications.Count);
        }
    }
}