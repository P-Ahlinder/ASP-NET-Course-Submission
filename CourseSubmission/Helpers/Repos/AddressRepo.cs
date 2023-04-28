using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;

namespace CourseSubmission.Helpers.Repos;

public class AddressRepo : Repos<AddressEntity>
{
    public AddressRepo(DejjtabejjsContext context) : base(context)
    {
    }
}
