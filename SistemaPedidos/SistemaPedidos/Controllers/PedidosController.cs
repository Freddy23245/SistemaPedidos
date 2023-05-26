using Microsoft.AspNetCore.Mvc;

namespace SistemaPedidos.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
