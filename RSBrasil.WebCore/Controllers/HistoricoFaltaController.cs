using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSBrasil.Model.Entidades;
using System.Net.Http;
using Newtonsoft.Json;
using RSBRasil.Model.Entidades;
using RSBrasil.Model.DTOs;

namespace RSBrasil.WebCore.Controllers
{
    public class HistoricoFaltaController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoFaltaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<FuncionarioFaltaDTO> faltas = GetFaltasAsync();
            return View(faltas);
        }

        public ActionResult Novo()
        {
            //Task<List<Cliente>> clientes = Testar();

            ViewBag.IdCliente = new SelectList
                (
                    GetClienteAsync(),
                    "Id",
                    "NomeFantasia"
                );

            ViewBag.IdFuncionario = new SelectList
                (
                    GetFuncionarioAsync(),
                    "Id",
                    "Nome"
                );

            return View();
        }

        public List<FuncionarioFaltaDTO> GetFaltasAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var urlConfig = _configuration.GetSection("Listagem");
                string url = urlConfig.GetValue<string>("EPListarFaltas");
                var response = client.GetStringAsync(url);
                var faltas = JsonConvert.DeserializeObject<List<FuncionarioFaltaDTO>>(response.Result);
                return faltas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Funcionario> GetFuncionarioAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var urlConfig = _configuration.GetSection("Listagem");
                string url = urlConfig.GetValue<string>("EPListarFuncionarios");
                var response = client.GetStringAsync(url);
                List<Funcionario> funcionarios = new List<Funcionario>();
                if (response.Result != null && response.Result.Length > 10)
                    funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(response.Result);

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<List<Cliente>> Testar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}