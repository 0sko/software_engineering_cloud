namespace CarRentalSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float price { get; set; }

        public bool paymentSuccesful { get; set; } = false;

        public Payment() { }

        /**
         * Method to simulate payment by the user
         */
        public bool pay()
        {
            //method to pay

            if(true)
            {
                paymentSuccesful = true;
            }
            else 
            {
                paymentSuccesful = false;
            }
            return paymentSuccesful;
        }

        /**
         * cancel : PaymentController
         * Method to cancel a payment
         * 
         */
        public void cancel()
        {
            return;
        }
    }
}
