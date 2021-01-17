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
        public bool esGuardar;
        public string nameArticles;
        public string descriptionArticles;
        public decimal priceArticles;
        public int totalShelfArticles;
        public int totalVaultArticles;
        public int idStore;
        public enum Tipo
        {
            Add,
            Edit
        }
        public AgregarEditarArticles(Tipo tipo, string nameArticles, string descriptionArticles, decimal priceArticles,
                                        int totalShelfArticles, int totalVaultArticles, int idTienda, object listaTiendaArticles)
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
            cmbTiendaArticles.SelectedValue = idTienda;

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
        private void btnGuardarArticles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameArticles.Text))
            {
                MessageBox.Show("Debe agregar el nombre del articulo.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescriptionArticles.Text))
            {
                MessageBox.Show("Debe agregar la descripcion del articulo.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPriceArticles.Text))
            {
                MessageBox.Show("Debe agregar el precio del articulo.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalShelfArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de estante.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalVaultArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de boveda.", "Agregar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nameArticles = txtNameArticles.Text;
            this.descriptionArticles = txtDescriptionArticles.Text;
            this.priceArticles = Convert.ToDecimal(txtPriceArticles.Text);
            this.totalShelfArticles = Convert.ToInt32(txtTotalShelfArticles.Text);
            this.totalVaultArticles = Convert.ToInt32(txtTotalVaultArticles.Text);
            this.idStore = Convert.ToInt32(cmbTiendaArticles.SelectedValue);

            this.esGuardar = true;

            this.Close();
        }
        private void btnEditarArticles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameArticles.Text))
            {
                MessageBox.Show("Debe agregar el nombre del articulo.", "Editar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescriptionArticles.Text))
            {
                MessageBox.Show("Debe agregar la descripcion del articulo.", "Editar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPriceArticles.Text))
            {
                MessageBox.Show("Debe agregar el precio del articulo.", "Editar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalShelfArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de estante.", "Editar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTotalVaultArticles.Text))
            {
                MessageBox.Show("Debe agregar el total de boveda.", "Editar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nameArticles = txtNameArticles.Text;
            this.descriptionArticles = txtDescriptionArticles.Text;
            this.priceArticles = Convert.ToDecimal(txtPriceArticles.Text);
            this.totalShelfArticles = Convert.ToInt32(txtTotalShelfArticles.Text);
            this.totalVaultArticles = Convert.ToInt32(txtTotalVaultArticles.Text);
            this.idStore = Convert.ToInt32(cmbTiendaArticles.SelectedValue);

            this.esGuardar = true;

            this.Close();
        }
        private void btnCancelarArticles_Click(object sender, EventArgs e)
        {
            this.esGuardar = false;

            this.Close();
        }
    }
}
