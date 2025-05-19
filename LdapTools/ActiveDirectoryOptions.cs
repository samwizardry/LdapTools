namespace LdapTools;

public class ActiveDirectoryOptions
{
    /// <summary>
    /// e.g. "DC=contoso,DC=com"
    /// </summary>
    public required string QueryBase { get; init; }
}
