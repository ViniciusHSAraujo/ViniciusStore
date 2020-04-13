using ViniciusStore.Domain.StoreContext.Services;

namespace ViniciusStore.Tests.Mocks {
    public class FakeEmailService : IEmailService {
        public void Send(string to, string @from, string subject, string body) {
            
        }
    }
}