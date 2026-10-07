using System.Net;
using System.Text.RegularExpressions;
using Ganss.Xss;
using Markdig;

namespace ddiscourse.Data;

public static class ArticleContent
{
    // Make Markdown and HTML to work on a article body;
    // the sanitizer below makes it safe.
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()               // tables, autolinks, footnotes, strikethrough...
        .UseSoftlineBreakAsHardlineBreak()     // one Enter in the textarea = a line break
        .Build();

    /// <summary>Article body (Markdown and/or HTML) -> safe HTML for display.</summary>
    public static string ToSafeHtml(string? body, IHtmlSanitizer sanitizer) =>
        sanitizer.Sanitize(Markdown.ToHtml(body ?? "", Pipeline));

    /// <summary>Article body -> short plain text for article cards.</summary>
    public static string PlainExcerpt(string? body, int max = 160)
    {
        var html = Markdown.ToHtml(body ?? "", Pipeline);
        var text = Regex.Replace(html, "<[^>]*>", " ");          // drop the tags
        text = WebUtility.HtmlDecode(text);                      // &amp; becomes &
        text = Regex.Replace(text, @"\s+", " ").Trim();          // collapse whitespace
        return text.Length <= max ? text : text[..max].TrimEnd() + "…";
    }
}