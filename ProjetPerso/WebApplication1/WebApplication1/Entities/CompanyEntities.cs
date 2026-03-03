namespace WebApplication1.Entities
{
    public class Company
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Company() { } // EF

        public Company(string name, string description, string email, string address, double latitude, double longitude)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Company name is required");

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Email = email;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
