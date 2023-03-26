using System.Collections.Generic;
using CarRentalSystem.Models;

namespace CarRentalSystem
{
    /**
     *  Customer class
     *  inherits from User
     */
    public class Customer : User
    {

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal AccountBalance { get; set; }
        /**
         * List of cars in the customer's cart
         */
        public List<Car> Cart { get; set; }

        /**
         * List of cars rented by the customer
         */
        public List<Car> RentedCars { get; set; }

        public Customer() { }
        public Customer(int id, string password, string name, string surname, string email) : base()
        {
            AccountBalance = 0;
            Cart = new List<Car>();
            RentedCars = new List<Car>();
        }


    }
}