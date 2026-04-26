namespace Labb_3_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int InterestId { get; set; }

        public User User { get; set; } = null!;
        public Interest Interest { get; set; } = null!;
    }
}
