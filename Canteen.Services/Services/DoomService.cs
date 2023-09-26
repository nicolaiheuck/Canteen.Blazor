using Canteen.Repositories.Entities;
using Canteen.Repositories.Interfaces;
using Canteen.Services.DTO;
using Canteen.Services.Interfaces;

namespace Canteen.Services.Services;

public class DoomService : IDoomService
{
    private IDoomRepository _repository;

    public DoomService(IDoomRepository repository)
    {
        _repository = repository;
    }

    private async Task<List<FoodMenuItemDTO>> GetWeekMenuAsync(bool nextWeek = false)
    {
        var foodList = nextWeek switch
        {
            true => await _repository.GetThisWeekMenuAsync(),
            false => await _repository.GetNextWeeksMenuAsync()
        };
        
        List<FoodMenuItemDTO> result = new();
        
        foreach (var foodItem in foodList)
        {
            result.Add(new FoodMenuItemDTO
            {
                DishName = foodItem.DishName,
                Kcal = foodItem.Kcal,
                Kj = foodItem.Kj,
                Footprint = foodItem.FoodFootprint.FootprintText,
                Vegetarian = foodItem.Vegetarian,
                Vegan = foodItem.Vegan,
                Allergy_Gluten = foodItem.Allergy_Gluten,
                Allergy_Crustacean = foodItem.Allergy_Crustacean,
                Allergy_Mollusca = foodItem.Allergy_Mollusca,
                Allergy_Egg = foodItem.Allergy_Egg,
                Allergy_Fish = foodItem.Allergy_Fish,
                Allergy_Peanut = foodItem.Allergy_Peanut,
                Allergy_Soy = foodItem.Allergy_Soy,
                Allergy_Milk = foodItem.Allergy_Milk,
                Allergy_Nuts = foodItem.Allergy_Nuts,
                Allergy_Lupin = foodItem.Allergy_Lupin,
                Allergy_Celery = foodItem.Allergy_Celery,
                Allergy_Mustard = foodItem.Allergy_Mustard,
                Allergy_Sesame = foodItem.Allergy_Sesame,
                Allergy_Sulphite = foodItem.Allergy_Sulphite,
                Weekday = foodItem.WeekDay,
                FootprintId = foodItem.FootprintID
            });
        }
        return result;
    }

    public async Task<List<FoodMenuItemDTO>> ListThisWeeksMenuAsync()
    {
        var result = await GetWeekMenuAsync();
        return result;
    }

    public async Task<List<FoodMenuItemDTO>> ListNextWeeksMenuAsync()
    {
        var result = await GetWeekMenuAsync(true);
        return result;
    }

    public async Task<List<FoodMenuItemDTO>> ListAllMenuAsync()
    {
        var result = (await ListThisWeeksMenuAsync())
            .Concat(await ListNextWeeksMenuAsync());

        return result.ToList();
    }

    public async Task<bool> UpdateMenu(List<FoodMenuItemDTO> foodMenu, int weekDay, bool nextWeek)
    {
        var result = await _repository.UpdateMenuItem(MapFoodMenuFromDTO(foodMenu), weekDay, nextWeek);
        return result;
    }

    private List<Food_Menu> MapFoodMenuFromDTO(List<FoodMenuItemDTO> foodMenuItemDtos)
    {
        var menuList = new List<Food_Menu>();
        
        foreach (var FoodItem in foodMenuItemDtos)
        {
            var foodItem = new Food_Menu
            {
                DishName = FoodItem.DishName,
                Kcal = FoodItem.Kcal,
                Kj = FoodItem.Kj,
                FootprintID = FoodItem.FootprintId,
                Vegetarian = FoodItem.Vegetarian,
                Vegan = FoodItem.Vegan,
                Allergy_Gluten = FoodItem.Allergy_Gluten,
                Allergy_Crustacean = FoodItem.Allergy_Crustacean,
                Allergy_Mollusca = FoodItem.Allergy_Mollusca,
                Allergy_Egg = FoodItem.Allergy_Egg,
                Allergy_Fish = FoodItem.Allergy_Fish,
                Allergy_Peanut = FoodItem.Allergy_Peanut,
                Allergy_Soy = FoodItem.Allergy_Soy,
                Allergy_Milk = FoodItem.Allergy_Milk,
                Allergy_Nuts = FoodItem.Allergy_Nuts,
                Allergy_Lupin = FoodItem.Allergy_Lupin,
                Allergy_Celery = FoodItem.Allergy_Celery,
                Allergy_Mustard = FoodItem.Allergy_Mustard,
                Allergy_Sesame = FoodItem.Allergy_Sesame,
                Allergy_Sulphite = FoodItem.Allergy_Sulphite,
                WeekDay = FoodItem.Weekday
            };
            menuList.Add(foodItem);
        }

        return menuList;
    }
}