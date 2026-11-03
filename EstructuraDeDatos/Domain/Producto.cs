using EstructuraDeDatos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Domain
{
    internal class Producto : IEntity<long>, IFactory<Producto>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        private Producto()
        {
            Id = 0;
            Name = string.Empty;
        }

        public static Producto Create()
        {
            return new Producto();
        }

        public static Producto Create(string textCsv)
        {
            return null;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
