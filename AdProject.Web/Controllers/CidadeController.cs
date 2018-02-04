using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdProject.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace AdProject.Web.Controllers
{
    public class CidadeController : Controller
    {
        public ICidadeAplicacao Aplicacao { get; set; }

        public CidadeController(ICidadeAplicacao aplicacao)
        {
            if (aplicacao == null)
                throw new ArgumentNullException("CidadeAplicacao não pode ser nulo");

            this.Aplicacao = aplicacao;
        }

        public async Task<IActionResult> Listar(int Id) {
            var cidades = await Aplicacao.FiltrarAsync(Id);

            return Json(cidades);
        }
    }
}