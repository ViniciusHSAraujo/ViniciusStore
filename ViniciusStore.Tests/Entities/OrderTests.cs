using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Domain.StoreContext.Enums;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Tests.Entities {
    [TestClass]
    public class OrderTests {

        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        public OrderTests() {
            _customer = CreateAValidCustomer();
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "1200 dpi", "mouse.png", 99M, 10);
            _keyboard = new Product("Teclado Gamer", "Mecânico e com LED's", "teclado.png", 199M, 10);
            _chair = new Product("Cadeira Gamer", "Acento reclinável", "cadeira.png", 499M, 10);
            _monitor = new Product("Monitor Gamer", "21 polegadas, 144Hz", "monitor.png", 899M, 10);
        }    
        
        //Consigo criar um novo pedido
        [TestMethod]
        public void DeveSerPossivelCriarUmPedidoQuandoValido() {
            Assert.AreEqual(true, _order.Valid);
            Assert.AreEqual(0, _order.Notifications.Count);
        }

        //Ao criar o pedido, o status deve ser "Created"
        [TestMethod]
        public void StatusDeveSerCreatedAoCriarOPedido() {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //Ao adicionar um item, a quantidade de itens deve mudar
        [TestMethod]
        public void DeveRetornarDoisQuandoAdicionadosDoisItensValidos() {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void DeveRetornarCincoQuandoAdicionadasCincoUnidadesCompradasDoItem() {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.Quantity);
        }

        //Ao confirmar o pedido, deve se gerar um número.
        [TestMethod]
        public void DeseSeRetornarUmNúmeroQuandoAOPedidoForRealizado() {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao pagar um pedido, o status deve ser pago.
        [TestMethod]
        public void DeveRetornarPagoQuandoOPedidoForPago() {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //Dados 10 produtos, devem haver duas entregas.
        [TestMethod]
        public void DeveSeRetornarDoisQuandoCompradosDezProdutos() {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado.
        [TestMethod]
        public void StatusDeveSerCanceledQuandoSeCancelarOPedido() {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, as entregas devem ser canceladas.
        [TestMethod]
        public void DeveSeCancelarAsEntregasAoSeCancelarOPedido() {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries) {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }

        private Customer CreateAValidCustomer() {
            var name = new Name("Vinicius", "Araujo");
            var document = new Document("528.946.920-64");
            var email = new Email("test@test.com");
            var phone = new Phone("(11) 1111-1111");
            return new Customer(name, document, email, phone);
        }
    }
}