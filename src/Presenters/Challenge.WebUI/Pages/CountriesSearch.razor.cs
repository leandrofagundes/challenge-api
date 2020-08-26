using Challenge.WebUI.DTOs;
using Challenge.WebUI.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebUI.Pages
{
    public partial class CountriesSearch
    {
        [Inject]
        private ICountryModel CountryModel { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public bool IsLoading { get; set; }
        public string ErrorMessage { get; set; }
        public CancellationTokenSource TokenSource { get; private set; }

        public CountriesSearchRequestData CountriesSearchRequestData { get; set; }

        public CountriesSearchResponseData[] Countries { get; set; }

        protected override void OnInitialized()
        {
            this.CountriesSearchRequestData = new CountriesSearchRequestData();
            this.Countries = new CountriesSearchResponseData[] { };
        }

        private async Task SearchCountriesSubmit()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;
                if (TokenSource != null)
                    TokenSource.Cancel();

                TokenSource = new CancellationTokenSource();
                var responseData = await CountryModel.SearchCountries(this.CountriesSearchRequestData, TokenSource.Token);
                this.Countries = responseData;

                IsLoading = false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                IsLoading = false;
            }
        }

        protected void NavigateToCountryDetails(string countryName)
        {
            NavigationManager.NavigateTo($"country-details/{countryName}", false);
        }
    }
}
