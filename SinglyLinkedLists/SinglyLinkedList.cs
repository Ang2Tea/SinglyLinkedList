using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedLists
{
    public class SinglyLinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>
    {
        private SinglyNode<T>? head;
        private SinglyNode<T>? tail;
        private int count;

        public int Count => count;
        public bool IsReadOnly => false;
        public T this[int index]
        {
            get
            {
                int currentIndex = 0;
                foreach (T item in this)
                {
                    if (index == currentIndex) return item;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                SinglyLinkedList<T> list = this;
                list[index] = value;
            }
        }

        public SinglyLinkedList()
        {
            ClearList();
        }
        public SinglyLinkedList(T firstElement) : this()
        {
            Add(firstElement);
        }
        public SinglyLinkedList(IEnumerable<T> collection) : this()
        {
            foreach (T nodeData in collection)
            {
                Add(nodeData);
            }
        }

        private void ClearList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SinglyNode<T>? current = head;
            while (current is not null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable).GetEnumerator();
        }
        public void Clear()
        {
            ClearList();
        }
        public void Add(T item)
        {
            SinglyNode<T> newNode = new(item);
            if (head is null) head = newNode;
            else tail!.Next = newNode;

            tail = newNode;
            count++;
        }
        public void AppendFirst(T item)
        {
            SinglyNode<T> node = new(item)
            {
                Next = head
            };
            head = node;
            if (Count == 0) tail = head;
            count++;
        }
        public bool Contains(T item)
        {
            foreach (T node in this)
            {
                if (node!.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            new List<T>(this).CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            SinglyNode<T>? current = head;
            SinglyNode<T>? previous = null;

            while (current is not null)
            {
                if (current.Data!.Equals(item))
                {
                    if (previous is not null)
                    {
                        previous.Next = current.Next;

                        if (current.Next is null) tail = previous;
                    }
                    else
                    {
                        head = head!.Next;

                        if (head is null) tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            SinglyLinkedList<T> list = this;
            for(int i = 0; i < Count; i++)
            {
                if (list[i]!.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
