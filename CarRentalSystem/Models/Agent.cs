namespace CarRentalSystem
{
    public class Agent : User
    {
        public int AgentCode { get; set; }

        public Agent() { }
        public Agent(string name, string surname, string email, string password, int agentCode) : base()
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            AgentCode = agentCode;
        }
    }
}