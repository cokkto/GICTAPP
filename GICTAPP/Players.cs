using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICTAPP
{
    public class Players
    {
        private string _name;
        private State stateofPlayer;

        public Players(string name, State state)
        {
            _name = name;
            stateofPlayer = state;
        }
        public int stateOfPl()
        {
            return (int)stateofPlayer;
        }

        public override string ToString()
        {
            return _name.ToString();
        }
    }
}
