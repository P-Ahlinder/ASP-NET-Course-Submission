using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSubmission.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Column(TypeName ="money")]
    public decimal Price { get; set; }  
    public string ImgUrl { get; set; } = null!;
}
