using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVM增删改查
{
    // ViewModel
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserModel user;

        public UserModel User
        {
            get { return user; }
            set
            {
                if (value != user)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public MainViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            User = new UserModel();
        }

        private void Login()
        {
            MessageBox.Show("Hello, " + User.Username + "!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
