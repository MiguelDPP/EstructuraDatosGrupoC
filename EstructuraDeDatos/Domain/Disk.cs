using System;
using System.Collections.Generic;
using System.Text;

namespace EstructuraDeDatos.Domain
{
    public class Disk
    {
        public int Tamanio {  get; set; }
        public Color Color { get ; set; }
        public Panel PanelDisk { get; set;  }

        //public Disk(int tamanio)
        //{
        //    Tamanio = tamanio;
        //}

        public void SetSize(int width, int height)
        {
            PanelDisk.Width = width;
            PanelDisk.Height = height;
        }

        //Ubicación
        public void SetLocation(int x, int y)
        {
            //PanelDisk.Left = x;
            //PanelDisk.Top = y;

            PanelDisk.Location = new Point(x, y);
        }

        public Disk(int tamanio, Color color)
        {
            PanelDisk = new Panel
            {
                BackColor = color
            };

            Label label = new Label
            {
                Text = tamanio.ToString(),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            PanelDisk.Controls.Add(label);

            Tamanio = tamanio;
            Color = color;
        }
    }
}
