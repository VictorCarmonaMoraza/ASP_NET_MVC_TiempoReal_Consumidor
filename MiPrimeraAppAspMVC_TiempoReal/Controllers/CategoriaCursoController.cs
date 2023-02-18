using MiPrimeraAppAspMVC_TiempoReal.Clases;
using MiPrimeraAppAspMVC_TiempoReal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MiPrimeraAppAspMVC_TiempoReal.Controllers
{
    public class CategoriaCursoController : Controller
    {
        // GET: CategoriaCurso
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retorna una lista de categorias
        /// </summary>
        /// <returns></returns>
        public JsonResult listarCategoriaCurso()
        {
            List<CategoriaCursoCLS> lista = new List<CategoriaCursoCLS>();
            using(BDCursoEntities1 bd = new BDCursoEntities1())
            {
                lista = bd.CategoriaCurso.Select(p=>new CategoriaCursoCLS
                {
                    IdCategoriaCurso = p.IIDCATEGORIACURSO,
                    Nombre = p.NOMBRE
                }).ToList();
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}