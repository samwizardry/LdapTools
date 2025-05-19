namespace LdapTools;

public class LdapOptions
{
    /// <summary>
    /// Server address (e.g. 127.0.0.1).
    /// </summary>
    public required string Host { get; init; }

    /// <summary>
    /// Server port (default: 389).
    /// </summary>
    public int Port { get; init; } = 389;

    /// <summary>
    /// Server zone (e.g. com).
    /// </summary>
    public required string Zone { get; init; }

    /// <summary>
    /// Server domain (e.g. contoso).
    /// </summary>
    public required string Domain { get; init; }

    /// <summary>
    /// Server subdomain (e.g. fabrikam).
    /// </summary>
    public string? Subdomain { get; init; }

    /// <summary>
    /// (e.g. fabrikam.contoso.com).
    /// </summary>
    public required string Server { get; init; }

    /// <summary>
    /// This is for connecting via LDAPS (636 port).
    /// </summary>
    public bool SecureSocketLayer { get; init; } = false;

    /// <summary>
    /// Skip certificate verification.
    /// </summary>
    public bool TrustAllCertificates { get; init; } = false;

    /// <summary>
    /// Service account username.
    /// </summary>
    public required string UserName { get; init; }

    /// <summary>
    /// Service account password.
    /// </summary>
    public required string Password { get; init; }
}
