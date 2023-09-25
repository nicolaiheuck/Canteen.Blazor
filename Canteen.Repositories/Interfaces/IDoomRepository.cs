using Canteen.Repositories.Entities;

namespace Canteen.Repositories.Interfaces;

public interface IDoomRepository
{
    public Task<List<Food_Menu>> GetThisWeekMenuAsync();
    public Task<List<Food_Menu>> GetNextWeeksMenuAsync();
    public Task<bool> UpdateMenuItem(List<Food_Menu> foodMenu, int weekDay, bool nextWeek = false);
}