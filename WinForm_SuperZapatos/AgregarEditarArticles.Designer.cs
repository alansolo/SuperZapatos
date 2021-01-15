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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarArticles = new System.Windows.Forms.Button();
            this.btnGuardarArticles = new System.Windows.Forms.Button();
            this.lblNameArticles = new System.Windows.Forms.Label();
            this.txtNameArticles = new System.Windows.Forms.TextBox();
            this.lblAddressArticles = new System.Windows.Forms.Label();
            this.txtAddressArticles = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 137);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAddressArticles);
            this.panel1.Controls.Add(this.lblAddressArticles);
            this.panel1.Controls.Add(this.txtNameArticles);
            this.panel1.Controls.Add(this.lblNameArticles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 89);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancelarArticles);
            this.panel2.Controls.Add(this.btnGuardarArticles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 36);
            this.panel2.TabIndex = 1;
            // 
            // btnCancelarArticles
            // 
            this.btnCancelarArticles.Location = new System.Drawing.Point(161, 11);
            this.btnCancelarArticles.Name = "btnCancelarArticles";
            this.btnCancelarArticles.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarArticles.TabIndex = 1;
            this.btnCancelarArticles.Text = "Cancelar";
            this.btnCancelarArticles.UseVisualStyleBackColor = true;
            // 
            // btnGuardarArticles
            // 
            this.btnGuardarArticles.Location = new System.Drawing.Point(57, 11);
            this.btnGuardarArticles.Name = "btnGuardarArticles";
            this.btnGuardarArticles.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarArticles.TabIndex = 0;
            this.btnGuardarArticles.Text = "Guardar";
            this.btnGuardarArticles.UseVisualStyleBackColor = true;
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
            // txtNameArticles
            // 
            this.txtNameArticles.Location = new System.Drawing.Point(109, 16);
            this.txtNameArticles.Name = "txtNameArticles";
            this.txtNameArticles.Size = new System.Drawing.Size(149, 23);
            this.txtNameArticles.TabIndex = 1;
            // 
            // lblAddressArticles
            // 
            this.lblAddressArticles.AutoSize = true;
            this.lblAddressArticles.Location = new System.Drawing.Point(25, 48);
            this.lblAddressArticles.Name = "lblAddressArticles";
            this.lblAddressArticles.Size = new System.Drawing.Size(60, 15);
            this.lblAddressArticles.TabIndex = 0;
            this.lblAddressArticles.Text = "Direccion:";
            // 
            // txtAddressArticles
            // 
            this.txtAddressArticles.Location = new System.Drawing.Point(109, 45);
            this.txtAddressArticles.Name = "txtAddressArticles";
            this.txtAddressArticles.Size = new System.Drawing.Size(149, 23);
            this.txtAddressArticles.TabIndex = 1;
            // 
            // AgregarEditarArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 137);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.TextBox txtAddressArticles;
        private System.Windows.Forms.Label lblAddressArticles;
        private System.Windows.Forms.TextBox txtNameArticles;
        private System.Windows.Forms.Label lblNameArticles;
    }
}



