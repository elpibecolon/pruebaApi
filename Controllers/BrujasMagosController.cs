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
        /// <summary>
        /// Obtiene un objeto por su Id.
        /// </summary>
        /// <remarks>
        /// Se obtiene todos los registros almacenados en la bd en formato JSON.
        /// </remarks>          
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        public IEnumerable<BrujasMagos> Get()
        {
            return context.Brujas_Magos.ToList();
        }

        // GET: api/<controller>/id
        /// <summary>
        /// Obtiene un objeto por su identificacion.
        /// </summary>
        /// <remarks>
        /// Se obtiene el registro almacenado en la bd en formato JSON segun su identificacion.
        /// </remarks>
        /// <param name="id">identificacion del objeto.</param>             
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet("{id}")]
        public BrujasMagos Get(Int64 id)
        {
            var brujasMagos = context.Brujas_Magos.FirstOrDefault(bm=>bm.identificacion==id);
            return brujasMagos;
        }

        // POST: api/<controller>
        /// <summary>
        /// Insertar registro.
        /// </summary>
        /// <remarks>
        /// Se inserta el registro en BD.
        /// </remarks>
        /// <param name="identificacion">id del mago o bruja.</param>
        /// <param name="nombre">nombre del mago o bruja.</param>
        /// <param name="apellido">apellido del mago o bruja.</param>
        /// <param name="edad">edad del mago o bruja.</param>
        /// <param name="casa">casa al cual pertenece el mago o bruja.</param>            
        /// <response code="200">OK. Insercion exitosa.</response>        
        /// <response code="400">BadRequest. No se inserto el objeto.</response>
        /// <response code="500">Servidor no responde.</response>
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
        /// <summary>
        /// Actualizar registros.
        /// </summary>
        /// <remarks>
        /// Se actualiza el registro en BD segun el parametro id y debe ser el mismo al tag identificacion existente en BD .
        /// </remarks>
        /// <param name="id">identificacion del objeto.</param>
        /// <remarks>
        /// Parametros para realizar la actualizacion del registro en BD
        /// </remarks>
        /// <param name="identificacion">id del mago o bruja.</param>
        /// <param name="nombre">nombre del mago o bruja.</param>
        /// <param name="apellido">apellido del mago o bruja.</param>
        /// <param name="edad">edad del mago o bruja.</param>
        /// <param name="casa">casa al cual pertenece el mago o bruja.</param>             
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="400">BadRequest. No se inserto el objeto.</response>
        /// <response code="500">Servidor no responde.</response>
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
        /// <summary>
        /// Elimnar registro.
        /// </summary>
        /// <remarks>
        /// Se elimina el registro en BD.
        /// </remarks>
        /// <param name="id">identificacion del objeto a eliminar.</param>             
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="400">BadRequest. No se inserto el objeto.</response>
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
