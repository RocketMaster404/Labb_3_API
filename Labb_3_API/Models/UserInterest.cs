namespace Labb_3_API.Models
{
    public class UserInterest
    {
        public int Id { get; set; }
        public int InterestId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } = null!;
        public Interest Interest { get; set; } = null!;

    }
}
