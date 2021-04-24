using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaApi.Context;
using pruebaApi.Entities;

namespace pruebaApi.Controllers
{
    [Route("api/[controller]")]
    public class BrujasMagosController:Controller
    {
        private readonly AppDBContext context;

        public BrujasMagosController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BrujasMagos> Get()
        {
            return context.Brujas_Magos.ToList();
        }

        // GET: api/<controller>/id
        [HttpGet("{id}")]
        public BrujasMagos Get(Int64 id)
        {
            var brujasMagos = context.Brujas_Magos.FirstOrDefault(bm=>bm.identificacion==id);
            return brujasMagos;
        }

        // POST: api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]BrujasMagos brujasMagos)
        {
            try
            {
                if(brujasMagos.casa.Equals(Constants.GRYFFINDOR) || brujasMagos.casa.Equals(Constants.RAVENCLAW)
                || brujasMagos.casa.Equals(Constants.HUFFLEPUFF) || brujasMagos.casa.Equals(Constants.SLYTHERIN))
                {    
                    context.Brujas_Magos.Add(brujasMagos);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    Console.WriteLine("Casa no permitida.");
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepction: "+ex);
                return BadRequest();
            }
            
        }

        // PUT: api/<controller>/id
        [HttpPut("{id}")]
        public ActionResult Put(Int64 id, [FromBody]BrujasMagos brujasMagos)
        {
            //Console.WriteLine("BD: "+brujasMagos.identificacion+" | Parametro: "+id);
            if (brujasMagos.identificacion == id)
            {
                context.Entry(brujasMagos).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
        }

        // DELETE: api/<controller>/id
        [HttpDelete("{id}")]
        public ActionResult Delete(Int64 id)
        {
            var brujasMagos = context.Brujas_Magos.FirstOrDefault(bm => bm.identificacion==id);

            if (brujasMagos != null)
            {
                context.Brujas_Magos.Remove(brujasMagos);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
