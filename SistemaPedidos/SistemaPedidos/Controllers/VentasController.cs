using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    public class VentasController : Controller
    {
        PedidosContext context;
        public VentasController(PedidosContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var vent = await context.Venta.Include(x => x.IdClienteNavigation).Include(t=>t.IdTipoNavigation).ToListAsync();
            Ventas xvent = new Ventas();
            ViewBag.Ventas = vent;
            return View(xvent);
        }
    }
}
