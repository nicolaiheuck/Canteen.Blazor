using Canteen.Repositories.Context;
using Canteen.Repositories.Entities;
using Canteen.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Canteen.Repositories.Repositories;

public class DoomRepository : IDoomRepository
{
    private DBContext _context;

    public DoomRepository(DBContext context)
    {
        _context = context;
    }

    private IQueryable<Food_Menu> GetWeekMenu()
    {
        var menu = _context.Food_Menu
            .Where(f => f.Id > 0);
        return menu;
    }
    
    public async Task<List<Food_Menu>> GetThisWeekMenuAsync()
    {
        var weekMenu = await GetWeekMenu()
            .Where(f => f.WeekDay > 0 && f.WeekDay < 6)
            .Include(f => f.FoodFootprint)
            .AsNoTracking()
            .ToListAsync();

        return weekMenu;
    }

    public async Task<List<Food_Menu>> GetNextWeeksMenuAsync()
    {
        var weekMenu = await GetWeekMenu()
            .Where(f => f.WeekDay > 5 && f.WeekDay < 10)
            .Include(f => f.FoodFootprint)
            .AsNoTracking()
            .ToListAsync();

        return weekMenu;
    }

    public async Task<bool> UpdateMenuItem(List<Food_Menu> foodMenu, int weekDay, bool nextWeek = false)
    {
        try
        {
            var foodWeekDay = nextWeek switch
            {
                true => weekDay + 5,
                false => weekDay
            };

            foreach (var food in foodMenu)
            {
                food.WeekDay = foodWeekDay;
                _context.Food_Menu.Update(food);
            }

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }
}