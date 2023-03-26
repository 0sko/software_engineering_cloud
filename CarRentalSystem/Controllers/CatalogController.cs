using CarRentalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly PgsqlContext _context;

        public CatalogController(PgsqlContext context)
        {
            _context = context;
        }

        /**
        * GET: CatalogController
        * Method to get all the cars from the catalog
        */
        [HttpGet]
        public IActionResult Index()
        {
            //get all the available cars from the db
            var allCars = _context.Cars.ToList();
            if (allCars == null)
            {
                return NotFound();
            }

            return Ok(allCars);
        }

        /**
        * GET: CatalogController
        * Method to get one car from the DB using its ID
        */
        [HttpGet("car/{id}")]
        public ActionResult<User> GetCar(string carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        /**
        * POST: CatalogController
        * Method to add a new car to the catalog
        */
        [HttpPost("add")]
        public IActionResult AddCarToCatalog([FromBody] Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        /**
         * POST: CatalogController/edit/5
         * Method to post a car edit of id car
         */
        [HttpPost("edit/{carId}")]
        public ActionResult EditCar(int carId, [FromBody] Car car)
        {
            Car existingCar = _context.Cars.Find(carId);

            if (existingCar == null)
            {
                return NotFound();
            }

            try
            {
                existingCar = car;
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        /**
         * DELETE : CatalogController
         * Method to delete a car from the DB
         */
        [HttpDelete("delete/{carId}")]
        public IActionResult DeleteCarFromCatalog(string CarId)
        {
            var car = _context.Cars.Find(CarId);
            if (car == null)
            {
                return NotFound();
            }

            try
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
