using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_SuperZapatos;

namespace SuperZapatos
{
    public partial class StoresArticles : Form
    {
        object listStores;
        object listArticles;
        public StoresArticles()
        {
            InitializeComponent();

            LoadStore();

            LoadArticles();
            
        }  
        public void LoadStore()
        {
            try
            {
                //CARGAR STORES
                HttpClient client = new HttpClient();
                var responseTask = client.GetAsync(ConfigurationManager.AppSettings["ApiStores"]);
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var respuestaString = responseTask.Result.Content.ReadAsStringAsync();
                    respuestaString.Wait();
                    JObject objetoJson = JObject.Parse(respuestaString.Result);
                    var success = objetoJson["success"];
                    if ((bool)success)
                    {
                        var total_elements = objetoJson["total_elements"];
                        var stores = objetoJson["stores"];
                        listStores = (from a in stores
                                      select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          address = a["address"]
                                      }).ToList();

                        dgvStore.DataSource = listStores;
                        dgvStore.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var stores = objetoJson["stores"];
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void LoadArticles()
        {
            try
            {
                //CARGAR STORES
                HttpClient client = new HttpClient();
                var responseTask = client.GetAsync(ConfigurationManager.AppSettings["ApiArticles"]);
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var respuestaString = responseTask.Result.Content.ReadAsStringAsync();
                    respuestaString.Wait();
                    JObject objetoJson = JObject.Parse(respuestaString.Result);
                    var success = objetoJson["success"];
                    if ((bool)success)
                    {
                        var total_elements = objetoJson["total_elements"];
                        var stores = objetoJson["articles"];
                        listArticles = (from a in stores
                                      select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          description = a["description"],
                                          price = a["price"],
                                          total_in_shelf = a["total_in_shelf"],
                                          total_in_vault = a["total_in_vault"],
                                          store_name = a["store_name"]
                                      }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var stores = objetoJson["stores"];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void LoadArticles(int id)
        {
            try
            {
                //CARGAR STORES
                HttpClient client = new HttpClient();
                var responseTask = client.GetAsync(ConfigurationManager.AppSettings["ApiArticlesStores"] + "/" + id);
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var respuestaString = responseTask.Result.Content.ReadAsStringAsync();
                    respuestaString.Wait();
                    JObject objetoJson = JObject.Parse(respuestaString.Result);
                    var success = objetoJson["success"];
                    if ((bool)success)
                    {
                        var total_elements = objetoJson["total_elements"];
                        var stores = objetoJson["articles"];
                        listArticles = (from a in stores
                                      select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          description = a["description"],
                                          price = a["price"],
                                          total_in_shelf = a["total_in_shelf"],
                                          total_in_vault = a["total_in_vault"],
                                          store_name = a["store_name"]
                                      }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var stores = objetoJson["stores"];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnAgregarStore_Click(object sender, EventArgs e)
        {
            AgregarEditarStore agregarStore = new AgregarEditarStore();
            agregarStore.ShowDialog();

            if(agregarStore.esGuardar)
            {
                var store = (dynamic)new JObject();
                store.name = agregarStore.nameStore;
                store.address = agregarStore.addressStore;

                AddStore(store);
            }
        }
        private void btnBuscarArticlesStores_Click(object sender, EventArgs e)
        {
            string idString = txtBuscarArticlesStores.Text;
            int idNumero;

            bool esNumero = Int32.TryParse(idString, out idNumero);

            if(!esNumero)
            {
                MessageBox.Show("Debe agregar un numero en el campo de Id Tienda", "Buscar Articulos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LoadArticles(idNumero);
        }
        private void dgvStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //EDITAR STORE
            if (e.ColumnIndex == 0)
            {

            }
            //ELIMINAR STORE
            else if(e.ColumnIndex == 1)
            {
                DialogResult respuestaEliminar = MessageBox.Show("¿Estas seguro de que quieres eliminar el Tienda?", "Eliminar Tienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuestaEliminar.ToString().ToUpper() == "YES")
                {
                    int idDelete = Convert.ToInt32(dgvStore.Rows[e.RowIndex].Cells["id"].Value.ToString());

                    DeleteStore(idDelete);
                }
            }
        }
        private void AddStore(JObject store)
        {
            try 
            {
                //CARGAR STORES
                HttpClient client = new HttpClient();
                var content = new StringContent(store.ToString(), Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(ConfigurationManager.AppSettings["ApiStoresAdd"], content);
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var respuestaString = responseTask.Result.Content.ReadAsStringAsync();
                    respuestaString.Wait();
                    JObject objetoJson = JObject.Parse(respuestaString.Result);
                    var success = objetoJson["success"];
                    if ((bool)success)
                    {
                        var total_elements = objetoJson["total_elements"];
                        var stores = objetoJson["stores"];
                        listStores = (from a in stores
                                      select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          address = a["address"]
                                      }).ToList();

                        dgvStore.DataSource = listStores;
                        dgvStore.Refresh();

                        MessageBox.Show("Se agrego la Tienda de forma correcta.", "Agregar Tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void DeleteStore(int id)
        {
            //ELIMINAR STORES
            HttpClient client = new HttpClient();
            var responseTask = client.DeleteAsync(ConfigurationManager.AppSettings["ApiStoresDelete"] + "/" + id);
            responseTask.Wait();

            if (responseTask.Result.IsSuccessStatusCode)
            {
                var respuestaString = responseTask.Result.Content.ReadAsStringAsync();
                respuestaString.Wait();
                JObject objetoJson = JObject.Parse(respuestaString.Result);
                var success = objetoJson["success"];
                if ((bool)success)
                {
                    var total_elements = objetoJson["total_elements"];
                    var stores = objetoJson["stores"];
                    listStores = (from a in stores
                                  select new
                                  {
                                      id = a["id"],
                                      name = a["name"],
                                      address = a["address"]
                                  }).ToList();

                    dgvStore.DataSource = listStores;
                    dgvStore.Refresh();

                    MessageBox.Show("Se elimino la Tienda de forma correcta.", "Eliminar Tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var error_code = objetoJson["error_code"];
                    var stores = objetoJson["stores"];
                }
            }
        }
        private void EditStore(int id, JObject store)
        {

        }
    }
}
