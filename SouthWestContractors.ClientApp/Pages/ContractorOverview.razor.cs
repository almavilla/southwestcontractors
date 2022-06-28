using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using SouthWestContractors.ClientApp.Contracts;
using SouthWestContractors.ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SouthWestContractors.ClientApp.Pages
{
    public partial class ContractorOverviewModel :  ComponentBase, IDisposable
    {
        [Inject]
        public IContractorDataService ContractorDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ContractorListViewModel> Contractors { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Contractors = await ContractorDataService.GetAllContractors();
        }

        protected void AddNewContractor()
        {
            NavigationManager.NavigateTo("/contractordetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportContractors()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:5001/api/contractors/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
