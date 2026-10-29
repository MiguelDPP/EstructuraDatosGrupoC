using EstructuraDeDatos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.DynamicStructure
{
    public class Node<T>
    {
        public T Data {  get; set; }
        public Node<T> Next { get; set; }

        public Node<T> Back {  get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class Lista<T> : IListOperation<T> where T : class
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; set; }

        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        public Lista() {
            Count = 0;
        }

        public void Add(T data)
        {
            Node<T> n = new Node<T>(data);
            if (IsEmpty)
            {
                _head = n;
                _last = n;
            }
            else
            {
                n.Back = _last;
                _last.Next = n;
                _last = n;
            }
            Count++;
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < Count)
            {
                if (index == 0)
                {
                    _head = _head.Next;
                    if (_head == null)
                    {
                        _last = null;
                    } else
                    {
                        _head.Back = null;
                    }
                   
                }
                else
                {
                    Node<T> temp = _head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        temp = temp.Next;
                    }
                    Node<T> temp2 = temp.Next.Next;
                    if (temp.Next == _last)
                    {
                        _last = temp;
                    }
                    else
                    {
                        temp2.Back = temp;
                    }
                    temp.Next = temp2;
                }
                Count--;
            }
        }

        public T? ElementAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                return null;
            }

            Node <T> temp = _head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }
            return temp.Data;
        }
    }
}
