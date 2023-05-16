using CourseSubmission.Models.Dtos;

namespace CourseSubmission.ViewModels;

public class ColletionVM
{
    public string? Title { get; set; }
    public IEnumerable<Product> Items { get; set; } = new List<Product>();
}
