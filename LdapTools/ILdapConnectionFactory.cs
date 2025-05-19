using System.DirectoryServices.Protocols;

namespace LdapTools;

public interface ILdapConnectionFactory
{
    LdapConnection CreateConnection();

    LdapConnection CreateConnection(string username, string password);
}
