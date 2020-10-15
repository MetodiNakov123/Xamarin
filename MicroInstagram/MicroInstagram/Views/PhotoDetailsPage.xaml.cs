using MicroInstagram.Services;
using MicroInstagram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MicroInstagram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetailsPage : ContentPage
    {
        private PhotoDetailsViewModel viewModel;
        public PhotoDetailsPage(PhotoDetailsViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            image.Source = this.viewModel.Photo.ThumbnailUrl;
            title.Text = this.viewModel.Photo.Title;
            thumbnailUrl.Text = this.viewModel.Photo.ThumbnailUrl;

            BindingContext = this.viewModel;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.Photo.Title = title.Text;
            viewModel.Photo.ThumbnailUrl = thumbnailUrl.Text;
            MessagingCenter.Send(this, Constants.EDIT_PHOTO, viewModel.Photo);
            DependencyService.Get<IToast>().Show("Changes saved");
            await Navigation.PopAsync();

        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var delete = await DisplayAlert("Delete", "Are you sure to delete?", "Delete", "Cancel");
            if (delete)
            {
                MessagingCenter.Send(this, Constants.DELETE_PHOTO, viewModel.Photo);
                DependencyService.Get<IToast>().Show("Item deleted");
                await Navigation.PopAsync();
            }
            else
            {
                return;
            }
            
        }

        private async void Image_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PhotoFullScreenPage(viewModel.Photo));
        }
    }
}