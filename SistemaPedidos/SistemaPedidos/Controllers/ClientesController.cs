using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    public class ClientesController : Controller
    {
        PedidosContext context;

        public ClientesController(PedidosContext _context)
        {
            context = _context;
        }
    
        public async Task<IActionResult> Index()
        {
            var customers = await context.Clientes.ToListAsync();
            Cliente cli = new Cliente();
            ViewBag.clientes = customers;
            return View(cli);
        }
        [BindProperty]
        public Cliente cli3 { get; set; }
        public async Task<IActionResult> NuevoCliente()
        {
            var id= cli3.IdCliente;
            var _cliente = await context.Clientes.Where(x => x.IdCliente == cli3.IdCliente).AnyAsync();

            if (!_cliente)
            {
                context.Clientes.Add(cli3);
            }
            else
            {
                context.Clientes.Attach(cli3);
                context.Entry(cli3).State = EntityState.Modified;

            }
            await context.SaveChangesAsync();
            return Redirect("Index");
        }

        public async Task<IActionResult> Modificar(int id)
        {
            var cus = await context.Clientes.FindAsync(id);
            if (cus == null)
                return RedirectToAction("Index");

            return View(cus);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var cliDelete = await context.Clientes.FindAsync(id);

            if (cliDelete == null)
            {
                return StatusCode(404);
            }
            else
                context.Clientes.Remove(cliDelete);
            context.SaveChanges();
            return Redirect("/Clientes/");
        }
    }

    
}
