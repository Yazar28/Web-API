using Microsoft.AspNetCore.Mvc;
using LinkedListAPI.Models;
using System.Collections.Generic;

namespace LinkedListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkedListController : ControllerBase
    {
        private static readonly LinkedList lista = new LinkedList();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(lista.GetAll());
        }

        [HttpPost]
        public IActionResult AddNode([FromBody] NodoInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Value))
                return BadRequest(new { error = "Falta el campo 'value'" });

            var id = lista.Add(input.Value);
            return Created("", new { id });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNode(Guid id)
        {
            var eliminado = lista.Remove(id);

            if (eliminado)
                return Ok(new { mensaje = $"Nodo con id {id} eliminado" });

            return NotFound(new { error = "Nodo no encontrado" });
        }
    }

    public class NodoInput
    {
        public string Value { get; set; }
    }
}
