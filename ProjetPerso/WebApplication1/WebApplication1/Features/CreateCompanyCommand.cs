namespace WebApplication1.Features
{
    public class CreateCompanyCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
