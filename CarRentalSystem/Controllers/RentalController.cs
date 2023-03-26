using CarRentalSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        private readonly PgsqlContext _context;

        public RentalController(PgsqlContext context)
        {
            _context = context;
        }

        /**
         * GET: RentalController
         * Method to get all the rentals
         */
        [HttpGet]
        public ActionResult Index()
        {
            List<Rental> rentalList = _context.Rentals.ToList();

            return Ok(rentalList);
        }

        /**
         * GET: RentalController/Details/5
         * Method to get the details of one rental
         */
        [HttpGet("details/{id}")]
        public ActionResult Details(int rentalId)
        {
            //TODO : access db (rental) with the id of the rental
            var rental = _context.Rentals.Find(rentalId);

            // if not found generate 404 response
            if (rental == null)
            { 
                return NotFound();
            }

            //if found generate http 200
            return Ok(rental);
        }

        /**
         * POST: RentalController/Create
         * Method to create a new rental
         */
        [HttpPost("create")]
        public ActionResult Create(List<Car> carList, int customerId, DateTime rentStartDate, DateTime rentEndDate)
        {

            //check if customer exists
            Customer customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            //check if cars are available and remove them from the list if they are not available
            foreach (Car car in carList)
            {
                if (car.IsCarAvailable == false)
                {
                    carList.Remove(car);
                }
            }

            try
            {
                var newRental = new Rental(carList, customerId, rentStartDate, rentEndDate);
                _context.Rentals.Add(newRental);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        /**
         * POST: RentalController/Edit/5
         * Method to post an edit of id rental
         */
        [HttpPost("edit/{rentalId}")]
        public ActionResult EditRental(int rentalId, [FromBody] Rental rental)
        {
            Rental existingRental = _context.Rentals.Find(rentalId);

            if (existingRental == null)
            {
                return NotFound();
            }

            try
            {
                existingRental = rental;
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        /**
         * Delete: RentalController/Delete/5
         * Method to delete one rental by its id
         */
        [HttpDelete("delete/{rentalId}")]
        public ActionResult DeleteRental(int rentalId)
        {
            Rental rental = _context.Rentals.Find(rentalId);

            if (rental == null)
            {
                return NotFound();
            }

            try
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        /**
         * POST: RentalController/rentcar/2
         * Method to start a rental
         */
        [HttpPost("startRental/{rentalId}")]
        public ActionResult StartRental(int rentalId)
        {
            Rental rental = _context.Rentals.Find(rentalId);

            if(rental == null)
            { 
                return NotFound(); 
            }

            rental.rentCars();
            _context.SaveChanges();

            return Ok(rental);
        }


        /**
         * POST: RentalController/rentcar/2
         * Method to end a rental and make cars available once more
         */
        [HttpPost("endRental/{rentalId}")]
        public ActionResult EndRental(int rentalId)
        {
            Rental rental = _context.Rentals.Find(rentalId);

            if (rental == null)
            {
                return NotFound();
            }

            rental.makeCarsAvailable();
            _context.SaveChanges();

            return Ok(rental);
        }


    }
}
