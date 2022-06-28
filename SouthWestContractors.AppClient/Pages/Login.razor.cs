using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SouthWestContractors.AppClient.Contracts;
using SouthWestContractors.AppClient.ViewModels;

namespace SouthWestContractors.AppClient.Pages
{
    public class LoginModel : ComponentBase
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        //public Login()
        //{

        //}

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            if (await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "Username/password combination unknown";
        }
    }
}
