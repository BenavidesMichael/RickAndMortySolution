using CommunityToolkit.Mvvm.ComponentModel;

namespace RickAndMorty.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _title;
    }
}
