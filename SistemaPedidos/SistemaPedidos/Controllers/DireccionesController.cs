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


            var cusDir = await context.Clientes.Select(x => new {x.IdCliente,NombreCliente = x.Nombre +"  "+x.Apellido}).ToListAsync();

            var id = 0;
           var dir = await context.Direccions.Include(x => x.IdClienteNavigation).ToListAsync();
            Direccion direc = new Direccion();
            ViewBag.Direccion = dir;
            ViewBag.CliDire = cusDir;
            return View(direc);
        }
        [BindProperty]
        public Direccion direccion { get; set; }
        public async Task<IActionResult> Nuevo()
        {
            var NewDir = await context.Direccions.Where(x => x.IdDireccion == direccion.IdDireccion).AnyAsync();

            if(!NewDir)
            {
                context.Direccions.Add(direccion);
            }else
            {
                context.Direccions.Attach(direccion);
                context.Entry(direccion).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return Redirect("Index");
        }

        public async Task<IActionResult> Modificar(int id)
        {
            var cus = await context.Clientes.Select(x => new { x.IdCliente, NombreCliente = x.Nombre + "  " + x.Apellido }).ToListAsync();
            var dir = await context.Direccions.FindAsync(id);
            ViewBag.Customers = cus;
            if (dir == null)
                return RedirectToAction("Index");

            return View(dir);
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var dir = await context.Direccions.FindAsync(id);

            if (dir == null)
                return StatusCode(404);
            else
            {
                context.Direccions.Remove(dir);
                context.SaveChanges();
                return Redirect("/Direcciones/");
            }
        }
    }
}
