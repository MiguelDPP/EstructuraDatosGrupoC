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
        private Pila<Producto> _canastaPendiente;
        private Pila<Producto> _canastaPagados;
        public FrPilaBasica()
        {
            InitializeComponent();
            _canastaPendiente = new Pila<Producto>();
            _canastaPagados = new Pila<Producto>();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            _canastaPagados.Clear();
            updateListView(listViewPaid, _canastaPagados);
        }

        private void updateListView(ListView listView, Pila<Producto> data)
        {
            listView.Items.Clear();

            foreach (Producto producto in data)
            {
                listView.Items.Add(producto.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Tool.validatedEmpty(txtAddProduct))
            {
                Producto producto = Producto.Create();
                producto.Name = txtAddProduct.Text;
                _canastaPendiente.Push(producto);
                updateListView(listViewPilaPendding, _canastaPendiente);
                txtAddProduct.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Campo producto vacío");
            }
        }

        private void btnClearPending_Click(object sender, EventArgs e)
        {
            _canastaPendiente.Clear();
            updateListView(listViewPilaPendding, _canastaPendiente);
        }

        private void btnPassToPaid_Click(object sender, EventArgs e)
        {
            //if (!_canastaPendiente.IsEmpty)
            //{
                Producto producto = _canastaPendiente.Pop();
                _canastaPagados.Push(producto);
                updateListView(listViewPilaPendding, _canastaPendiente);
                updateListView(listViewPaid, _canastaPagados);
            //}
            
        }

        private void btnPassToPedding_Click(object sender, EventArgs e)
        {
            //if (!_canastaPagados.IsEmpty)
            //{
                Producto producto = _canastaPagados.Pop();
                _canastaPendiente.Push(producto);
                updateListView(listViewPilaPendding, _canastaPendiente);
                updateListView(listViewPaid, _canastaPagados);
            //}
        }
    }
}
