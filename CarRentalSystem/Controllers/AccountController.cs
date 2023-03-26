using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CarRentalSystem.Services.MessageQueue;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly PgsqlContext _context;

        public AccountController(PgsqlContext context)
        {
            _context = context;
        }

        /**
         * POST : AcountController
         * Method to create a new account in the DB
         */
        [HttpPost]
        public ActionResult<User> CreateAccount([FromBody] User newUser)
        {
            Regex regex = new("^[a-zA-Z0-9-_]+$");

            //TODO : user validate

            // db insert
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(newUser);
        }

        /**
         * GET : AcountController
         * Method to get an account from the DB, with user ID
         */
        [HttpGet("{id}")]
        public ActionResult<User> GetAccount(int id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            return Ok(existingUser);
        }

        /**
         * GET : AccountController
         * Method to edit an existing account from the DB
         */
        [HttpGet("{id}/edit")]
        public ActionResult<User> EditAccount(int id, [FromBody] User user)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Password = user.Password;

            _context.SaveChanges();

            return Ok(existingUser);
        }

        /**
         * DELETE : AccountController 
         * Method to delete an account from the DB
         */
        [HttpDelete("delete/{id}")]
        public ActionResult<User> DeleteAccount(int id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(existingUser);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("sendMessage")]
        public ActionResult SendMessage(string message)
        {
            Send.NewMessage("User 'azerpas' send you a message");

            return Ok();
        }
    }
}