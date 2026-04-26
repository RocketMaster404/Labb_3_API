namespace Labb_3_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<Link> Links { get; set; } = new List<Link>();
        public ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
    }
}
