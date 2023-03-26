namespace CarRentalSystem
{
    /**
     * User class
     */
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User() { }

        public User(int id, string password, string name, string surname, string email)
        {
            UserID = id;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }


    }
}