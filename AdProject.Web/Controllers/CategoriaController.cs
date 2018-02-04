using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdProject.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace AdProject.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public ICategoriaAplicacao Aplicacao { get; set; }

        public CategoriaController(ICategoriaAplicacao aplicacao)
        {
            if (aplicacao == null)
                throw new ArgumentNullException("CategoriaAplicacao não pode ser nulo");

            this.Aplicacao = aplicacao;
        }

        public async Task<IActionResult> Listar() {
            var categorias = await Aplicacao.TodosAsync();

            return Json(categorias);
        }
    }
}