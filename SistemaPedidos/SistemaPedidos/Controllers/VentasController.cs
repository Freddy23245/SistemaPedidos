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
            var cust = await context.Clientes.ToListAsync();
            var tipo = await context.Tipos.ToListAsync();
            ViewBag.Tipos = tipo;
            ViewBag.Clientes = cust;
            //Tuple<Ventas, Pedido> Model = new Tuple<Ventas, Pedido>(Venta, new Pedido());
            return View(xvent);
        }
        [BindProperty]
        public Ventas venta { get; set; }
        public async Task<IActionResult> Registrar()
        {
            var vent = await context.Venta.Where(x=> x.IdVenta == venta.IdVenta).AnyAsync();

            if (!vent)
                context.Venta.Add(venta);
            else
            {
                context.Venta.Attach(venta);
                context.Entry(venta).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Nuevo.cshtml", "Pedidos");
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var VentDelete = await context.Venta.FindAsync(id);

            if (VentDelete == null)
            {
                return StatusCode(404);
            }
            else
                context.Venta.Remove(VentDelete);
            context.SaveChanges();
            return Redirect("/Ventas/");
        }

    }
}
