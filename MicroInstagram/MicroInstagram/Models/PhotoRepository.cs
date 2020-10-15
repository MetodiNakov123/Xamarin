using MicroInstagram.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace MicroInstagram.Models
{
    public class PhotoRepository
    {
        private const string Url = "https://jsonplaceholder.typicode.com/photos"; //endpoint
        private HttpClient _client = new HttpClient();
        public ObservableCollection<Photo> Photos { get; private set; }

        public PhotoRepository()
        {
            loadPhotos();
        }

        private void loadPhotos()
        {
            var content = _client.GetStringAsync(Url);          // send an HTTP Get request to endpoint to get the list of all photos
            var _photos = JsonConvert.DeserializeObject<List<Photo>>(content.Result);
            Photos = new ObservableCollection<Photo>(_photos);
            /*
            Photos = new ObservableCollection<PhotoViewModel>
            {
                new PhotoViewModel{AlbumId=1, Id=1, Title="accusamus beatae ad facilis cum similique qui sunt", Url="https://cnet2.cbsistatic.com/img/-e95qclc6pwSnGE2YccC2oLDW_8=/1200x675/2020/04/16/7d6d8ed2-e10c-4f91-b2dd-74fae951c6d8/bazaart-edit-app.jpg", ThumbnailUrl="https://cnet2.cbsistatic.com/img/-e95qclc6pwSnGE2YccC2oLDW_8=/1200x675/2020/04/16/7d6d8ed2-e10c-4f91-b2dd-74fae951c6d8/bazaart-edit-app.jpg"},
                new PhotoViewModel{AlbumId=1, Id=2, Title="reprehenderit est deserunt velit ipsam", Url="https://iso.500px.com/wp-content/uploads/2016/11/stock-photo-159533631-1500x1000.jpg", ThumbnailUrl="https://iso.500px.com/wp-content/uploads/2016/11/stock-photo-159533631-1500x1000.jpg"},
                new PhotoViewModel{AlbumId=1, Id=3, Title="officia porro iure quia iusto qui ipsa ut modi", Url="https://via.placeholder.com/600/24f355", ThumbnailUrl="https://via.placeholder.com/600/24f355"},
                new PhotoViewModel{AlbumId=1, Id=4, Title="culpa odio esse rerum omnis laboriosam voluptate repudiandae", Url="https://via.placeholder.com/600/d32776", ThumbnailUrl="https://via.placeholder.com/600/d32776"},
                new PhotoViewModel{AlbumId=1, Id=5, Title="natus nisi omnis corporis facere molestiae rerum in", Url="https://images.unsplash.com/photo-1508921912186-1d1a45ebb3c1?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80", ThumbnailUrl="https://images.unsplash.com/photo-1508921912186-1d1a45ebb3c1?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"}
            };
            */
        }

        public async void UpdatePhoto(Photo photo)
        {
            var content = JsonConvert.SerializeObject(photo);
            await _client.PutAsync(Url + "/" + photo.Id, new StringContent(content));
        }

        public async void DeletePhoto(Photo photo)
        {
            await _client.DeleteAsync(Url + "/" + photo.Id);
        }

        public async void AddPhoto(Photo newPhoto)
        {
            var content = JsonConvert.SerializeObject(newPhoto);
            await _client.PostAsync(Url, new StringContent(content));
        }



    }
}
