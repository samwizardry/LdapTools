using System.DirectoryServices.Protocols;

using LdapTools;

namespace Sandbox;

public class MyUser : IActiveDirectoryUser<MyUser>
{
    public string Email { get; init; } = null!;

    public static MyUser? ParseUser(SearchResultEntry entry)
    {
        var email = entry.GetAttributeValue<string>("mail");

        if (email is null)
            return null;

        return new MyUser
        {
            Email = email
        };
    }
}
