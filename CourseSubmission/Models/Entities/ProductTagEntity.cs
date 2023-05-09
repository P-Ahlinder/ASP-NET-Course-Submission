namespace CourseSubmission.Models.Entities;

public class ProductTagEntity
{
    public string ArticleNumber { get; set; }
    public ProductEntity Poduct { get; set; }
    public int TagId { get; set; }
    public TagEntity Tag { get; set; }
}




