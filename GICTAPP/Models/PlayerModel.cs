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
        public PlayerModel()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string Id { get { return _id; } }

    }
}
