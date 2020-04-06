using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Tests.ValueObjects {
    [TestClass]
    public class PhoneTests {

        private Phone validPhone;
        private Phone invalidPhone;
        
        public PhoneTests() {
            validPhone = new Phone("(11) 1111-1111");
            invalidPhone = new Phone("123456789");
        }
        
        [TestMethod]
        public void DeveRetornarNotificacaoQuandoOPhoneNaoForValido() {
            Assert.AreEqual(true, invalidPhone.Invalid);
            Assert.IsTrue(invalidPhone.Notifications.Count >= 1);
        }
        
        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoOPhoneForValido() {
            Assert.AreEqual(true, validPhone.Valid);
            Assert.AreEqual(0, validPhone.Notifications.Count);
        }
    }
}