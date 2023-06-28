using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;

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
            var _producto = await context.Productos.FindAsync(Prod1.IdProducto);
            if (_producto == null)
            {

                context.Productos.Add(Prod1);
            }

            else
            {



                double.TryParse(Prod1.PrecioCompra.ToString(), out double precioDecimal);
                var formato = new CultureInfo("es-AR");
                formato.NumberFormat.CurrencySymbol = "$";
                formato.NumberFormat.CurrencyDecimalSeparator = ",";
                formato.NumberFormat.CurrencyGroupSeparator = ".";
                CultureInfo.DefaultThreadCurrentCulture = formato;
                CultureInfo.DefaultThreadCurrentUICulture = formato;



                //var precio = precioDecimal.ToString("N1");
                _producto.Nombre = Prod1.Nombre;
                _producto.IdMarca = Prod1.IdMarca;
                _producto.Color = Prod1.Color;
                _producto.Modelo = Prod1.Modelo;
                _producto.Talle = Prod1.Talle;
                _producto.Descripcion = Prod1.Descripcion;
                _producto.PrecioCompra = Prod1.PrecioCompra;
                _producto.Precio = Prod1.Precio;
                _producto.Stock = Prod1.Stock;
                //context.Productos.Attach(Prod1);
                //context.Entry(Prod1).State = EntityState.Modified;
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
