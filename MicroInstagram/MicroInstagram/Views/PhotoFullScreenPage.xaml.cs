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
    public partial class PhotoFullScreenPage : ContentPage
    {
        public PhotoFullScreenPage(Photo photo)
        {
            InitializeComponent();
            image.Source = photo.ThumbnailUrl;
        }
    }
}