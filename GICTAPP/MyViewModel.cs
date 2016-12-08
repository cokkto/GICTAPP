using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;

namespace GICTAPP
{
    public class MyViewModel : Model
    {
        private ICommand _myCommand;
        private int _numberOfPlayers;
        private List<int> _playersoptions;
        private List<int> _cardsOptions;
        private int _numberOfCards;
        private List<ImageModel> _images;

        public ICommand CommandStart
        {
            get { return _myCommand; }
            set { SetProperty(ref _myCommand, value); }
        }

        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set { SetProperty(ref _numberOfPlayers, value); }
        }

        public List<int> PlayersOptions
        {
            get { return _playersoptions ?? (_playersoptions = new List<int>()); }
            set { SetProperty(ref _playersoptions, value); }
        }

        public List<int> CardsOptions
        {
            get { return _cardsOptions ?? (_cardsOptions = new List<int>()); }
            set { SetProperty(ref _cardsOptions, value); }
        }

        public int NumberOfCards
        {
            get { return _numberOfCards; }
            set { SetProperty(ref _numberOfCards, value); }
        }

        public List<ImageModel> Images
        {
            get { return _images ?? (_images = new List<ImageModel>()); }
            set { SetProperty(ref _images, value); }
        }
    }
}