using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/<HeroiController1>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            { 

                return BadRequest($"Erro: {ex}");
            }
            
        }

        // GET api/<HeroiController1>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/Heroi
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("Vai curinthia");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<HeroiController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefault( h => h.Id == id ) != null) // nao travar na hora de dar um update
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("VAI CURINTHIA");
                }

                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<HeroiController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
