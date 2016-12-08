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
        private string _guid;

        public ImageModel()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get { return _guid; }
        }

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
