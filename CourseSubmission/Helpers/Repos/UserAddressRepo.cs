using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;

namespace CourseSubmission.Helpers.Repos;

public class UserAddressRepo : Repos<UserAddressEntity>
{
    public UserAddressRepo(DejjtabejjsContext context) : base(context)
    {
    }
}
