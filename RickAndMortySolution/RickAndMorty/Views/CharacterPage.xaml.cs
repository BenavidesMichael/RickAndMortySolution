using RickAndMorty.ViewModels;

namespace RickAndMorty.Views;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(CharacterViewModel characterViewModel)
	{
		InitializeComponent();
		BindingContext= characterViewModel;
	}
}