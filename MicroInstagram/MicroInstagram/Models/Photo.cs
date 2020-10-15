using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MicroInstagram.ViewModels
{
    public class Photo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int AlbumId { get; set; }
        public long Id { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Url { get; set; }

        private string _thumbnailUrl;
        public string ThumbnailUrl
        {
            get { return _thumbnailUrl; }
            set
            {
                if (_thumbnailUrl == value)
                    return;
                _thumbnailUrl = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
