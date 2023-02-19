using MiPrimeraAppAspMVC_TiempoReal.Clases;
using MiPrimeraAppAspMVC_TiempoReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAppAspMVC_TiempoReal.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarCursos()
        {
            List<CursoCLS> lista = new List<CursoCLS>();
            //Llamamos a BBDD para obtener la informacion 
            using(BDCursoEntities1 bd = new BDCursoEntities1())
            {
                lista = (from curso in bd.Curso
                        join categoriacurso in bd.CategoriaCurso
                        on curso.IIDCATEGORIACURSO  equals categoriacurso.IIDCATEGORIACURSO
                        select new CursoCLS
                        {
                            IdCurso = curso.IIDCURSO,
                            NombreCurso = curso.NOMBRE,
                            NombreCategoria = categoriacurso.NOMBRE,
                            Precio = curso.PRECIO
                        }).ToList();
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}