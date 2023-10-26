using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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

                // 自定义日期的背景色
                for (int day = 1; day <= DateTime.DaysInMonth(selectedYear, i + 1); day++)
                {
                    DateTime date = new DateTime(selectedYear, i + 1, day);
                    CalendarDayButton dayButton = GetCalendarDayButton(monthCalendar, date);
                    if (dayButton != null)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            // 周末，背景色为白色 (D)
                            dayButton.Background = Brushes.White;
                        }
                        else
                        {
                            // 周一到周五，背景色为蓝色 (A)
                            dayButton.Background = Brushes.LightBlue;
                        }
                    }
                }
            }
        }

        // 获取指定日期对应的 CalendarDayButton
        private CalendarDayButton GetCalendarDayButton(Calendar calendar, DateTime date)
        {
            CalendarDayButton dayButton = null;

            // 找到 Calendar 控件的日历视觉树根元素
            FrameworkElement calendarRoot = (FrameworkElement)calendar.Template.FindName("PART_Root", calendar);

            // 查找指定日期对应的 CalendarDayButton
            foreach (var child in GetVisualChildren(calendarRoot))
            {
                if (child is CalendarDayButton dayButtonElement)
                {
                    if (dayButtonElement.DataContext is DateTime dayDate && dayDate.Date == date.Date)
                    {
                        dayButton = dayButtonElement;
                        break;
                    }
                }
            }

            return dayButton;
        }

        // 辅助方法：获取视觉树中的所有子元素
        private static IEnumerable<DependencyObject> GetVisualChildren(DependencyObject parent)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                yield return VisualTreeHelper.GetChild(parent, i);

                foreach (var childOfChild in GetVisualChildren(VisualTreeHelper.GetChild(parent, i)))
                {
                    yield return childOfChild;
                }
            }
        }

    }
}
