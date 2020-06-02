using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace zajecia_14
{
    class RegisterCommand : ICommand
    {
        private RegistrationModelValidator _validator = new RegistrationModelValidator(); //to trzbea zmianic na registrationvalidatro
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var model = parameter as RegistrationModel;
            if(model is null)
            {
                return false; //guzik bedzie wylaczony
            }
            var results = _validator.Validate(model);
            model.Errors = string.Join(", ", results.Errors);
            return results.IsValid;
            //return string.IsNullOrEmpty(model.Email) && !string.IsNullOrWhiteSpace(model.Password) && model.Accept; //to trzbea zmianic na registrationvalidatro
        }

        public void Execute(object parameter)
        {
            var model = parameter as RegistrationModel;
            MessageBox.Show($"Zarejestrowano uzytkownika {model.Email}","rejestracjja pomyslna", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
