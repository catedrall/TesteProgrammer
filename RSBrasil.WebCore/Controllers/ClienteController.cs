using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace RSBrasil.Web.Controllers
{
    public class ClienteController : Controller
    {

        private IConfiguration _configuration;

        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> clientes = GetClienteAsync();
            return View(clientes);
        }

        public ActionResult Novo()
        {
            var enumEstados = from EEstados e in Enum.GetValues(typeof(EEstados))
                              select new
                              {
                                  ID = (int)e,
                                  Name = e.ToString()
                              };
            ViewBag.EstadosList = new SelectList(enumEstados, "ID", "Name");

            return View();
        }

        //[HttpPost]
        //public ActionResult Novo(ClienteDTO cliente)
        //{
        //    string resultContent = string.Empty;

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    using (var client = new HttpClient())
        //    {
        //        var urlConfig = _configuration.GetSection("Insercao");
        //        string url = urlConfig.GetValue<string>("EPListarClientesInserir");
        //        string json = JsonConvert.SerializeObject(cliente);
        //        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //        var result = client.PostAsync(url, httpContent);
        //        if (result.Result != null)
        //            resultContent = result.Result.StatusCode.ToString();
        //    }

        //    return Ok(resultContent);
        //}

        public ActionResult Edit()
        {
            return View();
        }

        public List<Cliente> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var urlConfig = _configuration.GetSection("Listagem");
                string url = urlConfig.GetValue<string>("EPListarClientes");
                var response = client.GetStringAsync(url);
                List<Cliente> clientes = new List<Cliente>();
                if (response.Result != null && response.Result.Length > 10)
                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(response.Result);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}