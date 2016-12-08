using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ImageModel> _images;
        private ICommand _commandSwapCard;

        public ICommand CommandStart
        {
            get { return _myCommand; }
            set { SetProperty(ref _myCommand, value); }
        }

        public ICommand CommandSwapCard
        {
            get { return _commandSwapCard; }
            set { SetProperty(ref _commandSwapCard, value); }
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

        public ObservableCollection<ImageModel> Images
        {
            get { return _images ?? (_images = new ObservableCollection<ImageModel>()); }
            set { SetProperty(ref _images, value); }
        }
    }
}