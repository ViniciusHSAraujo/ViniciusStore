using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ViniciusStore.Domain.StoreContext.ValueObjects;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class Customer {

        private readonly IList<Address> _addresses;
        public Customer(
            Document document,
            Email email,
            Phone phone
        ) {
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Phone Phone { get; private set; }

        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address) {
            //TODO - Validar o endereço..
            _addresses.Add(address);
        }

        public override string ToString() {
            return Name.ToString();
        }
    }
}