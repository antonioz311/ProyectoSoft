// Controllers/MovimientoController.cs
using GestionInventario.Models;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly MovimientoServicio _movimientoServicio;

        public MovimientoController(MovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
        }

       
        [HttpPost("Adicionar")]
        public ActionResult Adicionar([FromBody] Movimiento movimiento)
        {
            try
            {
                _movimientoServicio.AdicionarExistencias(movimiento.ProductoId, movimiento.Cantidad, movimiento.Motivo);
                return Ok(new { Message = "Existencias adicionadas exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("Disminuir")]
        public ActionResult Disminuir([FromBody] Movimiento movimiento)
        {
            try
            {
                _movimientoServicio.DisminuirExistencias(movimiento.ProductoId, movimiento.Cantidad, movimiento.Motivo);
                return Ok(new { Message = "Existencias disminuidas exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var movimientos = _movimientoServicio.ObtenerMovimientos();
            return Ok(movimientos);
        }

    
        [HttpGet("GetByProducto/{productoId}")]
        public ActionResult GetByProducto(int productoId)
        {
            var movimientos = _movimientoServicio.ObtenerMovimientosPorProducto(productoId);
            return Ok(movimientos);
        }
    }
}
