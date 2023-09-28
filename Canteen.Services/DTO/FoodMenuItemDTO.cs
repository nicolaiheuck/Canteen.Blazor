using System.ComponentModel;

namespace Canteen.Services.DTO;

public class FoodMenuItemDTO
{
    public string DishName { get; set; }
    public string Footprint { get; set; }
    public int FootprintId { get; set; }
    public int Kcal { get; set; }
    public int Kj { get; set; }
    public int Weekday { get; set; }
    public List<Food_Allergy> FoodAllergiesList { get; set; }
}