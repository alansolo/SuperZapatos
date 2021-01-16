namespace SuperZapatos
{
    partial class StoresArticles
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoresArticles));
            this.tabSuperZapatos = new System.Windows.Forms.TabControl();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvStore = new System.Windows.Forms.DataGridView();
            this.ColEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarStore = new System.Windows.Forms.Button();
            this.tabArticles = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarArticlesStores = new System.Windows.Forms.TextBox();
            this.btnBuscarArticlesStores = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.ColEditarA = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColEliminarA = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabSuperZapatos.SuspendLayout();
            this.tabStore.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabArticles.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSuperZapatos
            // 
            this.tabSuperZapatos.Controls.Add(this.tabStore);
            this.tabSuperZapatos.Controls.Add(this.tabArticles);
            this.tabSuperZapatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSuperZapatos.Location = new System.Drawing.Point(0, 0);
            this.tabSuperZapatos.Name = "tabSuperZapatos";
            this.tabSuperZapatos.SelectedIndex = 2;
            this.tabSuperZapatos.Size = new System.Drawing.Size(736, 450);
            this.tabSuperZapatos.TabIndex = 0;
            // 
            // tabStore
            // 
            this.tabStore.Controls.Add(this.tableLayoutPanel1);
            this.tabStore.Location = new System.Drawing.Point(4, 24);
            this.tabStore.Name = "tabStore";
            this.tabStore.Padding = new System.Windows.Forms.Padding(3);
            this.tabStore.Size = new System.Drawing.Size(728, 422);
            this.tabStore.TabIndex = 0;
            this.tabStore.Text = "Tiendas";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvStore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 416);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvStore
            // 
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColEditar,
            this.ColEliminar});
            this.dgvStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStore.Location = new System.Drawing.Point(3, 65);
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.RowHeadersVisible = false;
            this.dgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStore.Size = new System.Drawing.Size(716, 348);
            this.dgvStore.TabIndex = 0;
            this.dgvStore.Text = "dataGridView1";
            this.dgvStore.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStore_CellContentClick);
            // 
            // ColEditar
            // 
            this.ColEditar.HeaderText = "Editar";
            this.ColEditar.Image = ((System.Drawing.Image)(resources.GetObject("ColEditar.Image")));
            this.ColEditar.Name = "ColEditar";
            this.ColEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColEliminar
            // 
            this.ColEliminar.HeaderText = "Eliminar";
            this.ColEliminar.Image = ((System.Drawing.Image)(resources.GetObject("ColEliminar.Image")));
            this.ColEliminar.Name = "ColEliminar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAgregarStore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 56);
            this.panel1.TabIndex = 1;
            // 
            // btnAgregarStore
            // 
            this.btnAgregarStore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarStore.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarStore.Image")));
            this.btnAgregarStore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarStore.Location = new System.Drawing.Point(13, 15);
            this.btnAgregarStore.Name = "btnAgregarStore";
            this.btnAgregarStore.Size = new System.Drawing.Size(83, 31);
            this.btnAgregarStore.TabIndex = 0;
            this.btnAgregarStore.Text = "Agregar";
            this.btnAgregarStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarStore.UseVisualStyleBackColor = false;
            this.btnAgregarStore.Click += new System.EventHandler(this.btnAgregarStore_Click);
            // 
            // tabArticles
            // 
            this.tabArticles.Controls.Add(this.tableLayoutPanel2);
            this.tabArticles.Location = new System.Drawing.Point(4, 24);
            this.tabArticles.Name = "tabArticles";
            this.tabArticles.Padding = new System.Windows.Forms.Padding(3);
            this.tabArticles.Size = new System.Drawing.Size(728, 422);
            this.tabArticles.TabIndex = 1;
            this.tabArticles.Text = "Articulos";
            this.tabArticles.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvArticles, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(722, 416);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBuscarArticlesStores);
            this.panel2.Controls.Add(this.btnBuscarArticlesStores);
            this.panel2.Controls.Add(this.btnAgregarArticulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 118);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Tienda:";
            // 
            // txtBuscarArticlesStores
            // 
            this.txtBuscarArticlesStores.Location = new System.Drawing.Point(100, 29);
            this.txtBuscarArticlesStores.Name = "txtBuscarArticlesStores";
            this.txtBuscarArticlesStores.Size = new System.Drawing.Size(122, 23);
            this.txtBuscarArticlesStores.TabIndex = 1;
            // 
            // btnBuscarArticlesStores
            // 
            this.btnBuscarArticlesStores.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarArticlesStores.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArticlesStores.Image")));
            this.btnBuscarArticlesStores.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBuscarArticlesStores.Location = new System.Drawing.Point(239, 24);
            this.btnBuscarArticlesStores.Name = "btnBuscarArticlesStores";
            this.btnBuscarArticlesStores.Size = new System.Drawing.Size(83, 31);
            this.btnBuscarArticlesStores.TabIndex = 0;
            this.btnBuscarArticlesStores.Text = "Buscar";
            this.btnBuscarArticlesStores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarArticlesStores.UseVisualStyleBackColor = false;
            this.btnBuscarArticlesStores.Click += new System.EventHandler(this.btnBuscarArticlesStores_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArticulo.Image")));
            this.btnAgregarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(12, 79);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(83, 31);
            this.btnAgregarArticulo.TabIndex = 0;
            this.btnAgregarArticulo.Text = "Agregar";
            this.btnAgregarArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarArticulo.UseVisualStyleBackColor = false;
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColEditarA,
            this.ColEliminarA});
            this.dgvArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArticles.Location = new System.Drawing.Point(3, 127);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersVisible = false;
            this.dgvArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticles.Size = new System.Drawing.Size(716, 286);
            this.dgvArticles.TabIndex = 1;
            this.dgvArticles.Text = "dataGridView1";
            // 
            // ColEditarA
            // 
            this.ColEditarA.HeaderText = "Editar";
            this.ColEditarA.Image = ((System.Drawing.Image)(resources.GetObject("ColEditarA.Image")));
            this.ColEditarA.Name = "ColEditarA";
            // 
            // ColEliminarA
            // 
            this.ColEliminarA.HeaderText = "Eliminar";
            this.ColEliminarA.Image = ((System.Drawing.Image)(resources.GetObject("ColEliminarA.Image")));
            this.ColEliminarA.Name = "ColEliminarA";
            // 
            // StoresArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.tabSuperZapatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StoresArticles";
            this.Text = "Super Zapatos";
            this.tabSuperZapatos.ResumeLayout(false);
            this.tabStore.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabArticles.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSuperZapatos;
        private System.Windows.Forms.TabPage tabStore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvStore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregarStore;
        private System.Windows.Forms.TabPage tabArticles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.TextBox txtBuscarArticlesStores;
        private System.Windows.Forms.Button btnBuscarArticlesStores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn ColEditar;
        private System.Windows.Forms.DataGridViewImageColumn ColEliminar;
        private System.Windows.Forms.DataGridViewImageColumn ColEditarA;
        private System.Windows.Forms.DataGridViewImageColumn ColEliminarA;
    }
}

