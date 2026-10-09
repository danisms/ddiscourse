
using Microsoft.AspNetCore.Components;

namespace ddiscourse.Components.Utils;

public class Utils
{
     public static string Initials(string? name)
    {
        var parts = (name ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 2) return $"{parts[0][0]}{parts[^1][0]}".ToUpperInvariant();
        return parts.Length == 1 ? parts[0][..1].ToUpperInvariant() : "?";
    }

    public static MarkupString StarSvg(bool filled) => new(
        $"<svg width=\"22\" height=\"22\" viewBox=\"0 0 24 24\" fill=\"{(filled ? "currentColor" : "none")}\" stroke=\"currentColor\" stroke-width=\"2\" aria-hidden=\"true\">" +
        "<path d=\"M12 3l2.9 6 6.6.9-4.8 4.6 1.2 6.5L12 17.8 6.1 21l1.2-6.5L2.5 9.9 9.1 9z\"/></svg>");

}