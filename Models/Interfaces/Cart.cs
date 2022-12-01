using System.Collections;

namespace GroupWebProject.Models.Interfaces
{
    public interface ICart<T> : IEnumerable<T>
    {
        /// <summary>
        /// Add an item to the bag. <c>null</c> items are ignored.
        /// </summary>
        void AddProduct(T item);

        /// <summary>
        /// Remove the item from the bag at the given index.
        /// </summary>
        /// <returns>The item that was removed.</returns>
        T RemoveProduct(int index);
    }
    public class Cart<T> : ICart<T>
    {
        private readonly List<T> stuff = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T thing in stuff)
                yield return thing;
        }

        public void AddProduct(T item)
        {
            stuff.Add(item); //Adds Item to cart
        }

        public T RemoveProduct(int index)
        {
            T thing = stuff[index];
            stuff.RemoveAt(index);
            return thing;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
