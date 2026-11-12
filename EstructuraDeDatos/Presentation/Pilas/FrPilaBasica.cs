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
    public partial class FrPilaBasica : Form
    {
        private Pila<string> _pilaPendientes;
        private Pila<string> _pilaPagados;
        public FrPilaBasica()
        {
            InitializeComponent();
            _pilaPendientes = new Pila<string>();
            _pilaPagados = new Pila<string>();
        }

        private void UpdateListView(ListView listView, Pila<string> pila)
        {
            listView.Items.Clear();

            foreach(string producto in pila)
            {
                listView.Items.Add(producto);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddProduct.Text != string.Empty)
            {
                string producto = txtAddProduct.Text;
                _pilaPendientes.Push(producto);
                UpdateListView(listViewPilaPendding, _pilaPendientes);
                txtAddProduct.Text = string.Empty;
            } else
            {
                MessageBox.Show("Error: Ingrese un nombre para el producto");
            }
        }

        private void btnClearPending_Click(object sender, EventArgs e)
        {
            _pilaPendientes.Clear();
            UpdateListView(listViewPilaPendding, _pilaPendientes);
        }

        private void btnPassToPaid_Click(object sender, EventArgs e)
        {
            if (!_pilaPendientes.IsEmpty)
            {
                string producto = _pilaPendientes.Pop();
                _pilaPagados.Push(producto);
                UpdateListView(listViewPilaPendding, _pilaPendientes);
                UpdateListView(listViewPaid, _pilaPagados);
            }
        }

        private void btnPassToPedding_Click(object sender, EventArgs e)
        {
            if (!_pilaPagados.IsEmpty)
            {
                string producto = _pilaPagados.Pop();
                _pilaPendientes.Push(producto);
                UpdateListView(listViewPilaPendding, _pilaPendientes);
                UpdateListView(listViewPaid, _pilaPagados);
            }
        }

        private void btnClearPaid_Click(object sender, EventArgs e)
        {
            _pilaPagados.Clear();
            UpdateListView(listViewPaid, _pilaPagados);
        }
    }
}
