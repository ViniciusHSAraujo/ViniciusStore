using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Tests.ValueObjects {
    [TestClass]
    public class NameTests {

        private Name validName;
        private Name invalidName;
        
        public NameTests() {
            validName = new Name("Vinicius", "Araujo");
            invalidName = new Name("", "Araujo");
        }
        
        [TestMethod]
        public void DeveRetornarNotificacaoQuandoONomeNaoForValido() {
            Assert.AreEqual(true, invalidName.Invalid);
            Assert.IsTrue(invalidName.Notifications.Count >= 1);
        }
        
        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoONomeForValido() {
            Assert.AreEqual(true, validName.Valid);
            Assert.AreEqual(0, validName.Notifications.Count);
        }
    }
}