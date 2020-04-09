using ViniciusStore.Domain.StoreContext.Entities;

namespace ViniciusStore.Domain.StoreContext.Repositories {
    public interface ICustomeRepository {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    }
}