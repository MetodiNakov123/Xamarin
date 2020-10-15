using MicroInstagram.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroInstagram.ViewModels
{
    public class PhotoDetailsViewModel
    {
        public Photo Photo{ get; set; }
        public string Title { get; set; }
        public PhotoDetailsViewModel(Photo photo = null)
        {
            Title = "Details";
            Photo = photo;
        }
    }
}
