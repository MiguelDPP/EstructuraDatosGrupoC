using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Domain
{
    public class Disk
    {
        public int Tamanio {  get; set; }
        public Color Color { get ; set; }

        public Disk(int tamanio)
        {
            Tamanio = tamanio;
        }

        public Disk(int tamanio, Color color)
        {
            Tamanio = tamanio;
            Color = color;
        }
    }
}
