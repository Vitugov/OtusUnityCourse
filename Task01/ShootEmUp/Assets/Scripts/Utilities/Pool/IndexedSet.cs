using System;
using System.Collections.Generic;


namespace ShootEmUp
{
    // Add - O(1), Remove - O(1), Contains - O(1), GetList - O(1) 
    public class IndexedSet<T>
    {
        private readonly Dictionary<T, int> _indexMap;
        private readonly List<T> _items;
        public int Count => _items.Count;

        public IndexedSet()
        {
            _indexMap = new Dictionary<T, int>();
            _items = new List<T>();
        }

        public void Add(T item)
        {
            if (_indexMap.ContainsKey(item))
            {
                throw new InvalidOperationException("Item already exists in the set.");
            }

            _indexMap[item] = _items.Count;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (!_indexMap.TryGetValue(item, out int index))
            {
                throw new InvalidOperationException("Item does not exist in the set.");
            }

            int lastIndex = _items.Count - 1;
            T lastItem = _items[lastIndex];

            _items[index] = lastItem;
            _indexMap[lastItem] = index;

            _items.RemoveAt(lastIndex);
            _indexMap.Remove(item);
        }

        public IReadOnlyList<T> GetList() => _items;

        public bool Contains(T item) => _indexMap.ContainsKey(item);
    }
}
