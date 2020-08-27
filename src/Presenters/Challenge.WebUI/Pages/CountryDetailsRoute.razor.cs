using Challenge.WebUI.DTOs;
using Challenge.WebUI.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Challenge.WebUI.Pages
{
    public partial class CountryDetailsRoute
    {
        [Parameter]
        public string Origin { get; set; }

        [Parameter]
        public string Destiny { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ICountryModel CountryModel { get; set; }

        private CountryDetailResponseData OriginCountry { get; set; }
        private CountryDetailResponseData DestinyCountry { get; set; }

        private RouteResponseData[] Route { get; set; }

        protected override async Task OnInitializedAsync()
        {
            OriginCountry = await CountryModel.GetDetails(Origin);
            DestinyCountry = await CountryModel.GetDetails(Destiny);
            Route = await CountryModel.GetRoute(Origin, Destiny);
        }

        internal void GoBackTo(string country)
        {
            NavigationManager.NavigateTo($"/country-details/{country}");
        }
    }
}
