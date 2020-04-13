using System.Data;
using System.Globalization;
using System.Linq;
using Dapper;
using ViniciusStore.Domain.StoreContext.Entities;
using ViniciusStore.Domain.StoreContext.Repositories;
using ViniciusStore.Domain.StoreContext.ValueObjects;
using ViniciusStore.Infra.StoreContext.DataContexts;

namespace ViniciusStore.Infra.StoreContext.Repositoryies {
    public class CustomerRepository : ICustomerRepository {
        private readonly ViniciusDataContext _database;

        public CustomerRepository(ViniciusDataContext database) {
            _database = database;
        }

        public bool CheckDocument(string document) {
            return _database.Connection
                .Query<bool>("spCheckDocument", new {Document = document}, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email) {
            return _database.Connection.Query<bool>("spCheckEmail", new {Email = email},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer) {
            _database.Connection.Execute("spCreateCustomer", new {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone.Number
            }, commandType: CommandType.StoredProcedure);
            foreach (var address in customer.Addresses) {
                _database.Connection.Execute("spCreateAddress", new {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}