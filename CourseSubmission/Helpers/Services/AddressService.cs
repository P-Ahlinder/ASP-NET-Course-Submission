using CourseSubmission.Helpers.Repos;
using CourseSubmission.Models.Entities;
using CourseSubmission.Models.Identity;

namespace CourseSubmission.Helpers.Services;

public class AddressService
{
    private readonly AddressRepo _addressRepo;
    private readonly UserAddressRepo _userAddressRepo;
    public AddressService(AddressRepo addressRepo, UserAddressRepo userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userAddressRepo = userAddressRepo;

    }
    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
    {
        var entity = await _addressRepo.GetAsync(x => 
        x.StreetName == addressEntity.StreetName &&
        x.City == addressEntity.City &&
        x.PostalCode == addressEntity.PostalCode
        );

        entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        
    }
    public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
    {
        await _userAddressRepo.AddAsync(new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = addressEntity.Id,
        });
    }
}
