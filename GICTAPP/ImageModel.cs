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
        private BitmapImage _bitmapImage;
        private bool _isCoverVisible;

        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
            set { SetProperty(ref _bitmapImage, value); }
        }

        public bool IsCoverVisible
        {
            get { return _isCoverVisible; }
            set { SetProperty(ref _isCoverVisible, value); }
        }
    }
}
