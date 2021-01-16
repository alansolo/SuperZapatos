using Newtonsoft.Json.Linq;
using SuperZapatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForm_SuperZapatos
{
    public partial class AgregarEditarStore : Form
    {
        public int id;
        public bool esGuardar;
        public string nameStore;
        public string addressStore;
        public AgregarEditarStore()
        {
            InitializeComponent();
            this.esGuardar = false;
            this.nameStore = string.Empty;
            this.addressStore = string.Empty;
    }
        private void btnGuardarStore_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNameStore.Text))
            {
                MessageBox.Show("Debe agregar el nombre de la tienda.", "Agregar Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(txtAddressStore.Text))
            {
                MessageBox.Show("Debe agregar la direccion de la tienda.", "Agregar Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nameStore = txtNameStore.Text.Trim();
            this.addressStore = txtAddressStore.Text.Trim();

            this.esGuardar = true;

            this.Close();
        }
        private void btnCancelarStore_Click(object sender, EventArgs e)
        {
            this.esGuardar = false;

            this.Close();
        }
    }
}
