using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Client.Auth
{
    public class Redirect: ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [CascadingParameter] protected Task<AuthenticationState> AuthStat { get; set; }

        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
            var user = (await AuthStat).User;
            if (!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo($"login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
            }
        }
    }
}
