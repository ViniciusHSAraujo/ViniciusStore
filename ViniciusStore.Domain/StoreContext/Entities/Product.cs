using System.Reflection;

namespace ViniciusStore.Domain.StoreContext.Entities {
    public class Product {
        public Product(string title, decimal description, string image, decimal price, int quantity) {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            Quantity = quantity;
        }

        public string Title { get; set; }

        public decimal Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public override string ToString() {
            return Title;
        }
    }
}