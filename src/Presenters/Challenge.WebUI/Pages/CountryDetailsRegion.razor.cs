using Challenge.WebUI.DTOs;
using Challenge.WebUI.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Challenge.WebUI.Pages
{
    public partial class CountryDetailsRegion
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public EventCallback<string> OnDestinyCountrySelected { get; set; }

        [Inject]
        private ICountryModel CountryModel { get; set; }

        public CountryDetailsRegionResponseData[] Countries { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.Countries = await CountryModel.GetInRegion(this.Name);
        }

        public async Task DestinyCountrySelected(string name)
        {
            await this.OnDestinyCountrySelected.InvokeAsync(name);
        }
    }
}
