namespace CarRentalSystem.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public List<Car> Cars { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public bool IsPaid { get; set; }
        public float RentalTotalPrice { get; set; }

        public Rental() { }

        public Rental(List<Car> cars, int customerId, DateTime rentStartDate, DateTime rentEndDate)
        {
            Cars = cars;
            CustomerId = customerId;
            RentStartDate = rentStartDate;
            RentEndDate = rentEndDate;
            IsPaid = false;
            RentalTotalPrice = getRentalTotalPrice();

        }

        /**
         * Method to get the total price of the rental
         */
        public float getRentalTotalPrice()
        {
            float price = 0;
            TimeSpan duration = RentEndDate - RentStartDate;
            int durationInt = duration.Days;

            foreach (var car in Cars)
            {
                price += (car.Price * durationInt);
            }

            return price;
        }

        /**
         * Method to activate rental of cars
         */
        public void rentCars()
        {
            foreach (var car in Cars)
            {
                car.IsCarAvailable = false;
            }
        }

        /**
         * Method to make cars available once again after rental end
         */
        public void makeCarsAvailable()
        {
            foreach (var car in Cars)
            {
                car.IsCarAvailable = true;
            }
        }

    }
}
