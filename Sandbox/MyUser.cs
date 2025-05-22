using System.DirectoryServices.Protocols;

using LdapTools;

namespace Sandbox;

public class MyUser : IUser<MyUser>
{
    public string Email { get; init; } = null!;

    public static MyUser? ParseUser(SearchResultEntry entry)
    {
        var email = entry.GetAttributeValue<string>("mail");

        if (string.IsNullOrWhiteSpace(email))
        {
            return null;
        }
        else
        {
            return new MyUser
            {
                Email = email
            };
        }
    }
}
