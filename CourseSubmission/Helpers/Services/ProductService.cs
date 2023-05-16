using CourseSubmission.Helpers.Repos;
using CourseSubmission.Models.Dtos;
using System.Runtime.CompilerServices;

namespace CourseSubmission.Helpers.Services;

public class ProductService
{

    private readonly ProductsRepository _productsRepository;

    public ProductService(ProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }



    public async Task<IEnumerable<Product>>GetAllByTagNameAsync(string tagName)
    {
        var items = await _productsRepository.GetAllAsync();
        var list = new List<Product>();
        foreach (var item in items)
        {
            var tagList = new List<string>();
            foreach (var tag in item.Tags)
                tagList.Add(tag.Tag.TagName);

                list.Add(new Product
                {
                    ArticleNumber = item.ArticleNumber,
                    Description = item.Description,
                    Ingress = item.Ingress,
                    ImgUrl = item.ImgUrl,
                    Tags = tagList,
                    Price = item.Price,
                    ProductName = item.ProductName,
                });
        }

        return list;
    }  



    public async Task<Product>GetAsync(string articleNumber)
    {
        var item = await _productsRepository.GetAsync(x => x.ArticleNumber == articleNumber);

        var tagList = new List<string>();
        foreach (var tag in item.Tags)
            tagList.Add(tag.Tag.TagName);

        var product = new Product 
        { 
            ArticleNumber = item.ArticleNumber,
            Description = item.Description,
            ImgUrl= item.ImgUrl,
            Tags = tagList,
            Price = item.Price,
            ProductName = item.ProductName
        };
        return product;
    }
}
