using System.Collections;
using System.Drawing;

namespace GroupWebProject.Models.Interfaces
{
    public interface IStore : IReadOnlyCollection<Product>
    {
        /// <summary>
        /// Add a Book to the library.
        /// </summary>
        void Add(string Name, string Brand, string Description, double Price, double Rating);

        /// <summary>
        /// Remove a Book from the library with the given title.
        /// </summary>
        /// <returns>The Book, or null if not found.</returns>
        Product Buy(string Name);
    }

    public class Store : IStore
    {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();
        public int Count => products.Count;

        public void Add(string Name, string Brand, string Description, double Price, double Rating)
        {
            throw new NotImplementedException();
        }

        public Product Buy(string Name)
        {
            if (!products.ContainsKey(Name)){
                return null;
            }
            Product product = products[Name];
            return product;
            
        }

        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
