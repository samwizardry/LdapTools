using System.DirectoryServices.Protocols;

using LdapTools;

namespace Sandbox;

public class MyUser : IUser<MyUser>
{
    public string Email { get; init; } = null!;

    public static MyUser ParseUser(SearchResultEntry entry)
    {
        return new MyUser
        {
            Email = entry.GetAttributeValue<string>("mail")!
        };
    }

    public static bool TryParseUser(SearchResultEntry entry, out MyUser? user)
    {
        user = ParseUser(entry);

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            user = null;
            return false;
        }

        return true;
    }
}
