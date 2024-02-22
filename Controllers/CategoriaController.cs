using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
