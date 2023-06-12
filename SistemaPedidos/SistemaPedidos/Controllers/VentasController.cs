using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;
using System.Data.SqlClient;
namespace SistemaPedidos.Controllers
{
    public class VentasController : Controller
    {
        PedidosContext context;
        Models.Response res = new Models.Response();
        public VentasController(PedidosContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
           
            var vent = await context.Venta.Include(r=>r.Pedidos).Include(x => x.IdClienteNavigation).Include(t=>t.IdTipoNavigation).ToListAsync();
            Ventas xvent = new Ventas();          
            ViewBag.Ventas = vent;
        
            //Tuple<Ventas, Pedido> Model = new Tuple<Ventas, Pedido>(Venta, new Pedido());
            return View(xvent);
        }
        [BindProperty]
        public Ventas venta { get; set; }
  
        public async Task<IActionResult> Nuevo(int? id)
        {
            var valor = id;
            var _vent = await context.Venta.FindAsync(id);
            var Venta = new Ventas();
            if (_vent != null)
            {
                Venta = _vent;
            }
            var cust = await context.Clientes.ToListAsync();
            var tipo = await context.Tipos.ToListAsync();
            ViewBag.Tipos = tipo;
            ViewBag.Clientes = cust;

            ViewBag.Productos = await context.Productos.Select(x => new { x.IdProducto, NombreProducto = x.Nombre + " - " + x.IdMarcaNavigation.Nombre }).ToListAsync();
            if(id != null)
                ViewBag.Pedido = await context.Pedidos.Include(p => p.IdProductoNavigation).Where(x => x.IdVenta == id.Value).ToListAsync();
            Tuple<Ventas, Pedido> Model = new Tuple<Ventas, Pedido>(Venta, new Pedido());
           
            return View(Model);
        }

        public async Task<IActionResult> SetVentas([Bind(Prefix = "Item1")] Ventas venta1)
        {
            var _venta = await context.Venta.FindAsync(venta1.IdVenta);
         
            if (_venta == null)
            {
                context.Add(venta1);
                await context.SaveChangesAsync();
          
            }
            else
            {
                _venta.IdCliente = venta1.IdCliente;
                _venta.IdTipo = venta1.IdTipo;
                await context.SaveChangesAsync();
            }

            res.resultado = venta1.IdVenta;
            res.estado = true;
            return Json(res);
        }
        public async Task<IActionResult> SetPedidos([Bind(Prefix = "Item2")] Pedido pedido)
        {
            var Ped = await context.Pedidos.Where(x => x.IdPedido == pedido.IdPedido).AnyAsync();
            var product = await context.Productos.FirstOrDefaultAsync(p => p.IdProducto == pedido.IdProducto);
           
            if(product != null)
            {
                pedido.Total = pedido.PrecioUnitario * pedido.Cantidad;
               product.Stock -= pedido.Cantidad;
            }
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();
           
            res.resultado = pedido;
            res.mensaje = "Porducto Agregado Correctamente";
            res.res2 = pedido.IdVenta;// cree un nuevo atributo a la clase Response asi me permite pasarle el id y llamarlo en el return
            return Json(res.res2); //aca en vez de retornar todos los datos Json retornaria solo el id de venta asi me lleva al formulario Modificar donde puedo seguir agregando items
           
           
        }
   

       [HttpGet]
        public async Task<IActionResult>TraerProducto(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(p => p.IdProducto == id);
            if(producto == null)
                return NotFound();
            else
            {
                return Ok(producto);
            }
        }
       
        public async Task<IActionResult> Modificar(int? id)
        {
            var valor = id;
            var _vent = await context.Venta.FindAsync(id);
            var Venta = new Ventas();
            if (_vent != null)
            {
                Venta = _vent;
            }
            var cust = await context.Clientes.ToListAsync();
            var tipo = await context.Tipos.ToListAsync();
            ViewBag.Tipos = tipo;
            ViewBag.Clientes = cust;

            ViewBag.Productos = await context.Productos.Select(x => new { x.IdProducto, NombreProducto = x.Nombre + " - " + x.IdMarcaNavigation.Nombre }).ToListAsync();
            if (id != null)
                ViewBag.Pedido = await context.Pedidos.Include(p => p.IdProductoNavigation).Where(x => x.IdVenta == id.Value).ToListAsync();
            Tuple<Ventas, Pedido> Model = new Tuple<Ventas, Pedido>(Venta, new Pedido());

            return View(Model);
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var VentDelete = await context.Venta.FindAsync(id);
            var detVent = await context.Pedidos.Where(x => x.IdVenta == id).AnyAsync();
            if (VentDelete == null || detVent )
            {
                return StatusCode(404);
            }
            else
                context.Venta.Remove(VentDelete);
            context.SaveChanges();
            return Redirect("/Ventas/");
        }
      public  Pedido pedido1 { get; set; }
        public async Task<IActionResult> EliminarPedido(int id)
        {
            var detallePedido = await context.Pedidos.FirstOrDefaultAsync(dv => dv.IdPedido == id);
          
            var product = await context.Productos.FirstOrDefaultAsync(p => p.IdProducto == detallePedido.IdProducto);
            if (product != null)
            {
                product.Stock += detallePedido.Cantidad;
                context.Pedidos.Remove(detallePedido);
                
                context.SaveChanges();

            }
            return Redirect("/Ventas/Modificar/"+ detallePedido.IdVenta);
        }
        public Ventas vent { get; set; }
        public async Task<IActionResult> Pagado(int id)
        {
            var ventaPago = await context.Venta.FindAsync(id);

            if(ventaPago != null)
            {
                //ventaPago.IdCliente = vent.IdCliente;
                //ventaPago.IdTipo = vent.IdTipo;
                ventaPago.Pagado = true;
                await context.SaveChangesAsync();
            }

            return Redirect("/Ventas/");
        }

    }
}
