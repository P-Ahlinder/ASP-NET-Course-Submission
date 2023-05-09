namespace CourseSubmission.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }
    public string TagName { get; set; }
    public string TagValue { get; set; }
    public ICollection<ProductTagEntity> Products { get; set; } = new HashSet<ProductTagEntity>();

}




