using EstructuraDeDatos.DynamicStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EstructuraDeDatos.Presentation
{
    public partial class FrListaBasica : Form
    {
        private Lista<string> numeros;
        public FrListaBasica()
        {
            InitializeComponent();
            numeros = new Lista<string>();
        }

        public long validateNumber(Control control)
        {
            long number = -1;
            if (!long.TryParse(control.Text, out number))
            {
                control.BackColor = Color.Red;
                control.Focus();
            }
            else
            {
                control.BackColor = Color.White;
            }

            return number;
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
            //validateNumber((Control)sender);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            numeros.Add(txtNumero.Text);
            SetListBoxNumeros();
            txtNumero.Text = "";
            //long number = validateNumber(txtNumero);
            //if (number != -1)
            //{
            //    numeros.Add((int)number);
            //    SetListBoxNumeros();
            //    txtNumero.Text = "";
            //}
        }

        public void SetListBoxNumeros()
        {
            listBoxNumeros.Items.Clear();
            for (int i = 0; i < numeros.Count; i++)
            {
                listBoxNumeros.Items.Add(numeros.ElementAt(i));
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            long position = validateNumber(txtNumero);

            if (position >= 0 && position < numeros.Count)
            {
                numeros.Delete((int)position);

                listBoxNumeros.Items.RemoveAt((int)position);
            }
            else
            {
                MessageBox.Show("Posición inválida");
            }
        }
    }
}
