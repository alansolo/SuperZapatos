﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BD_SuperZapatos.Models;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApi_SuperZapatos.Models;

namespace WebApi_SuperZapatos.Controllers
{
    [ApiController]
    public class ApiSuperZapatosController : ControllerBase
    {
        #region Variables
        private string connectionString;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        
        public ApiSuperZapatosController(IConfiguration config)
        {
            //CARGAR ARCHIVO DE CONFIGURACION LOG4NET
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            try
            {
                connectionString = config.GetConnectionString("DBSuperZapatos");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        
        /// <summary>
        /// METODOS REST API TIENDA
        /// </summary>
        #region Metodos_Rest_Tienda
        [HttpGet]
        [Route("services/stores")]
        public StoreResponse Stores()
        {
            StoreResponse StoreResponse = new StoreResponse();
            List<Stores> ListaStores = new List<Stores>();

            try
            {
                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    ListaStores = superZapatos.Stores.ToList();
                }

                StoreResponse.stores = ListaStores;
                StoreResponse.total_elements = ListaStores.Count;
                StoreResponse.success = true;
                StoreResponse.error_code = 0;
                StoreResponse.error_msg = string.Empty;           
            }
            catch(Exception ex)
            {
                StoreResponse.stores = new List<Stores>();
                StoreResponse.total_elements = 0;
                StoreResponse.success = false;
                StoreResponse.error_code = 500;
                StoreResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return StoreResponse;
        }
        [HttpPost]
        [Route("services/stores/add")]
        public StoreResponse Stores(Stores stores)
        {
            StoreResponse StoreResponse = new StoreResponse();
            List<Stores> ListaStores = new List<Stores>();

            try
            {
                if (stores == null)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    superZapatos.Stores.Add(stores);
                    superZapatos.SaveChanges();

                    ListaStores = superZapatos.Stores.ToList();
                }

                StoreResponse.stores = ListaStores;
                StoreResponse.total_elements = ListaStores.Count;
                StoreResponse.success = true;
                StoreResponse.error_code = 0;
                StoreResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                StoreResponse.stores = new List<Stores>();
                StoreResponse.total_elements = 0;
                StoreResponse.success = false;
                StoreResponse.error_code = 500;
                StoreResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return StoreResponse;
        }
        [HttpPut]
        [Route("services/stores/edit/{id?}")]
        public StoreResponse Stores(string id, Stores stores)
        {
            StoreResponse StoreResponse = new StoreResponse();
            List<Stores> ListaStores = new List<Stores>();
            int idNumero;

            try
            {
                if (id == null || stores == null)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                bool esNumero = Int32.TryParse(id, out idNumero);

                if (!esNumero)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                if(idNumero != stores.id)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    Stores storesEdit = superZapatos.Stores.Find(idNumero);
                    if (storesEdit == null)
                    {
                        StoreResponse.stores = new List<Stores>();
                        StoreResponse.total_elements = 0;
                        StoreResponse.success = false;
                        StoreResponse.error_code = 404;
                        StoreResponse.error_msg = "Record not Found";

                        return StoreResponse;
                    }

                    //storesEdit = stores;

                    superZapatos.Entry(storesEdit).State = EntityState.Detached;
                    superZapatos.Entry(stores).State = EntityState.Modified;

                    superZapatos.SaveChanges();

                    ListaStores = superZapatos.Stores.ToList();
                }

                StoreResponse.stores = ListaStores;
                StoreResponse.total_elements = ListaStores.Count;
                StoreResponse.success = true;
                StoreResponse.error_code = 0;
                StoreResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                StoreResponse.stores = new List<Stores>();
                StoreResponse.total_elements = 0;
                StoreResponse.success = false;
                StoreResponse.error_code = 500;
                StoreResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return StoreResponse;
        }
        [HttpDelete]
        [Route("services/stores/delete/{id?}")]
        public StoreResponse Stores(string id)
        {
            StoreResponse StoreResponse = new StoreResponse();
            List<Stores> ListaStores = new List<Stores>();
            int idNumero;

            try
            {
                if (id == null)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                bool esNumero = Int32.TryParse(id, out idNumero);

                if (!esNumero)
                {
                    StoreResponse.stores = new List<Stores>();
                    StoreResponse.total_elements = 0;
                    StoreResponse.success = false;
                    StoreResponse.error_code = 400;
                    StoreResponse.error_msg = "Bad Request";

                    return StoreResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    Stores storesDelete = superZapatos.Stores.Find(idNumero);
                    if(storesDelete == null)
                    {
                        StoreResponse.stores = new List<Stores>();
                        StoreResponse.total_elements = 0;
                        StoreResponse.success = false;
                        StoreResponse.error_code = 404;
                        StoreResponse.error_msg = "Record not Found";

                        return StoreResponse;
                    }

                    superZapatos.Stores.Remove(storesDelete);
                    superZapatos.SaveChanges();
                    
                    ListaStores = superZapatos.Stores.ToList();
                }

                StoreResponse.stores = ListaStores;
                StoreResponse.total_elements = ListaStores.Count;
                StoreResponse.success = true;
                StoreResponse.error_code = 0;
                StoreResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                StoreResponse.stores = new List<Stores>();
                StoreResponse.total_elements = 0;
                StoreResponse.success = false;
                StoreResponse.error_code = 500;
                StoreResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return StoreResponse;
        }
        #endregion

        /// <summary>
        /// METODOS REST API ARTICULOS
        /// </summary>
        #region Metodos_Rest_Articulos
        [HttpGet]
        [Route("services/articles")]
        public ArticlesResponse Articles()
        {
            ArticlesResponse ArticlesResponse = new ArticlesResponse();
            List<Articles> ListaArticles = new List<Articles>();

            try
            {
                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    superZapatos.Stores.ToList();
                    ListaArticles = superZapatos.Articles.ToList();
                }

                ArticlesResponse.articles = (from a in ListaArticles
                                             select new ApiArticles
                                             {
                                                 id = a.id,
                                                 name = a.name,
                                                 description = a.description,
                                                 price = a.price,
                                                 total_in_vault = a.total_in_vault,
                                                 total_in_shelf = a.total_in_shelf,
                                                 store_id = a.store_id,
                                                 store_name = a.store.name
                                             }
                                             ).ToList();
                ArticlesResponse.total_elements = ListaArticles.Count;
                ArticlesResponse.success = true;
                ArticlesResponse.error_code = 0;
                ArticlesResponse.error_msg = string.Empty;
            }
            catch(Exception ex)
            {
                ArticlesResponse.articles = new List<ApiArticles>();
                ArticlesResponse.total_elements = 0;
                ArticlesResponse.success = false;
                ArticlesResponse.error_code = 500;
                ArticlesResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return ArticlesResponse;
        }
        [HttpPost]
        [Route("services/articles/add")]
        public ArticlesResponse Articles(Articles articles)
        {
            ArticlesResponse ArticlesResponse = new ArticlesResponse();
            List<Articles> ListaArticles = new List<Articles>();

            try
            {
                if (articles == null)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    superZapatos.Articles.Add(articles);

                    superZapatos.SaveChanges();

                    superZapatos.Stores.ToList();
                    ListaArticles = superZapatos.Articles.ToList();
                }

                ArticlesResponse.articles = (from a in ListaArticles
                                             select new ApiArticles
                                             {
                                                 id = a.id,
                                                 name = a.name,
                                                 description = a.description,
                                                 price = a.price,
                                                 total_in_vault = a.total_in_vault,
                                                 total_in_shelf = a.total_in_shelf,
                                                 store_id = a.store_id,
                                                 store_name = a.store.name
                                             }
                                             ).ToList();
                ArticlesResponse.total_elements = ListaArticles.Count;
                ArticlesResponse.success = true;
                ArticlesResponse.error_code = 0;
                ArticlesResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                ArticlesResponse.articles = new List<ApiArticles>();
                ArticlesResponse.total_elements = 0;
                ArticlesResponse.success = false;
                ArticlesResponse.error_code = 500;
                ArticlesResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return ArticlesResponse;
        }
        [HttpPut]
        [Route("services/articles/edit/{id?}")]
        public ArticlesResponse Articles(string id, Articles articles)
        {
            ArticlesResponse ArticlesResponse = new ArticlesResponse();
            List<Articles> ListaArticles = new List<Articles>();
            int idNumero;

            try
            {
                if(id == null || articles == null)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                bool esNumero = Int32.TryParse(id, out idNumero);

                if (!esNumero)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                if(idNumero != articles.id)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    Stores storeEdit = superZapatos.Stores.Find(articles.store_id);

                    Articles articlesEdit = superZapatos.Articles.Find(idNumero);
                    if (articlesEdit == null)
                    {
                        ArticlesResponse.articles = new List<ApiArticles>();
                        ArticlesResponse.total_elements = 0;
                        ArticlesResponse.success = false;
                        ArticlesResponse.error_code = 404;
                        ArticlesResponse.error_msg = "Record not Found";

                        return ArticlesResponse;
                    }

                    superZapatos.Entry(articlesEdit).State = EntityState.Detached;
                    superZapatos.Entry(articles).State = EntityState.Modified;

                    superZapatos.SaveChanges();

                    superZapatos.Stores.ToList();
                    ListaArticles = superZapatos.Articles.ToList();
                }

                ArticlesResponse.articles = (from a in ListaArticles
                                             select new ApiArticles
                                             {
                                                 id = a.id,
                                                 name = a.name,
                                                 description = a.description,
                                                 price = a.price,
                                                 total_in_vault = a.total_in_vault,
                                                 total_in_shelf = a.total_in_shelf,
                                                 store_id = a.store_id,
                                                 store_name = a.store.name
                                             }
                                             ).ToList();
                ArticlesResponse.total_elements = ListaArticles.Count;
                ArticlesResponse.success = true;
                ArticlesResponse.error_code = 0;
                ArticlesResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                ArticlesResponse.articles = new List<ApiArticles>();
                ArticlesResponse.total_elements = 0;
                ArticlesResponse.success = false;
                ArticlesResponse.error_code = 500;
                ArticlesResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return ArticlesResponse;
        }
        [HttpDelete]
        [Route("services/articles/delete/{id?}")]
        public ArticlesResponse Articles(string id)
        {
            ArticlesResponse ArticlesResponse = new ArticlesResponse();
            List<Articles> ListaArticles = new List<Articles>();
            int idNumero;

            try
            {
                if (id == null)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                bool esNumero = Int32.TryParse(id, out idNumero);

                if (!esNumero)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    Articles articlesDelete = superZapatos.Articles.Find(idNumero);
                    if (articlesDelete == null)
                    {
                        ArticlesResponse.articles = new List<ApiArticles>();
                        ArticlesResponse.total_elements = 0;
                        ArticlesResponse.success = false;
                        ArticlesResponse.error_code = 404;
                        ArticlesResponse.error_msg = "Record not Found";

                        return ArticlesResponse;
                    }

                    superZapatos.Articles.Remove(articlesDelete);
                    superZapatos.SaveChanges();

                    superZapatos.Stores.ToList();
                    ListaArticles = superZapatos.Articles.ToList();
                }

                ArticlesResponse.articles = (from a in ListaArticles
                                             select new ApiArticles
                                             {
                                                 id = a.id,
                                                 name = a.name,
                                                 description = a.description,
                                                 price = a.price,
                                                 total_in_vault = a.total_in_vault,
                                                 total_in_shelf = a.total_in_shelf,
                                                 store_id = a.store_id,
                                                 store_name = a.store.name
                                             }
                                             ).ToList();
                ArticlesResponse.total_elements = ListaArticles.Count;
                ArticlesResponse.success = true;
                ArticlesResponse.error_code = 0;
                ArticlesResponse.error_msg = string.Empty;
            }
            catch (Exception ex)
            {
                ArticlesResponse.articles = new List<ApiArticles>();
                ArticlesResponse.total_elements = 0;
                ArticlesResponse.success = false;
                ArticlesResponse.error_code = 500;
                ArticlesResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return ArticlesResponse;
        }
        [HttpGet]
        [Route("services/articles/stores/{id?}")]
        public ArticlesResponse ArticlesStores(string id)
        {
            ArticlesResponse ArticlesResponse = new ArticlesResponse();
            List<Articles> ListaArticles = new List<Articles>();
            int idNumero;

            try
            {
                if(id == null)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                bool esNumero = Int32.TryParse(id, out idNumero);

                if(!esNumero)
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 400;
                    ArticlesResponse.error_msg = "Bad Request";

                    return ArticlesResponse;
                }

                using (DbContextSuperZapatos superZapatos = new DbContextSuperZapatos(connectionString))
                {
                    superZapatos.Stores.ToList();
                    ListaArticles = superZapatos.Articles.Where(n => n.store_id == idNumero).ToList();
                }

                if (ListaArticles.Count > 0)
                {
                    ArticlesResponse.articles = (from a in ListaArticles
                                                 select new ApiArticles
                                                 {
                                                     id = a.id,
                                                     name = a.name,
                                                     description = a.description,
                                                     price = a.price,
                                                     total_in_vault = a.total_in_vault,
                                                     total_in_shelf = a.total_in_shelf,
                                                     store_id = a.store_id,
                                                     store_name = a.store.name
                                                 }
                                                 ).ToList();
                    ArticlesResponse.total_elements = ListaArticles.Count;
                    ArticlesResponse.success = true;
                    ArticlesResponse.error_code = 0;
                    ArticlesResponse.error_msg = string.Empty;
                }
                else 
                {
                    ArticlesResponse.articles = new List<ApiArticles>();
                    ArticlesResponse.total_elements = 0;
                    ArticlesResponse.success = false;
                    ArticlesResponse.error_code = 404;
                    ArticlesResponse.error_msg = "Record not Found";
                }
            }
            catch(Exception ex)
            {
                ArticlesResponse.articles = new List<ApiArticles>();
                ArticlesResponse.total_elements = 0;
                ArticlesResponse.success = false;
                ArticlesResponse.error_code = 500;
                ArticlesResponse.error_msg = "Server Error";

                log.Error(ex.Message);
            }

            return ArticlesResponse;
        }
        #endregion
    }
}
