using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;

namespace CourseSubmission.Helpers.Repos;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(DejjtabejjsContext context) : base(context)
    {
    }
}
