using MicroInstagram.Models;
using MicroInstagram.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MicroInstagram.ViewModels
{
    public class HomeViewModel 
    {
        private const string Url = "https://jsonplaceholder.typicode.com/photos"; //endpoint
        private HttpClient _client = new HttpClient();
        public ObservableCollection<Photo> Photos { get; private set; }
        public string Title { get; private set; }

        private PhotoRepository photoRepository;
        public HomeViewModel()
        {
            Title = "Home";
            photoRepository = new PhotoRepository();
            Photos = photoRepository.Photos;

            MessagingCenter.Subscribe<PhotoDetailsPage, Photo>(this, Constants.EDIT_PHOTO, async (obj, photo) =>
            {
                var editPhoto = photo;
                var oldPhoto = Photos.Where((Photo arg) => arg.Id == photo.Id).FirstOrDefault();
                oldPhoto = editPhoto;

                photoRepository.UpdatePhoto(editPhoto);
            });

            MessagingCenter.Subscribe<PhotoDetailsPage, Photo>(this, Constants.DELETE_PHOTO, async (obj, photo) =>
            {
                Photos.Remove(photo);
                photoRepository.DeletePhoto(photo);
            });

            MessagingCenter.Subscribe<AddNewPhotoPage, Photo>(this, Constants.ADD_NEW_PHOTO, async (obj, photo) =>
            {
                Photos.Insert(0, photo);
                Photo newPhoto = new Photo
                {
                    AlbumId = 5,
                    Id = photo.Id,
                    Title = photo.Title,
                    Url = photo.Url,
                    ThumbnailUrl = photo.ThumbnailUrl
                };

                photoRepository.AddPhoto(newPhoto);
            });

        }

        public ObservableCollection<Photo> searchPhoto(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
            {
                return Photos;
            }

            var rezultPhotos = Photos.Where(p => p.Title.ToLower().StartsWith(searchText.ToLower())).ToList();
            return new ObservableCollection<Photo>(rezultPhotos);
        }
    }
}
