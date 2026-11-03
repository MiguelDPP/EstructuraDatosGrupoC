namespace EstructuraDeDatos.Presentation.Pilas
{
    partial class FrPilaBasica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxData = new GroupBox();
            btnAdd = new Button();
            textBox1 = new TextBox();
            lbProductTitle = new Label();
            groupBoxPilaPendding = new GroupBox();
            btnClearPending = new Button();
            listViewPilaPendding = new ListView();
            groupBoxPaid = new GroupBox();
            btnVaciarPaid = new Button();
            listViewPaid = new ListView();
            btnPassToPaid = new Button();
            btnPassToPedding = new Button();
            groupBoxData.SuspendLayout();
            groupBoxPilaPendding.SuspendLayout();
            groupBoxPaid.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(btnAdd);
            groupBoxData.Controls.Add(textBox1);
            groupBoxData.Controls.Add(lbProductTitle);
            groupBoxData.Location = new Point(32, 36);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(432, 76);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Productos de Mercado";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(294, 43);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(132, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar productos";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 23);
            textBox1.TabIndex = 1;
            // 
            // lbProductTitle
            // 
            lbProductTitle.AutoSize = true;
            lbProductTitle.Location = new Point(10, 20);
            lbProductTitle.Name = "lbProductTitle";
            lbProductTitle.Size = new Size(109, 15);
            lbProductTitle.TabIndex = 0;
            lbProductTitle.Text = "Ingrese el producto";
            // 
            // groupBoxPilaPendding
            // 
            groupBoxPilaPendding.Controls.Add(btnClearPending);
            groupBoxPilaPendding.Controls.Add(listViewPilaPendding);
            groupBoxPilaPendding.Location = new Point(32, 138);
            groupBoxPilaPendding.Name = "groupBoxPilaPendding";
            groupBoxPilaPendding.Size = new Size(196, 254);
            groupBoxPilaPendding.TabIndex = 1;
            groupBoxPilaPendding.TabStop = false;
            groupBoxPilaPendding.Text = "Pendientes";
            // 
            // btnClearPending
            // 
            btnClearPending.Location = new Point(6, 225);
            btnClearPending.Name = "btnClearPending";
            btnClearPending.Size = new Size(184, 23);
            btnClearPending.TabIndex = 3;
            btnClearPending.Text = "Vaciar Pendientes";
            btnClearPending.UseVisualStyleBackColor = true;
            // 
            // listViewPilaPendding
            // 
            listViewPilaPendding.Location = new Point(6, 22);
            listViewPilaPendding.Name = "listViewPilaPendding";
            listViewPilaPendding.Size = new Size(184, 197);
            listViewPilaPendding.TabIndex = 0;
            listViewPilaPendding.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxPaid
            // 
            groupBoxPaid.Controls.Add(btnVaciarPaid);
            groupBoxPaid.Controls.Add(listViewPaid);
            groupBoxPaid.Location = new Point(268, 138);
            groupBoxPaid.Name = "groupBoxPaid";
            groupBoxPaid.Size = new Size(196, 254);
            groupBoxPaid.TabIndex = 2;
            groupBoxPaid.TabStop = false;
            groupBoxPaid.Text = "Pagados";
            // 
            // btnVaciarPaid
            // 
            btnVaciarPaid.Location = new Point(6, 225);
            btnVaciarPaid.Name = "btnVaciarPaid";
            btnVaciarPaid.Size = new Size(184, 23);
            btnVaciarPaid.TabIndex = 4;
            btnVaciarPaid.Text = "Vaciar Pagados";
            btnVaciarPaid.UseVisualStyleBackColor = true;
            btnVaciarPaid.Click += button1_Click;
            // 
            // listViewPaid
            // 
            listViewPaid.Location = new Point(6, 22);
            listViewPaid.Name = "listViewPaid";
            listViewPaid.Size = new Size(184, 197);
            listViewPaid.TabIndex = 1;
            listViewPaid.UseCompatibleStateImageBehavior = false;
            // 
            // btnPassToPaid
            // 
            btnPassToPaid.Location = new Point(234, 212);
            btnPassToPaid.Name = "btnPassToPaid";
            btnPassToPaid.Size = new Size(28, 23);
            btnPassToPaid.TabIndex = 3;
            btnPassToPaid.Text = ">";
            btnPassToPaid.UseVisualStyleBackColor = true;
            // 
            // btnPassToPedding
            // 
            btnPassToPedding.Location = new Point(234, 241);
            btnPassToPedding.Name = "btnPassToPedding";
            btnPassToPedding.Size = new Size(28, 23);
            btnPassToPedding.TabIndex = 4;
            btnPassToPedding.Text = "<";
            btnPassToPedding.UseVisualStyleBackColor = true;
            // 
            // FrPilaBasica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 426);
            Controls.Add(btnPassToPedding);
            Controls.Add(btnPassToPaid);
            Controls.Add(groupBoxPaid);
            Controls.Add(groupBoxPilaPendding);
            Controls.Add(groupBoxData);
            MaximizeBox = false;
            MaximumSize = new Size(517, 465);
            MinimumSize = new Size(517, 465);
            Name = "FrPilaBasica";
            Text = "FrPilaBasica";
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            groupBoxPilaPendding.ResumeLayout(false);
            groupBoxPaid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxData;
        private Button btnClear;
        private Button btnAdd;
        private TextBox textBox1;
        private Label lbProductTitle;
        private GroupBox groupBoxPilaPendding;
        private ListView listViewPilaPendding;
        private GroupBox groupBoxPaid;
        private ListView listViewPaid;
        private Button btnClearPending;
        private Button btnVaciarPaid;
        private Button btnPassToPaid;
        private Button btnPassToPedding;
    }
}