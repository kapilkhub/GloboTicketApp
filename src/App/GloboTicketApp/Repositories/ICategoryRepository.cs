using GloboTicketApp.Models;

namespace GloboTicketApp.Repositories
{
	public interface ICategoryRepository
	{
		Task<List<CategoryModel>> GetCategories();
	}
}