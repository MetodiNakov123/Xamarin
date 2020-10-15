using Android.Widget;
using MicroInstagram.Droid;
using MicroInstagram.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_Android))]

namespace MicroInstagram.Droid
{
    class Toast_Android : IToast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}