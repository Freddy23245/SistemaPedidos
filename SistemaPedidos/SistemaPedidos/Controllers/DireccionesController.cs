using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    public class DireccionesController : Controller
    {
        PedidosContext context;
        public DireccionesController(PedidosContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var dir = await context.Direccions.Include(x => x.IdClienteNavigation).ToListAsync();
            Direccion direc = new Direccion();
            ViewBag.Direccion = dir;
            return View(direc);
        }
    }
}
