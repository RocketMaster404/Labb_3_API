using System.Collections;

namespace Labb_3_API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();

    }
}
