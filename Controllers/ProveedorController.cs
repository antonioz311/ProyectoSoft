
using GestionInventario.Models;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorServicio _proveedorServicio;

        public ProveedorController(ProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Proveedor>> GetAll()
        {
            return Ok(_proveedorServicio.ObtenerProveedores());
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Proveedor> GetById(int id)
        {
            var proveedor = _proveedorServicio.ObtenerProveedorPorId(id);
            if (proveedor == null)
                return NotFound(new { Message = $"Proveedor con ID {id} no encontrado." });

            return Ok(proveedor);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Proveedor proveedor)
        {
            try
            {
                _proveedorServicio.CrearProveedor(proveedor);
                return Ok(new { Message = "Proveedor creado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] Proveedor proveedor)
        {
            try
            {
                _proveedorServicio.ActualizarProveedor(proveedor);
                return Ok(new { Message = "Proveedor actualizado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _proveedorServicio.EliminarProveedor(id);
                return Ok(new { Message = "Proveedor eliminado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
