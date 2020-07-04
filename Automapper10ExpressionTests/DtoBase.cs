using System.Collections;
using System.Collections.Generic;

namespace Automapper10ExpressionTests
{
    public abstract class DtoBase<T> : IEnumerable<T> where T : DtoBase<T>
    {
        private readonly IList<T> _items;

        public int Count => _items.Count;
        public bool IsReadOnly => _items.IsReadOnly;
        public T this[int index] { get => _items[index]; set => _items[index] = value; }

        protected DtoBase()
        {
            this._items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
