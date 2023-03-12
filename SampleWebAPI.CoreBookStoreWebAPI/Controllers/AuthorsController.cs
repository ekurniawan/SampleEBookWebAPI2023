using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.CoreBookStoreWebAPI.Data;
using SampleWebAPI.CoreBookStoreWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPI.CoreBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthor _author;

        public AuthorsController(IAuthor author)
        {
            _author = author;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _author.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _author.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            try
            {
                var result = await _author.Insert(author);
                return CreatedAtAction("Get", new { id = result.AuthorId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put(Author author)
        {
            try
            {
                var result = await _author.Update(author);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id);
                return Ok($"Data author dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

