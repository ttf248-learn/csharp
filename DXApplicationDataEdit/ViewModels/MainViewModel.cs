using DevExpress.Mvvm.CodeGenerators;
using System;

namespace DXApplicationDataEdit.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        [GenerateProperty]
        string _Status;
        [GenerateProperty]
        string _UserName;

        [GenerateCommand]
        void Login() => Status = "User: " + UserName;
        bool CanLogin() => !string.IsNullOrEmpty(UserName);

        private DateTime? _currentYear = DateTime.Today;

        public DateTime? CurrentYear
        {
            get => _currentYear;
            set
            {
                Console.WriteLine("current year:{0}", _currentYear.Value.Year);
                _currentYear = value;
            }
        }
    }
}
