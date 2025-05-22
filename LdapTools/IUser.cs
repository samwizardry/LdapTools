using System.DirectoryServices.Protocols;

namespace LdapTools;

public interface IUser<TUser>
    where TUser : class, new()
{
    static abstract TUser? ParseUser(SearchResultEntry entry);
}
