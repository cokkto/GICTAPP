using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICTAPP
{
    public class PlayerSelectorModel : Model
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
