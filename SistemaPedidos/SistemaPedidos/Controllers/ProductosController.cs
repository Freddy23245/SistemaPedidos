using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

namespace SistemaPedidos.Controllers
{
    public class ProductosController : Controller
    {
        PedidosContext context;

        public ProductosController(PedidosContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var marcas = await context.Marcas.ToListAsync();
            var Prod = await context.Productos.Include(x => x.IdMarcaNavigation).ToListAsync();
            Producto Product = new Producto();
            ViewBag.Productos = Prod;
            ViewBag.Marcas = marcas;
            return View(Product);
        }
        [BindProperty]
        public Producto Prod1 { get; set; }
        public async Task<IActionResult> AgregarProducto()
        {
            var prod = await context.Productos.Where(x => x.IdProducto == Prod1.IdProducto).AnyAsync();

            if (!prod)
            {
        
                    context.Productos.Add(Prod1);
             
            }
           
            else
            {
                context.Productos.Attach(Prod1);
                context.Entry(Prod1).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return Redirect("Index");
        }
        public async Task<IActionResult> Modificar(int id)
        {
            var marcas1 = await context.Marcas.ToListAsync();
            var producto = await context.Productos.FindAsync(id);
            ViewBag.Marcas1 = marcas1;
            if (producto == null)
                return RedirectToAction("Index");

            return View(producto);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var Product = await context.Productos.FindAsync(id);

            if (Product == null)
                return StatusCode(404);
            else
            {
                context.Productos.Remove(Product);
                context.SaveChanges();
                return Redirect("/Productos/");
            }
        }
    }
}
