using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteAPI_EF.Data;
using clienteAPI_EF.Models;

namespace ClienteAPI_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDb _context;

        public ClientesController(ApplicationDb context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            cliente.FechaCreacion = DateTime.UtcNow;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpGet("ListadoGeneral")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListadoGeneral()
        {
            return await _context.Clientes
                .OrderBy(c => c.FechaCreacion)
                .ThenBy(c => c.Apellidos)
                .ToListAsync();
        }
    }
}


namespace ClienteAPI_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacionClienteController : ControllerBase
    {
        private readonly ApplicationDb _context;

        public InformacionClienteController(ApplicationDb context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<InformacionCliente>> CrearInformacionCliente(InformacionCliente informacion)
        {
            _context.InformacionClientes.Add(informacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInformacionCliente), new { id = informacion.Id }, informacion);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformacionCliente>> GetInformacionCliente(int id)
        {
            var informacion = await _context.InformacionClientes.FindAsync(id);
            if (informacion == null)
            {
                return NotFound();
            }
            return informacion;
        }
    }
}