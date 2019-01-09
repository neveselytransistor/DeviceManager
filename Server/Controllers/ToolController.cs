using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("Tool")]
    public class ToolController : Controller
    {
        private readonly IToolService _entityService;

        public ToolController(IToolService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _entityService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _entityService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Tool entity)
        {
            await _entityService.UpdateAsync(entity);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Tool entity)
        {
            await _entityService.AddAsync(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _entityService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("Export")]
        public async Task<IActionResult> Export()
        {
            var resultString = await _entityService.ExportToCsv();
            return Ok(resultString);
        }
    }
}