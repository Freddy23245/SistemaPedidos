﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

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
           
            var vent = await context.Venta.Include(x => x.IdClienteNavigation).Include(t=>t.IdTipoNavigation).ToListAsync();
            Ventas xvent = new Ventas();          
            ViewBag.Ventas = vent;
        
            //Tuple<Ventas, Pedido> Model = new Tuple<Ventas, Pedido>(Venta, new Pedido());
            return View(xvent);
        }
        [BindProperty]
        public Ventas venta { get; set; }
        public async Task<IActionResult> Nuevo(int? id)
        {
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
            ViewBag.Estado = await context.Estados.ToListAsync();
            ViewBag.Productos = await context.Productos.Select(x => new { x.IdProducto, NombreProducto = x.Nombre + " - " + x.IdMarcaNavigation.Nombre }).ToListAsync();
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

            context.Pedidos.Add(pedido);

            await context.SaveChangesAsync();
            res.resultado = pedido;
            res.mensaje = "Porducto Agregado Correctamente";
            return Json(res);
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
