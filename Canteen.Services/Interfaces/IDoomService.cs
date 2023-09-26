using Canteen.Services.DTO;

namespace Canteen.Services.Interfaces;

public interface IDoomService
{
    public Task<List<FoodMenuItemDTO>> ListThisWeeksMenuAsync();
    public Task<List<FoodMenuItemDTO>> ListNextWeeksMenuAsync();
    public Task<List<FoodMenuItemDTO>> ListAllMenuAsync();
    public Task<bool> UpdateMenu(List<FoodMenuItemDTO> foodMenu, int weekDay, bool nextWeek);
}