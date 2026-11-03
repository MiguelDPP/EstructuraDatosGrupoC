using EstructuraDeDatos.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.DynamicStructure
{
    public class NodePila<T> where T: class {
        public T Data { get; set; }

        public NodePila<T> Next { get; set; }

        public NodePila(T data) {
            Data = data;
        }
    }


    public class Pila<T>: IPila<T>, IEnumerable<T> where T: class
    {
        private NodePila<T> Top { get; set; }
        public int Count { get; private set; }
        public bool IsEmpty
        {
            get
            {
                return Top == null;
            }
        }

        public void Push(T data)
        {
            if (data == null) return;
            NodePila<T> n = new NodePila<T>(data);
            n.Next = Top;
            Top = n;
        }

        public T Pop()
        {
            if (IsEmpty) return null;

            NodePila<T> nodePop = Top;
            Top = Top.Next;

            return nodePop.Data;
        }

        public T Peek()
        {
            if (IsEmpty) return null;

            return Top.Data;
        }

        public void Clear()
        {
            Top = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodePila<T> temp = Top;
            while(temp != null)
            {
                yield return temp.Data;

                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
