namespace Canteen.Services.DTO;

public class FoodMenuItemDTO
{
    public string DishName { get; set; }
    public int Kcal { get; set; }
    public int Kj { get; set; }
    public string Footprint { get; set; }
    public int FootprintId { get; set; }
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }
    public bool Allergy_Gluten { get; set; }
    public bool Allergy_Crustacean { get; set; }
    public bool Allergy_Mollusca { get; set; }
    public bool Allergy_Egg { get; set; }
    public bool Allergy_Fish { get; set; }
    public bool Allergy_Peanut { get; set; }
    public bool Allergy_Soy { get; set; }
    public bool Allergy_Milk { get; set; }
    public bool Allergy_Nuts { get; set; }
    public bool Allergy_Lupin { get; set; }
    public bool Allergy_Celery { get; set; }
    public bool Allergy_Mustard { get; set; }
    public bool Allergy_Sesame { get; set; }
    public bool Allergy_Sulphite { get; set; }
    public int Weekday { get; set; }
}