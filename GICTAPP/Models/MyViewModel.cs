using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace GICTAPP
{
    /// <summary>
    ///     Application viewmodel
    /// </summary>
    public class MyViewModel : Model
    {
        private ICommand _myCommand;
        private int _numberOfPlayers;
        private ObservableCollection<int> _playersoptions;
        private ObservableCollection<int> _cardsOptions;
        private int _numberOfCards;
        private ObservableCollection<ImageModel> _images;
        private ICommand _commandSwapCard;
        private PlayerModel _activePlayer;
        private ObservableCollection<PlayerSelectorModel> _playerSelector;
        private ObservableCollection<PlayerModel> _recordedPlayers;
        private ObservableCollection<PlayerModel> _players;


        /// <summary>
        ///     Start game command
        /// </summary>
        public ICommand CommandStart
        {
            get { return _myCommand; }
            set { SetProperty(ref _myCommand, value); }
        }

        /// <summary>
        ///     Swap card command
        /// </summary>
        public ICommand CommandSwapCard
        {
            get { return _commandSwapCard; }
            set { SetProperty(ref _commandSwapCard, value); }
        }

        /// <summary>
        ///     Current number of players
        /// </summary>
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                SetProperty(ref _numberOfPlayers, value);
                PlayerSelector.Clear();
                for (int i = 0; i < _numberOfPlayers; i++)
                {
                    PlayerSelector.Add(new PlayerSelectorModel { Id = i});
                }
            }
        }

        public ObservableCollection<PlayerSelectorModel> PlayerSelector
        {
            get
            {
                return _playerSelector ?? (_playerSelector = new ObservableCollection<PlayerSelectorModel>());
            }
            set { SetProperty(ref _playerSelector, value); }
        }

        public ObservableCollection<PlayerModel> RecordedPlayers
        {
            get { return _recordedPlayers ?? (_recordedPlayers = SetRecordedPlayers()); }
            set { SetProperty(ref _recordedPlayers, value); }
        }

        /// <summary>
        ///     Available numbers of players
        /// </summary>
        public ObservableCollection<int> PlayersOptions
        {
            get { return _playersoptions ?? (_playersoptions = new ObservableCollection<int>()); } //сравнение на null
            set { SetProperty(ref _playersoptions, value); }
        }

        /// <summary>
        ///     Current number of cards
        /// </summary>
        public ObservableCollection<int> CardsOptions
        {
            get { return _cardsOptions ?? (_cardsOptions = new ObservableCollection<int>()); }
            set { SetProperty(ref _cardsOptions, value); }
        }

        /// <summary>
        ///     Available numbers of cards
        /// </summary>
        public int NumberOfCards
        {
            get { return _numberOfCards; }
            set { SetProperty(ref _numberOfCards, value); }
        }

        /// <summary>
        ///     Cards set
        /// </summary>
        public ObservableCollection<ImageModel> Images
        {
            get { return _images ?? (_images = new ObservableCollection<ImageModel>()); }
            set { SetProperty(ref _images, value); }
        }

        // <summary>
        ///     Is player hidden
        /// </summary>
        public PlayerModel ActivePlayer
        {
            get { return _activePlayer; }
            set { SetProperty(ref _activePlayer, value); }
        }

        public bool ActiveId()
        {
            return false;
        }

        public ObservableCollection<PlayerModel> SetRecordedPlayers(IList<PlayerModel> models = null)
        {
            if (_recordedPlayers == null) _recordedPlayers = new ObservableCollection<PlayerModel>();
            RecordedPlayers.Clear();
            RecordedPlayers.Add(new PlayerModel { Name = "New player" });
            if (models == null) return _recordedPlayers;
            foreach (var item in models)
            {
                RecordedPlayers.Add(item);
            }
            return _recordedPlayers;
        }

        /// <summary>
        ///     Players that are playing current game
        /// </summary>
        public ObservableCollection<PlayerModel> Players
        {
            get { return _players ?? (_players = new ObservableCollection<PlayerModel>()); }
            set { SetProperty(ref _players, value); }
        }

    }
}