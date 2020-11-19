using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PulsacionesAPI.Context;
using PulsacionesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PulsacionesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PulsacionesContext context;

        public PersonaController(PulsacionesContext context)
        {
            this.context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaModel> Get()
        {
            return context.Personas.ToList();
        }

        // GET api/Persona/5
        [HttpGet("{identificacion}")]
        public ActionResult<PersonaModel> Get(string identificacion)
        {
            var persona = context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
            if (persona == null) return NotFound();
            return persona;
        }

        // POST api/Persona
        [HttpPost]
        public ActionResult Post([FromBody] PersonaModel persona)
        {
            try
            {
                persona.CalcularPulsaciones();
                context.Personas.Add(persona);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/Persona/5
        [HttpPut("{identificacion}")]
        public ActionResult Put(string identificacion, [FromBody] PersonaModel persona)
        {
            if(persona.Identificacion == identificacion)
            {
                context.Entry(persona).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult Delete(string identificacion)
        {
            var persona = context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
            if(persona != null)
            {
                context.Personas.Remove(persona);
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
