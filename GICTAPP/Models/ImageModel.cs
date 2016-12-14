using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GICTAPP
{
    /// <summary>
    ///     Model of card
    /// </summary>
    public class ImageModel : Model
    {
        private bool _isCoverVisible;
        private string _imageSource;
        private string _guid; 

        public ImageModel()
        {
            _guid = Guid.NewGuid().ToString(); 
        }

        /// <summary>
        ///     Card unique Id
        /// </summary>
        public string Id
        {
            get { return _guid; }
        }

        /// <summary>
        ///     Is card hidden
        /// </summary>
        public bool IsCoverVisible
        {
            get { return _isCoverVisible; }
            set { SetProperty(ref _isCoverVisible, value); }
        }

        /// <summary>
        ///     Card image source
        /// </summary>
        public string ImageSource
        {
            get { return _imageSource; }
            set  { SetProperty(ref _imageSource, value); }
        }
    }
}
