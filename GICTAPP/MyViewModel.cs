using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace GICTAPP
{
    public class MyViewModel
    {
        ICommand _command;
        public ICommand MyCommand
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }
    }
}
