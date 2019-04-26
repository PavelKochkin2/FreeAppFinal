using System;
using System.Collections.Generic;
using System.Linq;
using FreeAppFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeAppFinal.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static readonly List<Phone> data;
        static ValuesController()
        {
            data = new List<Phone>
            {
                new Phone { Id = Guid.NewGuid().ToString(), Name="iPhone 7", Price=52000 },
                new Phone { Id = Guid.NewGuid().ToString(), Name="Samsung Galaxy S7", Price=42000 },
            };
        }
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Phone phone)
        {
            phone.Id = Guid.NewGuid().ToString();
            data.Add(phone);
            return Ok(phone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Phone phone = data.FirstOrDefault(x => x.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            data.Remove(phone);
            return Ok(phone);
        }
    }
}