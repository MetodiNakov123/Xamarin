using MicroInstagram.Models;
using MicroInstagram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroInstagram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomeViewModel();
            BindingContext = viewModel;
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Photo selectedPhoto = e.SelectedItem as Photo;
            
            if (selectedPhoto == null)
                return;

            await Navigation.PushAsync(new PhotoDetailsPage(new PhotoDetailsViewModel(selectedPhoto)));

            // Manually deselect item.
            listView.SelectedItem = null;

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPhotoPage());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = viewModel.searchPhoto(e.NewTextValue);
        }

        protected override void OnAppearing()
        {
            searchBar.Text = "";
            base.OnAppearing();
        }
    }
}