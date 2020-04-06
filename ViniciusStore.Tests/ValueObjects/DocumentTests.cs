using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Tests.ValueObjects {
    [TestClass]
    public class DocumentTests {

        private Document validDocument;
        private Document invalidDocument;
        
        public DocumentTests() {
            validDocument = new Document("528.946.920-64");
            invalidDocument = new Document("111.111.111-11");
        }
        
        [TestMethod]
        public void DeveRetornarNotificacaoQuandoODocumentoNaoForValido() {
            Assert.AreEqual(true, invalidDocument.Invalid);
            Assert.IsTrue(invalidDocument.Notifications.Count >= 1);
        }
        
        [TestMethod]
        public void NaoDeveRetornarNotificacaoQuandoODocumentoForValido() {
            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}