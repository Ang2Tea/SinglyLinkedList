using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DoubleLinkedLists
{
    internal class DoubleNode<T>
    {
        internal DoubleNode<T>? Previous { get; set; }
        internal DoubleNode<T>? Next { get; set; }
        internal T Data { get; set; }

        public DoubleNode(T data)
        {
            Data = data;
        }
    }
}
