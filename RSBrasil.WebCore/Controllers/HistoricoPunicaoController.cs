﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBRasil.Model.Entidades;

namespace RSBrasil.WebCore.Controllers
{
    public class HistoricoPunicaoController : Controller
    {
        private IConfiguration _configuration;

        public HistoricoPunicaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo()
        {
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
    }
}