namespace Samolocik.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? JobTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CanAddEmployees { get; set; }
        public bool CanAddUsers { get; set; }
        public bool CanAddFlights { get; set; }
        public bool CanAddAirports { get; set; }
        public bool CanAddPlanes { get; set; }
        public bool CanAddAirLines { get; set; }
    }
}
