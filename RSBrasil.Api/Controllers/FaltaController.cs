using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSBrasil.Business;
using RSBrasil.Model.DTOs;
using Microsoft.AspNetCore.Http;

namespace RSBrasil.API.Controllers
{
    [Route("api/[controller]")]
    public class FaltaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("ListarFaltas")]
        public JsonResult ListarFaltas()
        {
            try
            {
                HistoricoFaltasBusiness negocio = new HistoricoFaltasBusiness();
                List<FuncionarioFaltaDTO> lista = new List<FuncionarioFaltaDTO>();
                lista = negocio.ListarTodos();
                var result = new JsonResult(lista);
                if (result != null)
                {
                    result.StatusCode = 200;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Faltas não localizados"));
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado!"));
            }
        }
    }
}