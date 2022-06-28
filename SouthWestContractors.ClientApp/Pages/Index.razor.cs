using Microsoft.AspNetCore.Components;
using System;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using SouthWestContractors.ClientApp.Contracts;
using SouthWestContractors.ClientApp.Auth;

namespace SouthWestContractors.ClientApp.Pages
{
    public class IndexModel: ComponentBase, IDisposable
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

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
