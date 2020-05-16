using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controlers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PotworyController : ControllerBase
    {
        private DatabaseContext context { get; set; }

        public PotworyController(DatabaseContext con)
        {
            context = con;
        }

        [HttpGet]
        public IEnumerable<Potwory> Get()
        {
            return context.Potwory.ToList();
        }

        [HttpGet("{id}")]
        public Potwory GetOne(int id)
        {
            return context.Potwory.SingleOrDefault(m => m.Id == id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pot = context.Potwory.FirstOrDefault(t => t.Id == id);
            if (pot != null)
            {
                context.Potwory.Remove(pot);
                context.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public bool Update(int id, [FromBody] Potwory pot)
        {
            context.Potwory.Update(pot);
            context.SaveChanges();
            return true;
        }

        [HttpPost]
        public bool Create([FromBody] Potwory pot)
        {
            context.Potwory.Add(pot);
            context.SaveChanges();
            return true;

        }
    }

}