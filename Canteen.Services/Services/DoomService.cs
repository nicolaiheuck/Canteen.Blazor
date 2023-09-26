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
        List<Food_Menu> foodList = new();
        
        
        if (!nextWeek) foodList = await _repository.GetThisWeekMenuAsync();
        if (nextWeek) foodList = await _repository.GetNextWeeksMenuAsync();
        
        List<FoodMenuItemDTO> result = new();
        
        foreach (var foodItem in foodList)
        {
            var fAList = new List<Food_Allergy>();
            fAList.Add(new Food_Allergy
            {
                Allergy = "Vegan",
                Present = foodItem.Vegan
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Gluten",
                Present = foodItem.Allergy_Gluten
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Vegetarian",
                Present = foodItem.Vegetarian
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Crustacean",
                Present = foodItem.Allergy_Crustacean
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Mollusca",
                Present = foodItem.Allergy_Mollusca
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Egg",
                Present = foodItem.Allergy_Egg
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Fish",
                Present = foodItem.Allergy_Fish
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Peanut",
                Present = foodItem.Allergy_Peanut
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Soy",
                Present = foodItem.Allergy_Soy
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Milk",
                Present = foodItem.Allergy_Milk
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Nuts",
                Present = foodItem.Allergy_Nuts
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Lupin",
                Present = foodItem.Allergy_Lupin
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Celery",
                Present = foodItem.Allergy_Celery
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Mustard",
                Present = foodItem.Allergy_Mustard
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Sesame",
                Present = foodItem.Allergy_Sesame
            });
            fAList.Add(new Food_Allergy
            {
                Allergy = "Sulphite",
                Present = foodItem.Allergy_Sulphite
            });
            
            result.Add(new FoodMenuItemDTO
            {
                DishName = foodItem.DishName,
                Kcal = foodItem.Kcal,
                Kj = foodItem.Kj,
                Footprint = foodItem.FoodFootprint.FootprintText,
                FoodAllergiesList = fAList,
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
                Vegetarian = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Vegetarian").Present,
                Vegan = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Vegan").Present,
                Allergy_Gluten = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Gluten").Present,
                Allergy_Crustacean = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Crustacean").Present,
                Allergy_Mollusca = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Mollusca").Present,
                Allergy_Egg = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Egg").Present,
                Allergy_Fish = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Fish").Present,
                Allergy_Peanut = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Peanut").Present,
                Allergy_Soy = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Soy").Present,
                Allergy_Milk = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Milk").Present,
                Allergy_Nuts = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Nuts").Present,
                Allergy_Lupin = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Lupin").Present,
                Allergy_Celery = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Celery").Present,
                Allergy_Mustard = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Mustard").Present,
                Allergy_Sesame = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Sesame").Present,
                Allergy_Sulphite = FoodItem.FoodAllergiesList.First(f => f.Allergy == "Allergy_Sulphite").Present,
                WeekDay = FoodItem.Weekday
            };
            menuList.Add(foodItem);
        }

        return menuList;
    }
}