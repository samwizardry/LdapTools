using System.DirectoryServices.Protocols;
using System.Globalization;
using System.Text;

namespace LdapTools;

public static class ActiveDirectoryExtensions
{
    public static T? GetAttributeValue<T>(this SearchResultEntry entry, string attributeName)
    {
        if (!entry.Attributes.Contains(attributeName))
            return default;

        var attribute = entry.Attributes[attributeName];

        if (attribute.Count == 0)
            return default;

        if (attribute[0] is not T value)
            return default;

        return value;
    }

    public static ActiveDirectoryUser ParseActiveDirectoryUser(this SearchResultEntry entry)
    {
        var user = new ActiveDirectoryUser
        {
            ObjectGuid = new Guid(entry.GetAttributeValue<byte[]>("objectGUID")!),
            SAMAccountName = entry.GetAttributeValue<string>("sAMAccountName")!,
            UserPrincipalName = entry.GetAttributeValue<string>("userPrincipalName")!,
            UserAccountControl = (UserAccountControlFlag)int.Parse(entry.GetAttributeValue<string>("userAccountControl")!),
            CreatedAt = DateTimeOffset.ParseExact(entry.GetAttributeValue<string>("whenCreated")!, "yyyyMMddHHmmss.fZ", CultureInfo.InvariantCulture),
            LastModifiedAt = DateTimeOffset.ParseExact(entry.GetAttributeValue<string>("whenChanged")!, "yyyyMMddHHmmss.fZ", CultureInfo.InvariantCulture),
            DistinguishedName = entry.GetAttributeValue<string>("distinguishedName")!,
            CommonName = entry.GetAttributeValue<string>("cn"),
            Name = entry.GetAttributeValue<string>("name"),
            Mail = entry.GetAttributeValue<string>("mail"),
            TelephoneNumber = entry.GetAttributeValue<string>("telephoneNumber"),
            GivenName = entry.GetAttributeValue<string>("givenName"),
            Surname = entry.GetAttributeValue<string>("sn"),
            Company = entry.GetAttributeValue<string>("company"),
            Info = entry.GetAttributeValue<string>("info"),
            LogonCount = int.TryParse(entry.GetAttributeValue<string>("logonCount"), out int lc) ? lc : 0,
            LastLogon = long.TryParse(entry.GetAttributeValue<string>("lastLogon"), out long ll) ? ll : 0,
            LastLogonTimestamp = long.TryParse(entry.GetAttributeValue<string>("lastLogonTimestamp"), out long llt) ? llt : 0,
            LastLogonDt = ll > 0 ? DateTimeOffset.FromFileTime(ll) : default,
            LastLogonTimestampDt = llt > 0 ? DateTimeOffset.FromFileTime(llt) : default
        };

        if (entry.Attributes["memberOf"] is not null)
        {
            var groups = entry.Attributes["memberOf"];

            foreach (var group in groups)
            {
                if (group is byte[] groupBytes)
                {
                    user.Groups.Add(Encoding.UTF8.GetString(groupBytes));
                }
            }
        }

        return user;
    }
}
