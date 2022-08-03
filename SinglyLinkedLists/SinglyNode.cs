using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedLists
{
    internal class SinglyNode<T>
    {
        internal SinglyNode<T>? Next { get; set; }
        internal T Data { get; set; }

        internal SinglyNode(T data)
        {
            this.Data = data;
        }
    }
}
