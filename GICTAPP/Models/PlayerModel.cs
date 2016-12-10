using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICTAPP.Models
{
    public class PlayerModel : Model
    {
        private string _id;
        private string _name;
        private bool _isPlayerVisible;
        private int _playerScore;

        public PlayerModel()
        {
            _id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Player unique Id
        /// </summary>
        public string Id 
        { 
            get { return _id; }
        }

        /// <summary>
        ///     Give a name to player 
        ///     I not sure is needed
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        // <summary>
        ///     Is player hidden
        /// </summary>
        public bool IsPlayerVisible
        {
            get { return _isPlayerVisible; }
            set { SetProperty(ref _isPlayerVisible, value); }
        }

        /// <summary>
        ///     Give a score to Player
        /// </summary>
        public int PlayerScore
        {
            get { return _playerScore; }
            set { SetProperty(ref _playerScore, value); }
        }

        


    }
}
