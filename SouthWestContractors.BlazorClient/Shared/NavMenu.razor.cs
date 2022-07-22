using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SouthWestContractors.BlazorClient.Auth;
using SouthWestContractors.BlazorClient.Contracts;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Shared
{
    public partial class NavMenu
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }
        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}
