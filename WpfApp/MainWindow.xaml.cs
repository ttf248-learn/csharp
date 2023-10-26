using System;
using System.Windows;
using System.Windows.Controls;

namespace CalendarApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeYearComboBox();
            InitializeCalendars();
        }

        private void InitializeYearComboBox()
        {
            for (int year = DateTime.Now.Year - 1; year <= DateTime.Now.Year + 1; year++)
            {
                YearComboBox.Items.Add(year);
            }
            YearComboBox.SelectedIndex = 1; // Select the current year
            YearComboBox.SelectionChanged += YearComboBox_SelectionChanged;
        }

        private void InitializeCalendars()
        {
            for (int month = 1; month <= 12; month++)
            {
                var monthCalendar = new Calendar();
                monthCalendar.DisplayDate = new DateTime(DateTime.Now.Year, month, 1);
                CalendarItems.Items.Add(monthCalendar);
            }
        }

        private void YearComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int selectedYear = (int)YearComboBox.SelectedItem;

            for (int i = 0; i < 12; i++)
            {
                var monthCalendar = CalendarItems.Items[i] as Calendar;
                monthCalendar.DisplayDate = new DateTime(selectedYear, i + 1, 1);
            }
        }
    }
}
