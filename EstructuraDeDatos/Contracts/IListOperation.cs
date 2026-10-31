using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Contracts
{
    internal interface IListOperation<T>
    {
        void Add(T data);
        void Delete(int index);

        void Delete(T data);
        T? ElementAt(int index);

        void Set(int index, T data);
    }
}
