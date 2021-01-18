namespace WinForm_SuperZapatos
{
    partial class AgregarEditarStore
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarStore));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAddressStore = new System.Windows.Forms.TextBox();
            this.lblAddressStore = new System.Windows.Forms.Label();
            this.txtNameStore = new System.Windows.Forms.TextBox();
            this.lblNameStore = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditarStore = new System.Windows.Forms.Button();
            this.btnCancelarStore = new System.Windows.Forms.Button();
            this.btnGuardarStore = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 145);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAddressStore);
            this.panel1.Controls.Add(this.lblAddressStore);
            this.panel1.Controls.Add(this.txtNameStore);
            this.panel1.Controls.Add(this.lblNameStore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 95);
            this.panel1.TabIndex = 0;
            // 
            // txtAddressStore
            // 
            this.txtAddressStore.Location = new System.Drawing.Point(109, 45);
            this.txtAddressStore.Name = "txtAddressStore";
            this.txtAddressStore.Size = new System.Drawing.Size(149, 23);
            this.txtAddressStore.TabIndex = 1;
            // 
            // lblAddressStore
            // 
            this.lblAddressStore.AutoSize = true;
            this.lblAddressStore.Location = new System.Drawing.Point(25, 48);
            this.lblAddressStore.Name = "lblAddressStore";
            this.lblAddressStore.Size = new System.Drawing.Size(60, 15);
            this.lblAddressStore.TabIndex = 0;
            this.lblAddressStore.Text = "Direccion:";
            // 
            // txtNameStore
            // 
            this.txtNameStore.Location = new System.Drawing.Point(109, 16);
            this.txtNameStore.Name = "txtNameStore";
            this.txtNameStore.Size = new System.Drawing.Size(149, 23);
            this.txtNameStore.TabIndex = 0;
            // 
            // lblNameStore
            // 
            this.lblNameStore.AutoSize = true;
            this.lblNameStore.Location = new System.Drawing.Point(25, 19);
            this.lblNameStore.Name = "lblNameStore";
            this.lblNameStore.Size = new System.Drawing.Size(54, 15);
            this.lblNameStore.TabIndex = 0;
            this.lblNameStore.Text = "Nombre:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditarStore);
            this.panel2.Controls.Add(this.btnCancelarStore);
            this.panel2.Controls.Add(this.btnGuardarStore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 38);
            this.panel2.TabIndex = 1;
            // 
            // btnEditarStore
            // 
            this.btnEditarStore.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarStore.Image")));
            this.btnEditarStore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarStore.Location = new System.Drawing.Point(57, 5);
            this.btnEditarStore.Name = "btnEditarStore";
            this.btnEditarStore.Size = new System.Drawing.Size(85, 30);
            this.btnEditarStore.TabIndex = 3;
            this.btnEditarStore.Text = "Editar";
            this.btnEditarStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarStore.UseVisualStyleBackColor = true;
            this.btnEditarStore.Click += new System.EventHandler(this.btnEditarStore_Click);
            // 
            // btnCancelarStore
            // 
            this.btnCancelarStore.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarStore.Image")));
            this.btnCancelarStore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarStore.Location = new System.Drawing.Point(162, 5);
            this.btnCancelarStore.Name = "btnCancelarStore";
            this.btnCancelarStore.Size = new System.Drawing.Size(85, 30);
            this.btnCancelarStore.TabIndex = 4;
            this.btnCancelarStore.Text = "Cancelar";
            this.btnCancelarStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarStore.UseVisualStyleBackColor = true;
            this.btnCancelarStore.Click += new System.EventHandler(this.btnCancelarStore_Click);
            // 
            // btnGuardarStore
            // 
            this.btnGuardarStore.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarStore.Image")));
            this.btnGuardarStore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarStore.Location = new System.Drawing.Point(57, 5);
            this.btnGuardarStore.Name = "btnGuardarStore";
            this.btnGuardarStore.Size = new System.Drawing.Size(85, 30);
            this.btnGuardarStore.TabIndex = 2;
            this.btnGuardarStore.Text = "Guardar";
            this.btnGuardarStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarStore.UseVisualStyleBackColor = true;
            this.btnGuardarStore.Click += new System.EventHandler(this.btnGuardarStore_Click);
            // 
            // AgregarEditarStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 145);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEditarStore";
            this.Text = "Store";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelarStore;
        private System.Windows.Forms.Button btnGuardarStore;
        private System.Windows.Forms.TextBox txtAddressStore;
        private System.Windows.Forms.Label lblAddressStore;
        private System.Windows.Forms.TextBox txtNameStore;
        private System.Windows.Forms.Label lblNameStore;
        private System.Windows.Forms.Button btnEditarStore;
    }
}



