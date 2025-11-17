namespace JaemyPortfolio.Models
{
    public class HomeViewModel
    {
        public List<PortfolioItem> FeaturedPortfolioItems { get; set; } = new();
        public List<BlogPost> LatestBlogPosts { get; set; } = new();
    }
}
