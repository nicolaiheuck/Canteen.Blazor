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

public class Food_Allergy
{
    public string Allergy { get; set; }
    public bool Present { get; set; }
}
// public class Food_Allergies
// {
//     [DisplayName("Vegetarian")]
//     public bool Vegetarian { get; set; }
//     [DisplayName("Vegan")]
//     public bool Vegan { get; set; }
//     [DisplayName("Gluten")]
//     public bool Allergy_Gluten { get; set; }
//     [DisplayName("Crustacean")]
//     public bool Allergy_Crustacean { get; set; }
//     [DisplayName("Mollusca")]
//     public bool Allergy_Mollusca { get; set; }
//     [DisplayName("Egg")]
//     public bool Allergy_Egg { get; set; }
//     [DisplayName("Fish")]
//     public bool Allergy_Fish { get; set; }
//     [DisplayName("Peanut")]
//     public bool Allergy_Peanut { get; set; }
//     [DisplayName("Soy")]
//     public bool Allergy_Soy { get; set; }
//     [DisplayName("Milk")]
//     public bool Allergy_Milk { get; set; }
//     [DisplayName("Nuts")]
//     public bool Allergy_Nuts { get; set; }
//     [DisplayName("Lupin")]
//     public bool Allergy_Lupin { get; set; }
//     [DisplayName("Celery")]
//     public bool Allergy_Celery { get; set; }
//     [DisplayName("Mustard")]
//     public bool Allergy_Mustard { get; set; }
//     [DisplayName("Sesame")]
//     public bool Allergy_Sesame { get; set; }
//     [DisplayName("Sulphite")]
//     public bool Allergy_Sulphite { get; set; }
// }