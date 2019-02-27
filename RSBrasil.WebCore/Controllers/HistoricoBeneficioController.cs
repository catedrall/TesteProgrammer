using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.DTOs;
using RSBrasil.Model.Entidades;
using RSBrasil.Model.Enuns;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.WebCore.Controllers
{
    public class HistoricoBeneficioController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoBeneficioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Novo()
        {
            Task<List<HistoricoBeneficios>> beneficios = Testar();

            var enumBeneficios = from ETipoBeneficio e in Enum.GetValues(typeof(ETipoBeneficio))
                              select new
                              {
                                  ID = (int)e,
                                  Name = e.ToString()
                              };
            ViewBag.BeneficiosList = new SelectList(enumBeneficios, "ID", "Name");

            ViewBag.IdFuncionario = new SelectList
                (
                    GetFuncionarioAsync(),
                    "Id",
                    "Nome"
                );

            return View();
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

        public async Task<List<HistoricoBeneficios>> Testar()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                List<HistoricoBeneficios> beneficios = JsonConvert.DeserializeObject<List<HistoricoBeneficios>>(content);
                return beneficios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}