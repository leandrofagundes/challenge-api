using Challenge.WebUI.DTOs;
using Challenge.WebUI.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Challenge.WebUI.Pages
{
    public partial class CountryDetails
    {
        [Parameter]
        public string Name { get; set; }

        [Inject]
        private ICountryModel CountryModel { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public CountryDetailResponseData Country { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Country = await CountryModel.GetDetails(Name);
        }

        public void GoBack()
        {
            NavigationManager.NavigateTo("/countries");
        }
    }
}
