using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Context;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DbContacts>> GetContactsList()
        {
            try
            {
                return await _context.Contacts.ToListAsync();
                //return Ok(context.Contacts.ToList());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult Get(int id)
        {
            try
            {
                var contact = _context.Contacts.FirstOrDefault(x => x.id == id);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] DbContacts contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return CreatedAtRoute("GetContact",new {contact.id} ,contact);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DbContacts contact)
        {
            try
            {
                if (contact.id == id)
                {
                    _context.Entry(contact).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetContact", new {contact.id }, contact);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var contact = _context.Contacts.FirstOrDefault(x => x.id == id);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                    return Ok(contact);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
