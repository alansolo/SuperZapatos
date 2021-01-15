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

namespace SuperZapatosNC
{
    public partial class Form1 : Form
    {
        object listStores;
        public Form1()
        {
            InitializeComponent();

            CargarStore();

            CargarArticles();
            
        }  
        public void CargarStore()
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
        public void CargarArticles()
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
                        listStores = (from a in stores
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

                        dgvArticles.DataSource = listStores;
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
        public void CargarArticles(int id)
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
                        listStores = (from a in stores
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

                        dgvArticles.DataSource = listStores;
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

            CargarArticles(idNumero);
        }

        private void dgvStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {

            }
        }
    }
}
