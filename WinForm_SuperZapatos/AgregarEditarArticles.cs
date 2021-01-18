using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForm_SuperZapatos
{
    public partial class AgregarEditarArticles : Form
    {
        #region Variables
        public bool esGuardar;
        public string nameArticles;
        public string descriptionArticles;
        public decimal priceArticles;
        public int totalShelfArticles;
        public int totalVaultArticles;
        public int idStore;

        const string tituloAddArticles = "Agregar Articulo";
        const string tituloEditArticles = "Editar Articulo";
        #endregion

        #region Enumeraciones
        public enum Tipo
        {
            Add,
            Edit
        }
        #endregion

        public AgregarEditarArticles(Tipo tipo, string nameArticles, string descriptionArticles, decimal priceArticles,
                                        int totalShelfArticles, int totalVaultArticles, object selectTienda, object listaTiendaArticles)
        {
            InitializeComponent();

            this.esGuardar = false;
            this.nameArticles = string.Empty;
            this.descriptionArticles = string.Empty;
            this.priceArticles = 0;
            this.totalShelfArticles = 0;
            this.totalVaultArticles = 0;

            txtNameArticles.Text = nameArticles;
            txtDescriptionArticles.Text = descriptionArticles;
            txtPriceArticles.Text = priceArticles.ToString();
            txtTotalShelfArticles.Text = totalShelfArticles.ToString();
            txtTotalVaultArticles.Text = totalVaultArticles.ToString();

            cmbTiendaArticles.DataSource = listaTiendaArticles;
            cmbTiendaArticles.DisplayMember = "name";
            cmbTiendaArticles.ValueMember = "id";

            cmbTiendaArticles.SelectedItem = selectTienda;

            if (tipo == Tipo.Add)
            {
                btnGuardarArticles.Visible = true;
                btnEditarArticles.Visible = false;
            }
            else if (tipo == Tipo.Edit)
            {
                btnGuardarArticles.Visible = false;
                btnEditarArticles.Visible = true;
            }
        }
        
        /// <summary>
        /// METODOS PARA GUARDAR Y EDITAR ARTICULOS
        /// </summary>
        #region Metodos_Guardar_Editar
        private void btnGuardarArticles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameArticles.Text))
            {
                MessageBox.Show("Debe agregar el nombre del articulo.", tituloAddArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescriptionArticles.Text))
            {
                MessageBox.Show("Debe agregar la descripcion del articulo.", tituloAddArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPriceArticles.Text))
            {
                MessageBox.Show("Debe agregar el precio del articulo.", tituloAddArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalShelfArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de estante.", tituloAddArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalVaultArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de boveda.", tituloAddArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nameArticles = txtNameArticles.Text;
            this.descriptionArticles = txtDescriptionArticles.Text;
            this.priceArticles = Convert.ToDecimal(txtPriceArticles.Text);
            this.totalShelfArticles = Convert.ToInt32(txtTotalShelfArticles.Text);
            this.totalVaultArticles = Convert.ToInt32(txtTotalVaultArticles.Text);
            this.idStore = Convert.ToInt32(cmbTiendaArticles.SelectedValue.ToString());

            this.esGuardar = true;

            this.Close();
        }
        private void btnEditarArticles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameArticles.Text))
            {
                MessageBox.Show("Debe agregar el nombre del articulo.", tituloEditArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescriptionArticles.Text))
            {
                MessageBox.Show("Debe agregar la descripcion del articulo.", tituloEditArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPriceArticles.Text))
            {
                MessageBox.Show("Debe agregar el precio del articulo.", tituloEditArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalShelfArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de estante.", tituloEditArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalVaultArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de boveda.", tituloEditArticles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nameArticles = txtNameArticles.Text;
            this.descriptionArticles = txtDescriptionArticles.Text;
            this.priceArticles = Convert.ToDecimal(txtPriceArticles.Text);
            this.totalShelfArticles = Convert.ToInt32(txtTotalShelfArticles.Text);
            this.totalVaultArticles = Convert.ToInt32(txtTotalVaultArticles.Text);
            this.idStore = Convert.ToInt32(cmbTiendaArticles.SelectedValue.ToString());

            this.esGuardar = true;

            this.Close();
        }
        private void btnCancelarArticles_Click(object sender, EventArgs e)
        {
            this.esGuardar = false;

            this.Close();
        }
        #endregion
    }
}
