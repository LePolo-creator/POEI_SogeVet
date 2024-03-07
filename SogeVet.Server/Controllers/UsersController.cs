using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SogeVet.Server.Data;
using SogeVet.Server.Entities;
using SogeVet.Server.Models;

namespace SogeVet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreContext _context;

        public UsersController(StoreContext context)
        {
            _context = context;
        }

        /*
         *  
         */

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {

            return _context.Users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user =  _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = user.ConvertToDto();

            return userDto;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult<UserDto> PutUser(int id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var userToEdit = _context.Users.FirstOrDefault(u => u.Id == id);
            userToEdit.FirstName = userDto.FirstName;
            userToEdit.LastName = userDto.LastName;
            userToEdit.Email = userDto.Email;
            userToEdit.Password = userDto.Password;
            _context.SaveChanges();

            return GetUser(id) ;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<UserDto> PostUser(UserDto userDto)
        {
            var user = userDto.ConvertToUser();
            _context.Users.Add(user);
             _context.SaveChanges();

            return Ok(userDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user =  _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        } 

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
