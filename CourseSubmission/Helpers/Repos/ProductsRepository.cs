using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseSubmission.Helpers.Repos;

public class ProductsRepository : Repository<ProductEntity>
{
    private readonly DejjtabejjsContext _context;
    public ProductsRepository(DejjtabejjsContext context) : base(context)
    {
        _context = context; 
    }
    
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var items = await _context.Products
            .Include(x => x.Tags).ThenInclude(x => x.Tag).ToListAsync();

        return items;
    }
    /*
    public async Task<IEnumerable<ProductEntity>> GetAllByTagNameAsync(string tagName)
    {
        var items = await _context.Products
            .Include(x => x.Tags).ThenInclude(x => x.Tag.TagName == tagName).ToListAsync();

        return items;
    }
    */

}
