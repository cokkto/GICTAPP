using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GICTAPP
{
    public class ImageModel : Model
    {
        private bool _isCoverVisible;
        private string _imageSource;

        public bool IsCoverVisible
        {
            get { return _isCoverVisible; }
            set { SetProperty(ref _isCoverVisible, value); }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set  { SetProperty(ref _imageSource, value); }
        }
    }
}
