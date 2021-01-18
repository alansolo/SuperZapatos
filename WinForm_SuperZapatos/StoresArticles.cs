using log4net;
using log4net.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_SuperZapatos;

namespace SuperZapatos
{
    public partial class StoresArticles : Form
    {
        #region Variables
        object listStores;
        object listArticles;
        List<JToken> listStoresGlobal;

        const string tituloLoadStore = "Cargar Tienda";
        const string tituloLoadArticles = "Cargar Articulo";
        const string tituloAddStore = "Agregar Tienda";
        const string tituloDeleteStore = "Eliminar Tienda";
        const string tituloEditStore = "Editar Tienda";
        const string tituloAddArticle = "Agregar Articulo";
        const string tituloDeleteArticle = "Eliminar Articulo";
        const string tituloEditArticle = "Editar Articulo";

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        
        public StoresArticles()
        {
            InitializeComponent();

            //CARGAR ARCHIVO DE CONFIGURACION LOG4NET
            LoadLog();

            //CARGAR TIENDAS
            LoadStore();

            //CARGAR ARTICULOS
            LoadArticles();
        }
        
        /// <summary>
        /// METODOS CARGA INICIAL
        /// </summary>        
        #region Carga_Datos_Inicial
        public void LoadLog()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
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
                        var elementoDefault = (dynamic) new JObject();
                        elementoDefault.id = 0;
                        elementoDefault.name = "-- Seleccione --";
                        elementoDefault.address = "";

                        var total_elements = objetoJson["total_elements"];
                        var stores = objetoJson["stores"];
                        var storesCmb = stores.ToList();
                        storesCmb.Add(elementoDefault);

                        listStoresGlobal = stores.ToList();

                        listStores = (from a in stores
                                      select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          address = a["address"]
                                      }).ToList();
                        
                        //CARGAR DATA GRID CON LA LISTA DE STORE 
                        dgvStore.DataSource = listStores;
                        dgvStore.Columns["id"].HeaderText = "Id";
                        dgvStore.Columns["name"].HeaderText = "Nombre";
                        dgvStore.Columns["address"].HeaderText = "Direccion";
                        dgvStore.Refresh();

                        //CARGAR COMBO BOX CON LA LISTA DE STORE
                        object listStoresCmb = (from a in storesCmb
                                                select new
                                                {
                                                    id = a["id"],
                                                    name = a["name"],
                                                    address = a["address"]
                                                }).OrderBy(n => n.id).ToList();

                        cmbTiendaArticles.DataSource = listStoresCmb;
                        cmbTiendaArticles.DisplayMember = "name";
                        cmbTiendaArticles.ValueMember = "id";
                        cmbTiendaArticles.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 404)
                        {
                            MessageBox.Show("Registros de Tiendas no encontrados en la Base.", tituloLoadStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloLoadStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        public void LoadArticles()
        {
            try
            {
                //CARGAR ARTICLES
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
                        var articles = objetoJson["articles"];
                        listArticles = (from a in articles
                                        select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          description = a["description"],
                                          price = a["price"],
                                          total_in_shelf = a["total_in_shelf"],
                                          total_in_vault = a["total_in_vault"],
                                          store_id = a["store_id"],
                                          store_name = a["store_name"]
                                      }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Columns["store_id"].Visible = false;
                        dgvArticles.Columns["id"].HeaderText = "Id";
                        dgvArticles.Columns["name"].HeaderText = "Nombre";
                        dgvArticles.Columns["description"].HeaderText = "Descripcion";
                        dgvArticles.Columns["price"].HeaderText = "Precio";
                        dgvArticles.Columns["total_in_shelf"].HeaderText = "Total Estante";
                        dgvArticles.Columns["total_in_vault"].HeaderText = "Total Boveda";
                        dgvArticles.Columns["store_name"].HeaderText = "Tienda";
                        dgvArticles.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 404)
                        {
                            MessageBox.Show("Registros de Articulos no encontrados en la Base.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        public void LoadArticles(int id)
        {
            try
            {
                //CARGAR ARTICLES POR ID
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
                                          store_id = a["store_id"],
                                          store_name = a["store_name"]
                                      }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Columns["store_id"].Visible = false;
                        dgvArticles.Columns["id"].HeaderText = "Id";
                        dgvArticles.Columns["name"].HeaderText = "Nombre";
                        dgvArticles.Columns["description"].HeaderText = "Descripcion";
                        dgvArticles.Columns["price"].HeaderText = "Precio";
                        dgvArticles.Columns["total_in_shelf"].HeaderText = "Total Estante";
                        dgvArticles.Columns["total_in_vault"].HeaderText = "Total Boveda";
                        dgvArticles.Columns["store_name"].HeaderText = "Tienda";
                        dgvArticles.Refresh();
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];
                        
                        if(Convert.ToInt32(error_code.ToString()) == 404)
                        {
                            MessageBox.Show("Registros no encontrados con la Tienda seleccionada.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvArticles.DataSource = null;
                            dgvArticles.Refresh();

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloLoadArticles, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvArticles.DataSource = null;
                dgvArticles.Refresh();

                log.Error(ex.Message);
            }
        }
        #endregion
        
        /// <summary>
        /// METODOS TIENDA
        /// </summary>
        #region Metodos_Tienda
        private void btnAgregarStore_Click(object sender, EventArgs e)
        {
            //AGREGAR STORE
            AgregarEditarStore agregarStore = new AgregarEditarStore(AgregarEditarStore.Tipo.Add, "", "");
            agregarStore.Text = "Agregar Tienda";
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
            if (Convert.ToInt32(cmbTiendaArticles.SelectedValue.ToString()) == 0)
            {
                //CARGAR TODOS LOS ARTICLES POR DEFAULT
                LoadArticles();
            }
            else
            {
                //CARGAR ARTICLES POR ID
                string idString = cmbTiendaArticles.SelectedValue.ToString(); //txtBuscarArticlesStores.Text;
                int idNumero;

                bool esNumero = Int32.TryParse(idString, out idNumero);

                if (!esNumero)
                {
                    MessageBox.Show("Debe agregar un numero en el campo de Id Tienda.", "Buscar Articulos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                LoadArticles(idNumero);
            }
        }
        private void dgvStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //EDITAR STORE
            if (e.ColumnIndex == 0)
            {
                int idEdit = Convert.ToInt32(dgvStore.Rows[e.RowIndex].Cells["id"].Value.ToString());
                string nameStore = dgvStore.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string addressStore = dgvStore.Rows[e.RowIndex].Cells["address"].Value.ToString();

                AgregarEditarStore agregarStore = new AgregarEditarStore(AgregarEditarStore.Tipo.Edit, nameStore, addressStore);
                agregarStore.Text = "Editar Store";
                agregarStore.ShowDialog();

                if (agregarStore.esGuardar)
                {
                    var store = (dynamic)new JObject();
                    store.id = idEdit;
                    store.name = agregarStore.nameStore;
                    store.address = agregarStore.addressStore;

                    EditStore(idEdit, store);
                }

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
                        dgvStore.Columns["id"].HeaderText = "Id";
                        dgvStore.Columns["name"].HeaderText = "Nombre";
                        dgvStore.Columns["address"].HeaderText = "Direccion";
                        dgvStore.Refresh();

                        MessageBox.Show("Se agrego la Tienda de forma correcta.", tituloAddStore, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloAddStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloAddStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloAddStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        private void DeleteStore(int id)
        {
            try
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
                        dgvStore.Columns["id"].HeaderText = "Id";
                        dgvStore.Columns["name"].HeaderText = "Nombre";
                        dgvStore.Columns["address"].HeaderText = "Direccion";
                        dgvStore.Refresh();

                        MessageBox.Show("Se elimino la Tienda de forma correcta.", tituloDeleteStore, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloDeleteStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloDeleteStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloDeleteStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        private void EditStore(int id, JObject store)
        {
            try
            {
                //EDITAR STORES
                HttpClient client = new HttpClient();
                var content = new StringContent(store.ToString(), Encoding.UTF8, "application/json");
                var responseTask = client.PutAsync(ConfigurationManager.AppSettings["ApiStoresEdit"] + "/" + id, content);
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
                        dgvStore.Columns["id"].HeaderText = "Id";
                        dgvStore.Columns["name"].HeaderText = "Nombre";
                        dgvStore.Columns["address"].HeaderText = "Direccion";
                        dgvStore.Refresh();

                        MessageBox.Show("Se edito la Tienda de forma correcta.", tituloEditStore, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloEditStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloEditStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloEditStore, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        #endregion
        
        /// <summary>
        /// METODOS ARTICULOS
        /// </summary>
        #region Metodos_Articulos
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            //AGREGAR STORE
            AgregarEditarArticles agregarArticles = new AgregarEditarArticles(AgregarEditarArticles.Tipo.Add, "", "", 0, 0, 0, 0, listStores);
            agregarArticles.Text = "Agregar Articulo";
            agregarArticles.ShowDialog();

            if (agregarArticles.esGuardar)
            {
                var article = (dynamic)new JObject();
                article.name = agregarArticles.nameArticles;
                article.description = agregarArticles.descriptionArticles;
                article.price = agregarArticles.priceArticles;
                article.total_in_shelf = agregarArticles.totalShelfArticles;
                article.total_in_vault = agregarArticles.totalVaultArticles;
                article.store_id = agregarArticles.idStore;

                AddArticles(article);
            }
        }
        private void dgvArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //EDITAR STORE
            if (e.ColumnIndex == 0)
            {
                int idEdit = Convert.ToInt32(dgvArticles.Rows[e.RowIndex].Cells["id"].Value.ToString());
                string nameArticles = dgvArticles.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string descriptionArticles = dgvArticles.Rows[e.RowIndex].Cells["description"].Value.ToString();
                decimal priceArticles = Convert.ToDecimal(dgvArticles.Rows[e.RowIndex].Cells["price"].Value.ToString());
                int totalShelfArticles = Convert.ToInt32(dgvArticles.Rows[e.RowIndex].Cells["total_in_shelf"].Value.ToString());
                int totalVaultArticles = Convert.ToInt32(dgvArticles.Rows[e.RowIndex].Cells["total_in_vault"].Value.ToString());
                int storeIdArticles = Convert.ToInt32(dgvArticles.Rows[e.RowIndex].Cells["store_id"].Value.ToString());

                
                var selectTienda = (from a in listStoresGlobal
                                   where a["id"].ToString() == storeIdArticles.ToString()
                                   select new
                                   {
                                       id = a["id"],
                                       name = a["name"],
                                       address = a["address"]
                                   }).FirstOrDefault();
                //AGREGAR STORE
                AgregarEditarArticles agregarArticles = new AgregarEditarArticles(AgregarEditarArticles.Tipo.Edit, nameArticles, 
                                                                                    descriptionArticles, priceArticles, totalShelfArticles, 
                                                                                    totalVaultArticles, selectTienda, listStores);
                agregarArticles.Text = "Editar Articulo";
                agregarArticles.ShowDialog();

                if (agregarArticles.esGuardar)
                {
                    var article = (dynamic)new JObject();
                    article.id = idEdit;
                    article.name = agregarArticles.nameArticles;
                    article.description = agregarArticles.descriptionArticles;
                    article.price = agregarArticles.priceArticles;
                    article.total_in_shelf = agregarArticles.totalShelfArticles;
                    article.total_in_vault = agregarArticles.totalVaultArticles;
                    article.store_id = agregarArticles.idStore;

                    EditArticles(idEdit, article);
                }
            }
            //ELIMINAR STORE
            else if (e.ColumnIndex == 1)
            {
                DialogResult respuestaEliminar = MessageBox.Show("¿Estas seguro de que quieres eliminar el Articulo?", "Eliminar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuestaEliminar.ToString().ToUpper() == "YES")
                {
                    int idDelete = Convert.ToInt32(dgvArticles.Rows[e.RowIndex].Cells["id"].Value.ToString());

                    DeleteArticles(idDelete);
                }
            }
        }
        private void AddArticles(JObject article)
        {
            try
            {
                //CARGAR STORES
                HttpClient client = new HttpClient();
                var content = new StringContent(article.ToString(), Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(ConfigurationManager.AppSettings["ApiArticlesAdd"], content);
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
                        var articles = objetoJson["articles"];
                        listArticles = (from a in articles
                                        select new
                                      {
                                          id = a["id"],
                                          name = a["name"],
                                          description = a["description"],
                                          price = a["price"],
                                          total_in_shelf = a["total_in_shelf"],
                                          total_in_vault = a["total_in_vault"],
                                          store_id = a["store_id"],
                                          store_name = a["store_name"]
                                      }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Columns["store_id"].Visible = false;
                        dgvArticles.Columns["id"].HeaderText = "Id";
                        dgvArticles.Columns["name"].HeaderText = "Nombre";
                        dgvArticles.Columns["description"].HeaderText = "Descripcion";
                        dgvArticles.Columns["price"].HeaderText = "Precio";
                        dgvArticles.Columns["total_in_shelf"].HeaderText = "Total Estante";
                        dgvArticles.Columns["total_in_vault"].HeaderText = "Total Boveda";
                        dgvArticles.Columns["store_name"].HeaderText = "Tienda";
                        dgvArticles.Refresh();

                        MessageBox.Show("Se agrego el Articulo de forma correcta.", tituloAddArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloAddArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloAddArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloAddArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        private void DeleteArticles(int id)
        {
            try
            {
                //ELIMINAR STORES
                HttpClient client = new HttpClient();
                var responseTask = client.DeleteAsync(ConfigurationManager.AppSettings["ApiArticlesDelete"] + "/" + id);
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
                        var articles = objetoJson["articles"];
                        listArticles = (from a in articles
                                        select new
                                        {
                                            id = a["id"],
                                            name = a["name"],
                                            description = a["description"],
                                            price = a["price"],
                                            total_in_shelf = a["total_in_shelf"],
                                            total_in_vault = a["total_in_vault"],
                                            store_id = a["store_id"],
                                            store_name = a["store_name"]
                                        }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Columns["store_id"].Visible = false;
                        dgvArticles.Columns["id"].HeaderText = "Id";
                        dgvArticles.Columns["name"].HeaderText = "Nombre";
                        dgvArticles.Columns["description"].HeaderText = "Descripcion";
                        dgvArticles.Columns["price"].HeaderText = "Precio";
                        dgvArticles.Columns["total_in_shelf"].HeaderText = "Total Estante";
                        dgvArticles.Columns["total_in_vault"].HeaderText = "Total Boveda";
                        dgvArticles.Columns["store_name"].HeaderText = "Tienda";
                        dgvArticles.Refresh();

                        MessageBox.Show("Se elimino el Articulo de forma correcta.", tituloDeleteArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloDeleteArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloDeleteArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloDeleteArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        private void EditArticles(int id, JObject article)
        {
            try
            {
                //EDITAR STORES
                HttpClient client = new HttpClient();
                var content = new StringContent(article.ToString(), Encoding.UTF8, "application/json");
                var responseTask = client.PutAsync(ConfigurationManager.AppSettings["ApiArticlesEdit"] + "/" + id, content);
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
                        var articles = objetoJson["articles"];
                        listArticles = (from a in articles
                                        select new
                                        {
                                            id = a["id"],
                                            name = a["name"],
                                            description = a["description"],
                                            price = a["price"],
                                            total_in_shelf = a["total_in_shelf"],
                                            total_in_vault = a["total_in_vault"],
                                            store_id = a["store_id"],
                                            store_name = a["store_name"]
                                        }).ToList();

                        dgvArticles.DataSource = listArticles;
                        dgvArticles.Columns["store_id"].Visible = false;
                        dgvArticles.Columns["id"].HeaderText = "Id";
                        dgvArticles.Columns["name"].HeaderText = "Nombre";
                        dgvArticles.Columns["description"].HeaderText = "Descripcion";
                        dgvArticles.Columns["price"].HeaderText = "Precio";
                        dgvArticles.Columns["total_in_shelf"].HeaderText = "Total Estante";
                        dgvArticles.Columns["total_in_vault"].HeaderText = "Total Boveda";
                        dgvArticles.Columns["store_name"].HeaderText = "Tienda";
                        dgvArticles.Refresh();

                        MessageBox.Show("Se edito el Articulo de forma correcta.", tituloEditArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var error_code = objetoJson["error_code"];
                        var error_msg = objetoJson["error_msg"];

                        if (Convert.ToInt32(error_code.ToString()) == 400)
                        {
                            MessageBox.Show("Los parametros enviados al servicio son incorrectos.", tituloEditArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }

                        if (Convert.ToInt32(error_code.ToString()) == 500)
                        {
                            MessageBox.Show("Ocurrio un error al consumir el servicio, intente nuevamente o consulte con el administrador de sistemas.", tituloEditArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvStore.DataSource = null;
                            dgvStore.Refresh();

                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado, intente nuevamente o consulte con el administrador de sistemas.", tituloEditArticle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvStore.DataSource = null;
                dgvStore.Refresh();

                log.Error(ex.Message);
            }
        }
        #endregion
    }
}
