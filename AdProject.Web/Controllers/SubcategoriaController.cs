using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdProject.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace AdProject.Web.Controllers
{
    public class SubcategoriaController : Controller
    {
        public ISubcategoriaAplicacao Aplicacao { get; set; }

        public SubcategoriaController(ISubcategoriaAplicacao aplicacao)
        {
            if (aplicacao == null)
                throw new ArgumentNullException("SubcategoriaAplicacao não pode ser nulo");

            this.Aplicacao = aplicacao;
        }

        public async Task<IActionResult> Listar(int Id)
        {
            var subcategorias = await Aplicacao.TodosAsync();

            return Json(subcategorias);
        }
    }
}