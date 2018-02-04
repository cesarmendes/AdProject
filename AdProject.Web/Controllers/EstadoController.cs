using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdProject.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace AdProject.Web.Controllers
{
    public class EstadoController : Controller
    {
        public IEstadoAplicacao Aplicacao { get; set; }

        public EstadoController(IEstadoAplicacao aplicacao)
        {
            if (aplicacao == null)
                throw new ArgumentNullException("EstadoAplicacao não pode ser nulo");

            this.Aplicacao = aplicacao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listar()
        {
            var estados = await Aplicacao.TodosAsync();
            return Json(estados);
        }

    }
}