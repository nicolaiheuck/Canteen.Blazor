using Blazored.Toast.Services;
using Canteen.Services.DTO;
using Canteen.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Graph;

namespace Canteen.Blazor.Pages
{
	public partial class MenuTemplate
	{
		[Inject] public IDoomService Service { get; set; }
		private IDoomService _service;

		[Inject] public Toolbelt.Blazor.I18nText.I18nText? I18nText { get; set; }
		private I18nText.LanguageTable _languageTable = new();
		[Inject] public IToastService? ToastService { get; set; }

		[CascadingParameter] public int _weekDay { get; set; }

		public List<FoodMenuItemDTO> ThisWeekMenuList { get; set; } = new();
		public FoodMenuItemDTO MenuItem1 { get; set; } = new();
		private IEnumerable<string> foodAllergy1;

		public FoodMenuItemDTO MenuItem2 { get; set; } = new();
		private IEnumerable<string> foodAllergy2;
		public FoodMenuItemDTO MenuItem3 { get; set; } = new();
		private IEnumerable<string> foodAllergy3;
		public FoodMenuItemDTO MenuItem4 { get; set; } = new();
		private IEnumerable<string> foodAllergy4;

		private List<string> carbonFootPrint = new();
		private List<string> foodAllergyList = new();

		protected override async Task OnInitializedAsync()
		{
			carbonFootPrint.Add("Low");
			carbonFootPrint.Add("Medieum");
			carbonFootPrint.Add("High");
			_languageTable = await I18nText.GetTextTableAsync<I18nText.LanguageTable>(this); ;
			_service = Service;
			foodAllergyList = await _service.ListAllFoodAllergysAsync();
		}

		private async Task Submit(List<FoodMenuItemDTO> arg)
		{
			MenuItem1Async();
			MenuItem2Async();
			MenuItem3Async();
			MenuItem4Async();

			var result = await _service.UpdateMenu(ThisWeekMenuList, _weekDay, false);
			if (result)
			{
				ToastService.ShowSuccess($"{_languageTable["SuccessfullyUpdated"]}");
			}
			else
			{
				ToastService.ShowSuccess($"{_languageTable["FailedUpdate"]}");
			}
		}

		private async Task MenuItem1Async()
		{
			List<Food_Allergy> allergies = new();
			if (foodAllergy1 != null)
			{
				foreach (var item in foodAllergy1)
				{
					allergies.Add(new Food_Allergy { Allergy = item, Present = true });
				}
			}
			MenuItem1.FoodAllergiesList = allergies;
			MenuItem1.Weekday = _weekDay;
			ThisWeekMenuList.Add(MenuItem1);
		}

		private async Task MenuItem2Async()
		{
			List<Food_Allergy> allergies = new();
			if (foodAllergy2 != null)
			{
				foreach (var item in foodAllergy2)
				{
					allergies.Add(new Food_Allergy { Allergy = item, Present = true });
				}
			}
			MenuItem2.FoodAllergiesList = allergies;
			MenuItem2.Weekday = _weekDay;
			ThisWeekMenuList.Add(MenuItem2);
		}

		private async Task MenuItem3Async()
		{
			List<Food_Allergy> allergies = new();
			if (foodAllergy3 != null)
			{
				foreach (var item in foodAllergy3)
				{
					allergies.Add(new Food_Allergy { Allergy = item, Present = true });
				}
			}
			MenuItem3.FoodAllergiesList = allergies;
			MenuItem3.Weekday = _weekDay;
			ThisWeekMenuList.Add(MenuItem3);
		}

		private async Task MenuItem4Async()
		{
			List<Food_Allergy> allergies = new();
			if (foodAllergy4 != null)
			{
				foreach (var item in foodAllergy4)
				{
					allergies.Add(new Food_Allergy { Allergy = item, Present = true });
				}
			}
			MenuItem4.FoodAllergiesList = allergies;
			MenuItem4.Weekday = _weekDay;
			ThisWeekMenuList.Add(MenuItem4);
		}

		void Cancel()
		{
			//
		}
	}
}
