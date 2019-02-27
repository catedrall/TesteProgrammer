﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RSBrasil.Model.Entidades;
using RSBRasil.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RSBrasil.Web.Controllers
{
    public class UniformeController : Controller
    {

        private IConfiguration _configuration;

        public UniformeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            List<Uniforme> afastamento = GetClienteAsync();
            return View(afastamento);
        }

        public ActionResult Novo()
        {
            ViewBag.IdFuncionario = new SelectList
                (
                    GetFuncionarioAsync(),
                    "Id",
                    "Nome"
                );

            return View();
        }

        public ActionResult Edit()
        {
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

        public List<Uniforme> GetClienteAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = _configuration["EPListarClientes"];
                var response = client.GetStringAsync(url);
                var uniforme = JsonConvert.DeserializeObject<List<Uniforme>>(response.Result);
                return uniforme;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Cliente Inserir(Form)
    }
}