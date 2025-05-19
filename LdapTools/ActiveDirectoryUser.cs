namespace LdapTools;

public class ActiveDirectoryUser
{
    /// <summary>
    /// objectGUID.
    /// </summary>
    public Guid ObjectGuid { get; set; }

    /// <summary>
    /// sAMAccountName.
    /// </summary>
    public string SAMAccountName { get; set; } = null!;

    /// <summary>
    /// userPrincipalName.
    /// </summary>
    public string UserPrincipalName { get; set; } = null!;

    /// <summary>
    /// userAccountControl.
    /// </summary>
    public UserAccountControlFlag UserAccountControl { get; set; }

    /// <summary>
    /// whenCreated.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// whenChanged.
    /// </summary>
    public DateTimeOffset LastModifiedAt { get; set; }

    /// <summary>
    /// distinguishedName.
    /// </summary>
    public string DistinguishedName { get; set; } = null!;

    /// <summary>
    /// cn.
    /// </summary>
    public string? CommonName { get; set; }

    /// <summary>
    /// name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// memberOf.
    /// </summary>
    public List<string> Groups { get; set; } = new();

    /// <summary>
    /// mail.
    /// </summary>
    public string? Mail { get; set; }

    /// <summary>
    /// telephoneNumber.
    /// </summary>
    public string? TelephoneNumber { get; set; }

    /// <summary>
    /// givenName.
    /// </summary>
    public string? GivenName { get; set; }

    /// <summary>
    /// sn.
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// company.
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// info.
    /// </summary>
    public string? Info { get; set; }

    /// <summary>
    /// logonCount.
    /// Counts the number of successful times the user tried to log on to this account.
    /// </summary>
    public int LogonCount { get; set; }

    /// <summary>
    /// lastLogon.
    /// The last time the user logged on.
    /// This value is stored as a large integer that represents the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    /// A value of zero means that the last logon time is unknown.
    /// </summary>
    public long LastLogon { get; set; }

    /// <summary>
    /// lastLogonTimestamp.
    /// Lastlogon is only updated on the domain controller that performs the authentication and is not replicated.
    /// LastLogontimestamp is replicated, but by default only if it is 14 days or more older than the previous value.
    /// </summary>
    public long LastLogonTimestamp { get; set; }

    /// <summary>
    /// LastLogon в формате DateTimeOffset.
    /// </summary>
    public DateTimeOffset LastLogonDt { get; set; }

    /// <summary>
    /// LastLogonTimestamp в формате DateTimeOffset.
    /// </summary>
    public DateTimeOffset LastLogonTimestampDt { get; set; }

    public bool IsNormalAccount() =>
        (UserAccountControl & UserAccountControlFlag.NORMAL_ACCOUNT) == UserAccountControlFlag.NORMAL_ACCOUNT;

    public bool IsAccountDisabled() =>
        (UserAccountControl & UserAccountControlFlag.ACCOUNTDISABLE) == UserAccountControlFlag.ACCOUNTDISABLE;

    public bool IsLockedOut() =>
        (UserAccountControl & UserAccountControlFlag.LOCKOUT) == UserAccountControlFlag.LOCKOUT;

    /// <summary>
    /// Запрашиваемые поля
    /// </summary>
    public static IReadOnlyCollection<string> Attributes => new List<string>
    {
        "objectGUID",
        "sAMAccountName",
        "userPrincipalName",
        "userAccountControl",
        "whenCreated",
        "whenChanged",
        "distinguishedName",
        "cn",
        "name",
        "memberOf",
        "mail",
        "telephoneNumber",
        "givenName",
        "sn",
        "company",
        "info",
        "logonCount",
        "lastLogon",
        "lastLogonTimestamp"
    }.AsReadOnly();
}
