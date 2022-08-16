using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures;

public class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>
{
    private class Node<J>
    {
        internal Node<J>? Next { get; set; }
        internal J Data { get; set; }

        internal Node(J data)
        {
            Data = data;
        }
    }

    private Node<T>? head;
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
            LinkedList<T> list = this;
            list[index] = value;
        }
    }

    public LinkedList()
    {
        ClearList();
    }
    public LinkedList(T firstElement) : this()
    {
        Add(firstElement);
    }
    public LinkedList(IEnumerable<T> collection) : this()
    {
        foreach (T nodeData in collection)
        {
            Add(nodeData);
        }
    }

    private void ClearList()
    {
        head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = head;
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
        Node<T> newNode = new(item);
        if (head is null) { head = newNode; }
        else
        {
            Node<T> current = head;
            while (current.Next is not null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        count++;
    }
    public void AppendFirst(T item)
    {
        Node<T> node = new(item)
        {
            Next = head
        };
        head = node;
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
    public void CopyTo(T[] array, int arrayIndex = 0)
    {
        LinkedList<T> list = this;
        for (int i = 0; i < Count; i++, arrayIndex++)
        {
            array[arrayIndex] = list[i];
        }
    }
    public bool Remove(T item)
    {
        Node<T>? current = head;
        Node<T>? previous = null;

        while (current is not null)
        {
            if (current.Data!.Equals(item))
            {
                if (previous is not null) { previous.Next = current.Next; }
                else { head = head!.Next; }

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
        LinkedList<T> list = this;
        for (int i = 0; i < Count; i++)
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
        if (index >= Count) throw new IndexOutOfRangeException();

        Node<T>? previous = null;
        Node<T>? current = head;

        for (int i = 0; current is not null; i++)
        {
            if (index == i)
            {
                if (previous is not null)
                {
                    Node<T> newNode = new(item)
                    {
                        Next = current
                    };
                    previous.Next = newNode;
                }
                else { AppendFirst(item); }

                count++;
                return;
            }

            previous = current;
            current = current.Next;
        }
    }
    public void RemoveAt(int index)
    {
        if (index >= Count) throw new IndexOutOfRangeException();

        Node<T>? current = head;
        Node<T>? previous = null;

        for (int i = 0; current is not null; i++)
        {
            if (index == i)
            {
                if (previous is not null) { previous.Next = current.Next; }
                else { head = head!.Next; }

                count--;
                return;
            }

            previous = current;
            current = current.Next;
        }
    }
}