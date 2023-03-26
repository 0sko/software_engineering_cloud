using CarRentalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly PgsqlContext _context;
        private Payment payment;

        public PaymentController(PgsqlContext context)
        {
            _context = context;
            payment = new Payment();
        }

        /**
         * GET : PaymentController
         * Method to pay a rental and activate it
         * 
         */
        [HttpGet("{rentalId}")]
        public IActionResult getRental(int rentalId)
        {
            Rental rental = _context.Rentals.Find(rentalId);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        /**
        * POST : PaymentController
        * Method to pay a rental and activate it
        * 
        */
        [HttpPost("{rentalId}/pay")]
        public IActionResult pay(int rentalId)
        {
            Rental rental = _context.Rentals.Find(rentalId);
            if (rental == null)
            {
                return NotFound();
            }

            Customer customer = _context.Customers.Find(rental.CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            //simulate a payment
            payment.pay();

            if (payment.paymentSuccesful == false)
            {
                return BadRequest();
            }

            //activate the rental
            rental.IsPaid = true;
            rental.rentCars();

            return Ok(rental);
        }

    }
}
