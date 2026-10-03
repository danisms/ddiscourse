using System.Security.Claims;

namespace ddiscourse.Components.Layout;

public static class UserDisplay
{
    /// <summary>Full name from the claim; falls back to the username.</summary>
    public static string Name(ClaimsPrincipal user) =>
        user.FindFirst("full_name")?.Value is { Length: > 0 } n ? n : user.Identity?.Name ?? "";

    /// <summary>"Daniel Opute" -> "DO". One word -> first two letters.</summary>
    public static string Initials(ClaimsPrincipal user)
    {
        var parts = Name(user).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2) return $"{parts[0][0]}{parts[^1][0]}".ToUpperInvariant();
        var one = parts.FirstOrDefault() ?? "";
        return one.Length >= 2 ? one[..2].ToUpperInvariant() : one.ToUpperInvariant();
    }

    public static string Role(ClaimsPrincipal user) =>
        user.IsInRole("Admin") ? "Admin" :
        user.IsInRole("Moderator") ? "Moderator" : "Contributor";
}