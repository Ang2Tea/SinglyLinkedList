using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DoubleLinkedLists
{
    public class DoubleLinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private DoubleNode<T>? head;
        private DoubleNode<T>? tail;
        private int count;
        public int Count => count;

        public bool IsReadOnly => false;

        public DoubleLinkedList()
        {
            ClearList();
        }

        private void ClearList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            ClearList();
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
