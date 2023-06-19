using APIsLocales.Helpers;
using APIsLocales.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsLocales.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        Monkey monkey;
        IConnectivity connectivity;
        IToast toast;
        public MainPageViewModel(IConnectivity connectivity, IToast toast)
        {
            monkey = new Monkey { Name = "Mooch" };
            this.connectivity = connectivity;
            this.toast = toast;
        }




        [RelayCommand]
        async Task CheckInternet()
        {
            NetworkAccess accessType = connectivity.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                toast.MakeToast("You Have Internter!");
            }
            else
            {
                await Shell.Current.DisplayAlert("Check internet!", $"Current status: {accessType}", "OK");
            }
        }

    }
}
