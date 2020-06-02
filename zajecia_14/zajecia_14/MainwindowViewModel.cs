using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace zajecia_14
{
    public class MainwindowViewModel
    {
        public MainwindowViewModel()
        {
            Registration = new RegistrationModel();
            RegisterCommand = new RegisterCommand();
        }
        public RegistrationModel Registration { get; set; }
        public ICommand RegisterCommand { get; set; }
    }
}
