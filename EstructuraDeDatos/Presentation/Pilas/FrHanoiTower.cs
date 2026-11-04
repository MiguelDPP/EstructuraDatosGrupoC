using EstructuraDeDatos.Domain.HanoiTower;
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
        private Pila<Disk> _pilaA;
        private Pila<Disk> _pilaB;
        private Pila<Disk> _pilaC;

        private Pila<Disk> _pilaToMove;

        private int _diskNumber;

        private int _movements;

        public FrHanoiTower()
        {
            InitializeComponent();

            _pilaA = new Pila<Disk>();
            _pilaB = new Pila<Disk>();
            _pilaC = new Pila<Disk>();
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

            drawPanels();
        }

        //Mirar si lo agrego al tool o lo dejo aqui
        private void resizeHorizontalControls(Control parent, int margin)
        {
            int width;
            if (parent.Controls.Count > 0)
            {
                width = (parent.Width - (parent.Controls.Count * margin)) / parent.Controls.Count;
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

        private void clearPanels()
        {
            panelPila1.Controls.Clear();
            panelPila2.Controls.Clear();
            panelPila3.Controls.Clear();
        }



        private void drawPila(Pila<Disk> pila, Panel panel)
        {

            int widthPanel = panel.Width;
            int heightPanel = panel.Height;

            int yMargin = 5;

            int heightDisk = (heightPanel - yMargin * _diskNumber) / _diskNumber;
            int yPosition = heightPanel - ((heightDisk + yMargin) * (pila.Count)) + yMargin;



            foreach (Disk disk in pila)
            {
                int diskWidth = widthPanel - (20 * (_diskNumber - disk.Size));
                int xPosition = (widthPanel - diskWidth) / 2;

                Panel paneDisk = new Panel
                {
                    Width = widthPanel - (20 * (_diskNumber - disk.Size)),
                    Height = heightDisk,
                    BackColor = Color.Blue,
                    Location = new Point(xPosition, yPosition)
                };

                Label labelPane = new Label
                {
                    Text = disk.Size.ToString(),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                paneDisk.Controls.Add(labelPane);

                panel.Controls.Add(paneDisk);

                yPosition += heightDisk + yMargin;
            }

        }

        private void startGame()
        {
            _pilaA.Clear();
            _pilaB.Clear();
            _pilaC.Clear();

            for (int i = _diskNumber; i > 0; i--)
            {
                _pilaA.Push(new Disk(i));
            }

            _movements = 0;
            drawPanels();
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (Tool.IsNumeric(txtDiskNumber.Text))
            {
                _diskNumber = int.Parse(txtDiskNumber.Text);
                startGame();
            }
        }

        private void markPanel()
        {
            panelPila1.BorderStyle = BorderStyle.None;
            panelPila2.BorderStyle = BorderStyle.None;
            panelPila3.BorderStyle = BorderStyle.None;


            if (_pilaToMove != null)
            {
                Panel panel = null;
                if (_pilaToMove == _pilaA)
                {
                    panel = panelPila1;
                }
                else if (_pilaToMove == _pilaB)
                {
                    panel = panelPila2;
                }
                else if (_pilaToMove == _pilaC)
                {
                    panel = panelPila3;
                }
                if (panel != null)
                {
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    //Color de borde
                }
            }
        }

        private void drawPanels()
        {
            clearPanels();
            drawPila(_pilaA, panelPila1);
            drawPila(_pilaB, panelPila2);
            drawPila(_pilaC, panelPila3);
            lbMovements.Text = "Cantidad de Movimientos: " + _movements.ToString();
        }

        private void checkWin()
        {
            if (_pilaC.Count == _diskNumber || _pilaB.Count == _diskNumber)
            {
                MessageBox.Show("¡Felicidades! Has completado el juego en " + _movements + " movimientos.");
                startGame();

            }
        }

        private void movePila(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            Pila<Disk> aux = null;

            switch (panel.Name)
            {
                case "panelPila1":
                    aux = _pilaA;
                    break;
                case "panelPila2":
                    aux = _pilaB;
                    break;
                case "panelPila3":
                    aux = _pilaC;
                    break;
            }

            if (_pilaToMove == null)
            {
                _pilaToMove = aux;
            }
            else
            {
                if (_pilaToMove.Peek() != null && (aux.Peek() == null || _pilaToMove.Peek().Size < aux.Peek().Size))
                {
                    _movements++;
                    Disk disk = _pilaToMove.Pop();

                    aux.Push(disk);

                    drawPanels();

                    checkWin();

                }
                else
                {
                    MessageBox.Show("Movimiento no permitido, no puedes poner un disco más grande sobre uno más pequeño.");
                }

                _pilaToMove = null;
            }

            markPanel();
        }
    }
}
