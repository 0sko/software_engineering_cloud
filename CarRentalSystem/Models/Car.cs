using Microsoft.AspNetCore.Components.RenderTree;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace CarRentalSystem
{
    public class Car
    {
        public int CarID { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public bool IsCarAvailable { get; set; }

        public Car() { }
        public Car(int carId, string type, string color, string brand, string category, float price)
        {
            CarID = carId;
            Type = type;
            Color = color;
            Brand = brand;
            Category = category;
            Price = price;
            IsCarAvailable = true;
        }

        public static bool CanRentCar(DateTime startDate, DateTime endDate)
        {
            // Check if start date is in the future
            if (startDate > DateTime.Now)
            {
                // Check if end date is after start date
                if (endDate > startDate)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("End date must be after start date.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Start date must be in the future.");
                return false;
            }
        }
    }
}