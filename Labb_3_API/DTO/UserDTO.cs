using Labb_3_API.Models;

namespace Labb_3_API.DTO
{
    public record GetUserInformation(string firstName,string lastName, string phoneNumber,string email);
    public record AddLinkToUser(string url, int InterestID);
    public record AddInterestToUser(int interestId);
    public record GetUserInterests(string firstName, string lastName, string phoneNumber, string email, IEnumerable<string> interests);
    public record GetLinks(string url,string title);
    public record UserLinks(string firstName,string lastName, IEnumerable<GetLinks> interestLinks);
}
