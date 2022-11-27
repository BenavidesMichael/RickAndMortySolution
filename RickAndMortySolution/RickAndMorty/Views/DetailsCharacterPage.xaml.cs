using RickAndMorty.ViewModels;

namespace RickAndMorty.Views;

public partial class DetailsCharacterPage : ContentPage
{
	public DetailsCharacterPage(DetailCharacterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}