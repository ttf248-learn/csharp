using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace YearComboBox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new YearComboBoxViewModel();
        }
    }

    public class YearComboBoxViewModel : INotifyPropertyChanged
    {
        public YearComboBoxViewModel()
        {
            // 初始化下拉框数据
            Years = new List<YearItem>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear - 10; i <= currentYear + 10; i++)
            {
                Years.Add(new YearItem { Year = i });
            }

            SelectedYear = Years[10]; // 初始选择当前年份
        }

        private YearItem selectedYear;

        public YearItem SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                OnPropertyChanged("SelectedYear");
            }
        }

        public List<YearItem> Years { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class YearItem
    {
        public int Year { get; set; }
    }
}
