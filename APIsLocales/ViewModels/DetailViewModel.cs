using APIsLocales.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsLocales.ViewModels
{
    [QueryProperty(nameof(Count), nameof(Count))]
    [QueryProperty(nameof(Monkey), nameof(Monkey))]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Monkey monkey;

        [ObservableProperty]
        int count;

        IConnectivity connectivity;

        public DetailViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;

        }

        [RelayCommand]
        async Task CheckInternet()
        {
            var hasInternet = connectivity?.NetworkAccess == NetworkAccess.Internet;

            await App.Current.MainPage.DisplayAlert("Has Internet", hasInternet ? "YES!" : "NO!", "OK");
        }

        [RelayCommand]
        Task Back() => Shell.Current.GoToAsync("..");

        [RelayCommand]
        Task GoToAnother() =>
            Shell.Current.GoToAsync($"../{nameof(AnotherPage)}");
    }
}
