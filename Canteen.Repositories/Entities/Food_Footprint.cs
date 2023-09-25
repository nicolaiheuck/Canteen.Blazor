namespace Canteen.Repositories.Entities;

public class Food_Footprint
{
    public int FoodprintID { get; set; }
    public string FootprintText { get; set; }
    
    // Navigation property
    public IEnumerable<Food_Menu>? FoodMenu { get; set; }
}