using System.Net;
using System.Text.RegularExpressions;

public static class TextHelpers
{
    public static string PlainExcerpt(string html, int max = 160)
    {
        var text = Regex.Replace(html, "<[^>]*>", " ");  // drop the tags
        text = WebUtility.HtmlDecode(text);  // &amp; becomes &
        text = Regex.Replace(text, @"\s+", " ").Trim();  // collapse whitespace
        return text.Length <= max ? text : text[..max].TrimEnd() + "…";
    }
}