using GloboTicketApp.Models;
using GloboTicketApp.Repositories;

namespace GloboTicketApp.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<List<CategoryModel>> GetCategories()
        => _categoryRepository.GetCategories();
}
