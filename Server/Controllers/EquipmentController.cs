using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("Equipment")]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _equipmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _equipmentService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Equipment entity)
        {
            await _equipmentService.UpdateAsync(entity);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Equipment entity)
        {
            await _equipmentService.AddAsync(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _equipmentService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("Export")]
        public async Task<IActionResult> Export()
        {
            var resultString = await _equipmentService.ExportToCsv();
            return Ok(resultString);
        }
    }
}