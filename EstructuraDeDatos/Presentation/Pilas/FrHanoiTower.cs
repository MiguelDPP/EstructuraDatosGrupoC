using EstructuraDeDatos.Domain;
using EstructuraDeDatos.DynamicStructure;
using EstructuraDeDatos.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EstructuraDeDatos.Presentation.Pilas
{
    public partial class FrHanoiTower : Form
    {
        private Pila<Disk> _pila1;
        private Pila<Disk> _pila2;
        private Pila<Disk> _pila3;

        private int _cantidadDiscos;
        public FrHanoiTower()
        {
            InitializeComponent();
            _pila1 = new Pila<Disk>();
            _pila2 = new Pila<Disk>();
            _pila3 = new Pila<Disk>();
        }

        private void FrHanoiTower_SizeChanged(object sender, EventArgs e)
        {
            Tool.resizeWitdhControls(this, lbTitle, 20);
            Tool.resizeHeightControls(this, panelPilas, 60);
            Tool.resizeWitdhControls(this, panelPilas, 40);

            Tool.resizeHeightControls(panelPilas, panelPila1, 20);
            Tool.resizeHeightControls(panelPilas, panelPila2, 20);
            Tool.resizeHeightControls(panelPilas, panelPila3, 20);

            resizeHorizontalControls(panelPilas, 20);
        }

        //Mirar si lo agrego al tool o lo dejo aqui
        private void resizeHorizontalControls(Control parent, int margin)
        {
            int width;
            if (parent.Controls.Count > 0)
            {
                width = (parent.Width - (parent.Controls.Count + 1 * margin)) / parent.Controls.Count;
            }
            else
            {
                return;
            }
            int positionX = margin;
            foreach (Control control in parent.Controls)
            {
                control.Width = width;
                control.Left = positionX;
                positionX += width + margin;
            }
        }

        private void ActualizarDiscos(Control panel, Pila<Disk> pila)
        {
            panel.Controls.Clear();

            int widthPanel = panel.Width;
            int heightPanel = panel.Height;

            int heightDisk = heightPanel / _cantidadDiscos;

            int positionX = 0;
            int positionY = 0;

            foreach(Disk disco in pila)
            {
                Panel panelDisk = new Panel
                {
                    Width = widthPanel,
                    Height = heightDisk,
                    BackColor = disco.Color,
                    Location = new Point(positionX, positionY)
                };

                positionY += heightDisk;

                Label label = new Label
                {
                    Text = disco.Tamanio.ToString(),
                    //Ajustar al contenedor padre
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelDisk.Controls.Add(label);

                panel.Controls.Add(panelDisk);
            }
        }

        private void ReiniciarPilas()
        {
            _pila1.Clear();
            _pila2.Clear();
            _pila3.Clear();

            Random random = new Random();

            for(int i = _cantidadDiscos; i > 0; i--)
            {
                int r = random.Next(0, 255);
                int g = random.Next(0, 255);
                int b = random.Next(0, 255);


                Disk disco = new Disk(i, Color.FromArgb(r, g, b));
                

                _pila1.Push(disco);
            }

            ActualizarDiscos(panelPila1, _pila1);
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDiskNumber.Text, out _cantidadDiscos))
            {
                ReiniciarPilas();
            } else
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }
    }
}
