using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Contracts
{
    internal interface IPila<T> where T: class
    {
        void Push(T data);
        T Pop();
        T Peek();
        void Clear();
    }
}
