namespace CourseSubmission.Models.Dtos;

public class Product
{
    public string? ArticleNumber { get; set; }
    public string? ProductName { get; set; }
    public string? Ingress { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImgUrl { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
}
