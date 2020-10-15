using MicroInstagram.Services;
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
    public partial class AddNewPhotoPage : ContentPage
    {
        public Photo Photo { get; set; }
        public AddNewPhotoPage()
        {
            InitializeComponent();

            Photo = new Photo { };
            BindingContext = this;
        }


        private async void Save_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Title.Text) || String.IsNullOrEmpty(Url.Text) || String.IsNullOrEmpty(ThumbnailUrl.Text))
            {
                await DisplayAlert("Warning!", "Аll fields are required!", "OK");
                return;
            }
            Photo.Id = (int)DateTime.Now.Ticks;
            Photo.Title = Title.Text;
            Photo.Url = Url.Text;
            Photo.ThumbnailUrl = ThumbnailUrl.Text;

            MessagingCenter.Send(this, Constants.ADD_NEW_PHOTO, Photo);
            DependencyService.Get<IToast>().Show("Item added");
            await Navigation.PopAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}