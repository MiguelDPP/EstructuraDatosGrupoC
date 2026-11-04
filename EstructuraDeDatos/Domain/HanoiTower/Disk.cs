using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Domain.HanoiTower
{
    internal class Disk
    {
        public int Size { get; private set; }

        public Disk(int size)
        {
            Size = size;
        }
    }
}
