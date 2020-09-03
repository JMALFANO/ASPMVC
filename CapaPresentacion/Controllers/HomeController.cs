using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ABMBodegas()
        {
            ViewBag.Message = "ABMBodegas";

            return View();
        }

        public ActionResult ABMCategorias()
        {
            ViewBag.Message = "ABMCategorias";

            return View();
        }
        public ActionResult ABMProductos()
        {
            ViewBag.Message = "ABMProductos";

            return View();
        }

        public ActionResult Bodegas()
        {
            ViewBag.Message = "Bodegas";

            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.Message = "Categorias";

            return View();
        }
        public ActionResult Productos()
        {
            ViewBag.Message = "Productos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}