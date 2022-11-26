using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CategoryController
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService = new CategoryService();
    }

    [HttpGet]
    public List<Category> GetCategories()
    {
        return _categoryService.GetCategories();
    }
    
    [HttpPost]
    public int InsertCategory(Category category)
    {
        return _categoryService.InsertCategory(category);
    }
    [HttpPut]
    public int UpdateCategory(Category category)
    {
        return _categoryService.UpdateCategory(category);
    }
    [HttpDelete]
    public int DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
}