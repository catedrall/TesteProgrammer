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
    public class TipoAfastamentoController : Controller
    {

        private IConfiguration _configuration;

        public TipoAfastamentoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<TipoAfastamentos> tipoDeAfastamentos = GetAfastamentoAsync();
            return View(tipoDeAfastamentos);
        }

        public ActionResult Novo()
        {
            var enumDocs = from EDocAfastamento e in Enum.GetValues(typeof(EDocAfastamento))
                              select new
                              {
                                  ID = (int)e,
                                  Name = e.ToString()
                              };
            ViewBag.DocsList = new SelectList(enumDocs, "ID", "Name");

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public List<TipoAfastamentos> GetAfastamentoAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var urlConfig = _configuration.GetSection("Listagem");
                string url = urlConfig.GetValue<string>("EPListarAfastamento");
                var response = client.GetStringAsync(url);
                List<TipoAfastamentos> afastamentos = new List<TipoAfastamentos>();
                if (response.Result != null && response.Result.Length > 10)
                    afastamentos = JsonConvert.DeserializeObject<List<TipoAfastamentos>>(response.Result);
                return afastamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}