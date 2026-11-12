using EstructuraDeDatos.Contracts;
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
        private Pila<Disk> _origen;
        private int quantity;

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

        private void SetSize()
        {
            int widthPanel = panelPila1.Width;
            int heightPanel = panelPila1.Height;

            int heightDisk = heightPanel / _cantidadDiscos;
            //Ancho minimo
            int minWidth = (int)(widthPanel * 0.2);

            //Incremennto
            int steep = (widthPanel - minWidth) / (_pila1.Count - 1);

            foreach (Disk disco in _pila1)
            {
                disco.SetSize(minWidth, heightDisk);
                minWidth += steep;
            }
        }

        private void ActualizarDiscos(Control panelPila, Pila<Disk> pila)
        {
            panelPila.Controls.Clear();
            if (!pila.IsEmpty)
            {
                int positionX = 0;
                int positionY = panelPila.Height - (pila.Peek().PanelDisk.Height*pila.Count);

                int heightDisk = pila.Peek().PanelDisk.Height;

                foreach (Disk disco in pila)
                {
                    positionX = (panelPila.Width - disco.PanelDisk.Width) / 2;

                    disco.SetLocation(positionX, positionY);

                    positionY += heightDisk;

                    panelPila.Controls.Add(disco.PanelDisk);
                }
            }
        }

        private void ReiniciarPilas()
        {
            _pila1.Clear();
            _pila2.Clear();
            _pila3.Clear();

            Random random = new Random();

            for (int i = _cantidadDiscos; i > 0; i--)
            {
                int r = random.Next(0, 255);
                int g = random.Next(0, 255);
                int b = random.Next(0, 255);


                Disk disco = new Disk(i, Color.FromArgb(r, g, b));


                _pila1.Push(disco);
            }

            SetSize();
            ActualizarDiscos(panelPila1, _pila1);
            ActualizarDiscos(panelPila2, _pila2);
            ActualizarDiscos(panelPila3, _pila3);
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDiskNumber.Text, out _cantidadDiscos))
            {

                ReiniciarPilas();
            }
            else
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }

        private Pila<Disk> getPila(Panel panel)
        {
            switch (panel.Name)
            {
                case "panelPila1":
                    return _pila1;
                case "panelPila2":
                    return _pila2;
                case "panelPila3":
                    return _pila3;
            }

            return null;
        }

        private void panelPila_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            if (_origen == null)
            {
                _origen = getPila(panel);
                if (_origen.Count == 0) _origen = null;
            } else
            {
                Pila<Disk> destino = getPila(panel);
                
                if (destino.Peek() == null || _origen.Peek().Tamanio < destino.Peek().Tamanio)
                {
                    Disk disco = _origen.Pop();
                    destino.Push(disco);
                    ActualizarDiscos(panelPila1, _pila1);
                    ActualizarDiscos(panelPila2, _pila2);
                    ActualizarDiscos(panelPila3, _pila3);

                    _origen = null;
                } else
                {
                    MessageBox.Show("Error de moviemiento");
                    _origen = null;
                }
            }
        }
    }
}
