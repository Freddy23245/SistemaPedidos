using System.Dynamic;

namespace SistemaPedidos.Models
{
    public class Response
    {
        public string mensaje { get; set; }
        public bool estado { get; set; }
        public dynamic resultado { get; set; }
        public dynamic res2 { get; set; }
    }
}
