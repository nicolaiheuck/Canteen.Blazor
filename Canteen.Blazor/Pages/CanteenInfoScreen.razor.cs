using Canteen.Services.DTO;
using Canteen.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Canteen.Blazor.Pages;

public partial class CanteenInfoScreen
{
    [Inject] public IDoomService Service { get; set; }
    private IDoomService _service;
    [Inject] public Toolbelt.Blazor.I18nText.I18nText? I18nText { get; set; }
    private I18nText.LanguageTable _languageTable = new ();
    public List<FoodMenuItemDTO> thisWeekMenuList { get; set; } = new();
    public List<FoodMenuItemDTO> nextWeekMenuList { get; set; }

	protected override async Task OnInitializedAsync()
    {
        _languageTable = await I18nText.GetTextTableAsync<I18nText.LanguageTable>(this);;
        _service = Service;
        thisWeekMenuList = await _service.ListThisWeeksMenuAsync();
        // thisWeekMenuList = debug.AsEnumerable();
        nextWeekMenuList = await _service.ListNextWeeksMenuAsync();
    }
}