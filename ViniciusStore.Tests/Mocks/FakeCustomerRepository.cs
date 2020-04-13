using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Domain.StoreContext.Repositories;

namespace ViniciusStore.Tests.Mocks {
    public class FakeCustomerRepository : ICustomeRepository {
        public bool CheckDocument(string document) {
            return false;
        }

        public bool CheckEmail(string email) {
            return false;
        }

        public void Save(Customer customer) { }
    }
}