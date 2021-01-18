namespace WinForm_SuperZapatos
{
    partial class AgregarEditarArticles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarArticles));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTiendaArticles = new System.Windows.Forms.ComboBox();
            this.lblTiendaArticles = new System.Windows.Forms.Label();
            this.txtTotalVaultArticles = new System.Windows.Forms.TextBox();
            this.lblTotalBovedaArticles = new System.Windows.Forms.Label();
            this.lblPriceArticles = new System.Windows.Forms.Label();
            this.txtTotalShelfArticles = new System.Windows.Forms.TextBox();
            this.lblTotalShelfArticles = new System.Windows.Forms.Label();
            this.txtPriceArticles = new System.Windows.Forms.TextBox();
            this.txtDescriptionArticles = new System.Windows.Forms.TextBox();
            this.lblAddressArticles = new System.Windows.Forms.Label();
            this.txtNameArticles = new System.Windows.Forms.TextBox();
            this.lblNameArticles = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditarArticles = new System.Windows.Forms.Button();
            this.btnCancelarArticles = new System.Windows.Forms.Button();
            this.btnGuardarArticles = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 251);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTiendaArticles);
            this.panel1.Controls.Add(this.lblTiendaArticles);
            this.panel1.Controls.Add(this.txtTotalVaultArticles);
            this.panel1.Controls.Add(this.lblTotalBovedaArticles);
            this.panel1.Controls.Add(this.lblPriceArticles);
            this.panel1.Controls.Add(this.txtTotalShelfArticles);
            this.panel1.Controls.Add(this.lblTotalShelfArticles);
            this.panel1.Controls.Add(this.txtPriceArticles);
            this.panel1.Controls.Add(this.txtDescriptionArticles);
            this.panel1.Controls.Add(this.lblAddressArticles);
            this.panel1.Controls.Add(this.txtNameArticles);
            this.panel1.Controls.Add(this.lblNameArticles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 194);
            this.panel1.TabIndex = 0;
            // 
            // cmbTiendaArticles
            // 
            this.cmbTiendaArticles.FormattingEnabled = true;
            this.cmbTiendaArticles.Location = new System.Drawing.Point(109, 161);
            this.cmbTiendaArticles.Name = "cmbTiendaArticles";
            this.cmbTiendaArticles.Size = new System.Drawing.Size(149, 23);
            this.cmbTiendaArticles.TabIndex = 5;
            // 
            // lblTiendaArticles
            // 
            this.lblTiendaArticles.AutoSize = true;
            this.lblTiendaArticles.Location = new System.Drawing.Point(25, 164);
            this.lblTiendaArticles.Name = "lblTiendaArticles";
            this.lblTiendaArticles.Size = new System.Drawing.Size(45, 15);
            this.lblTiendaArticles.TabIndex = 0;
            this.lblTiendaArticles.Text = "Tienda:";
            // 
            // txtTotalVaultArticles
            // 
            this.txtTotalVaultArticles.Location = new System.Drawing.Point(109, 132);
            this.txtTotalVaultArticles.Name = "txtTotalVaultArticles";
            this.txtTotalVaultArticles.Size = new System.Drawing.Size(149, 23);
            this.txtTotalVaultArticles.TabIndex = 4;
            // 
            // lblTotalBovedaArticles
            // 
            this.lblTotalBovedaArticles.AutoSize = true;
            this.lblTotalBovedaArticles.Location = new System.Drawing.Point(25, 135);
            this.lblTotalBovedaArticles.Name = "lblTotalBovedaArticles";
            this.lblTotalBovedaArticles.Size = new System.Drawing.Size(77, 15);
            this.lblTotalBovedaArticles.TabIndex = 0;
            this.lblTotalBovedaArticles.Text = "Total boveda:";
            // 
            // lblPriceArticles
            // 
            this.lblPriceArticles.AutoSize = true;
            this.lblPriceArticles.Location = new System.Drawing.Point(25, 77);
            this.lblPriceArticles.Name = "lblPriceArticles";
            this.lblPriceArticles.Size = new System.Drawing.Size(43, 15);
            this.lblPriceArticles.TabIndex = 0;
            this.lblPriceArticles.Text = "Precio:";
            // 
            // txtTotalShelfArticles
            // 
            this.txtTotalShelfArticles.Location = new System.Drawing.Point(109, 103);
            this.txtTotalShelfArticles.Name = "txtTotalShelfArticles";
            this.txtTotalShelfArticles.Size = new System.Drawing.Size(149, 23);
            this.txtTotalShelfArticles.TabIndex = 3;
            // 
            // lblTotalShelfArticles
            // 
            this.lblTotalShelfArticles.AutoSize = true;
            this.lblTotalShelfArticles.Location = new System.Drawing.Point(25, 106);
            this.lblTotalShelfArticles.Name = "lblTotalShelfArticles";
            this.lblTotalShelfArticles.Size = new System.Drawing.Size(76, 15);
            this.lblTotalShelfArticles.TabIndex = 0;
            this.lblTotalShelfArticles.Text = "Total estante:";
            // 
            // txtPriceArticles
            // 
            this.txtPriceArticles.Location = new System.Drawing.Point(109, 74);
            this.txtPriceArticles.Name = "txtPriceArticles";
            this.txtPriceArticles.Size = new System.Drawing.Size(149, 23);
            this.txtPriceArticles.TabIndex = 2;
            // 
            // txtDescriptionArticles
            // 
            this.txtDescriptionArticles.Location = new System.Drawing.Point(109, 45);
            this.txtDescriptionArticles.Name = "txtDescriptionArticles";
            this.txtDescriptionArticles.Size = new System.Drawing.Size(149, 23);
            this.txtDescriptionArticles.TabIndex = 1;
            // 
            // lblAddressArticles
            // 
            this.lblAddressArticles.AutoSize = true;
            this.lblAddressArticles.Location = new System.Drawing.Point(25, 48);
            this.lblAddressArticles.Name = "lblAddressArticles";
            this.lblAddressArticles.Size = new System.Drawing.Size(72, 15);
            this.lblAddressArticles.TabIndex = 0;
            this.lblAddressArticles.Text = "Descripcion:";
            // 
            // txtNameArticles
            // 
            this.txtNameArticles.Location = new System.Drawing.Point(109, 16);
            this.txtNameArticles.Name = "txtNameArticles";
            this.txtNameArticles.Size = new System.Drawing.Size(149, 23);
            this.txtNameArticles.TabIndex = 0;
            // 
            // lblNameArticles
            // 
            this.lblNameArticles.AutoSize = true;
            this.lblNameArticles.Location = new System.Drawing.Point(25, 19);
            this.lblNameArticles.Name = "lblNameArticles";
            this.lblNameArticles.Size = new System.Drawing.Size(54, 15);
            this.lblNameArticles.TabIndex = 0;
            this.lblNameArticles.Text = "Nombre:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditarArticles);
            this.panel2.Controls.Add(this.btnCancelarArticles);
            this.panel2.Controls.Add(this.btnGuardarArticles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 45);
            this.panel2.TabIndex = 1;
            // 
            // btnEditarArticles
            // 
            this.btnEditarArticles.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarArticles.Image")));
            this.btnEditarArticles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarArticles.Location = new System.Drawing.Point(57, 9);
            this.btnEditarArticles.Name = "btnEditarArticles";
            this.btnEditarArticles.Size = new System.Drawing.Size(85, 30);
            this.btnEditarArticles.TabIndex = 7;
            this.btnEditarArticles.Text = "Editar";
            this.btnEditarArticles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarArticles.UseVisualStyleBackColor = true;
            this.btnEditarArticles.Click += new System.EventHandler(this.btnEditarArticles_Click);
            // 
            // btnCancelarArticles
            // 
            this.btnCancelarArticles.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarArticles.Image")));
            this.btnCancelarArticles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarArticles.Location = new System.Drawing.Point(161, 9);
            this.btnCancelarArticles.Name = "btnCancelarArticles";
            this.btnCancelarArticles.Size = new System.Drawing.Size(85, 30);
            this.btnCancelarArticles.TabIndex = 8;
            this.btnCancelarArticles.Text = "Cancelar";
            this.btnCancelarArticles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarArticles.UseVisualStyleBackColor = true;
            this.btnCancelarArticles.Click += new System.EventHandler(this.btnCancelarArticles_Click);
            // 
            // btnGuardarArticles
            // 
            this.btnGuardarArticles.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarArticles.Image")));
            this.btnGuardarArticles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarArticles.Location = new System.Drawing.Point(57, 9);
            this.btnGuardarArticles.Name = "btnGuardarArticles";
            this.btnGuardarArticles.Size = new System.Drawing.Size(85, 30);
            this.btnGuardarArticles.TabIndex = 6;
            this.btnGuardarArticles.Text = "Guardar";
            this.btnGuardarArticles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarArticles.UseVisualStyleBackColor = true;
            this.btnGuardarArticles.Click += new System.EventHandler(this.btnGuardarArticles_Click);
            // 
            // AgregarEditarArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 251);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEditarArticles";
            this.Text = "Articles";
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
        private System.Windows.Forms.Button btnCancelarArticles;
        private System.Windows.Forms.Button btnGuardarArticles;
        private System.Windows.Forms.TextBox txtDescriptionArticles;
        private System.Windows.Forms.Label lblAddressArticles;
        private System.Windows.Forms.TextBox txtNameArticles;
        private System.Windows.Forms.Label lblNameArticles;
        private System.Windows.Forms.Label lblTiendaArticles;
        private System.Windows.Forms.TextBox txtTotalVaultArticles;
        private System.Windows.Forms.Label lblTotalBovedaArticles;
        private System.Windows.Forms.Label lblPriceArticles;
        private System.Windows.Forms.TextBox txtTotalShelfArticles;
        private System.Windows.Forms.Label lblTotalShelfArticles;
        private System.Windows.Forms.TextBox txtPriceArticles;
        private System.Windows.Forms.ComboBox cmbTiendaArticles;
        private System.Windows.Forms.Button btnEditarArticles;
    }
}



