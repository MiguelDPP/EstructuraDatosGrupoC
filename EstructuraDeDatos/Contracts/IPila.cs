using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Contracts
{
    internal interface IPila<T>
    {
        void Push(T data);
        T Pop();
        void Clear();
    }
}
