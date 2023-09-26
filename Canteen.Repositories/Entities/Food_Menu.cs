namespace Canteen.Repositories.Entities;

public class Food_Menu
{
    public int Id { get; set; }
    public string DishName { get; set; }
    public int Kcal { get; set; }
    public int Kj { get; set; }
    public int FootprintID { get; set; }
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
    public int WeekDay { get; set; }
    
    // Navigation properties
    public Food_Footprint FoodFootprint { get; set; }
}