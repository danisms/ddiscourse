using ddiscourse.Data;

public class ArticleHelper
{
    // Builds `visible` from `allArticles`. allArticles itself is never changed, so clearing the search brings everything
    public static List<Article> ApplyArticleFilter(List<Article> allArticles, string searchText, SortArticle sortArticle = SortArticle.Newest)
    {
        IEnumerable<Article> query = allArticles;

        var term = searchText.Trim();
        if (term.Length > 0)
        {
            query = query.Where(a =>
            a.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            (a.Author?.FullName ?? "").Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        query = sortArticle switch
        {
            SortArticle.Top => query.OrderByDescending(a => a.Ratings.Count > 0 ? a.Ratings.Average(r => r.Value) : 0)
            .ThenByDescending(a => a.CreatedAt),
            SortArticle.MostDiscussed => query.OrderByDescending(a => a.Comments.Count)
            .ThenByDescending(a => a.CreatedAt),
            _ => query.OrderByDescending(a => a.CreatedAt)
        };

        return query.ToList();
    }
}

public enum SortArticle
{
    Newest = 0,
    Top = 1,
    MostDiscussed = 2
}