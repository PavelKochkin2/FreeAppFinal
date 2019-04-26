using System;
using System.Linq;
using FreeAppFinal.Data;
using FreeAppFinal.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FreeAppFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class FreeItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FreeItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //api/FreeItems/
        [HttpGet]
        public IActionResult GetFreeItems()
        {
            if (!_context.FreeItems.Any())
                return NotFound();
            return Ok(_context.FreeItems.ToList());
        }

        //api/FreeItems/5
        [HttpGet("{id}")]
        public IActionResult GetFreeItem([FromRoute] int id)
        {
            FreeItem freeItem = _context.FreeItems.FirstOrDefault(item => item.Id == id);

            if (freeItem == null)
                return NotFound();
            return Ok(freeItem);
        }

        //api/FreeItems/
        [HttpPost]
        public IActionResult AddFreeItem([FromBody] FreeItem freeItem)
        {
            _context.FreeItems.Add(freeItem);
            _context.SaveChanges();

            var result = CreatedAtAction("GetFreeItem", new { id = freeItem.Id }, freeItem);
            return result;
        }

        //api/FreeItems/5
        [HttpPut("{id}")]
        public IActionResult EditFreeItem([FromRoute] int id, FreeItem freeItem)
        {
            var freeItemInDb = _context.FreeItems.FirstOrDefault(item => item.Id == id);

            if (freeItemInDb == null)
                return NotFound();
            freeItemInDb.Name = freeItem.Name;
            freeItemInDb.Description = freeItem.Description;

            _context.SaveChanges();

            return Ok(freeItemInDb);
        }

        //api/FreeItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFreeItem([FromRoute] int id)
        {
            var freeItemInDb = _context.FreeItems.FirstOrDefault(item => item.Id == id);
            if (freeItemInDb != null)
            {
                _context.FreeItems.Remove(freeItemInDb);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}