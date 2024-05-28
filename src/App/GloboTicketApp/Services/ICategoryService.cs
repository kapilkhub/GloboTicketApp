using GloboTicketApp.Models;

namespace GloboTicketApp.Services;

public interface ICategoryService
{
    Task<List<CategoryModel>> GetCategories();
}
