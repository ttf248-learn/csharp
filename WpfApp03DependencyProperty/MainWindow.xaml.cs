using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp03DependencyProperty
{
    public class Person : DependencyObject
    {
        // 1. 定义依赖属性 Age
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(Person), new PropertyMetadata(0, new PropertyChangedCallback(AgePropertyChanged)));

        // 2. 封装 Age 属性
        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // 3. 定义 Age 属性变化时的回调方法
        private static void AgePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Person person = d as Person;
            if (person != null)
            {
                int newAge = (int)e.NewValue;
                Console.WriteLine($"Age changed to {newAge}");
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Person person = new Person();

            // 设置年龄，触发回调方法
            person.Age = 25;

            // 获取年龄
            int age = person.Age;
            Console.WriteLine($"Current age: {age}");
        }
    }
}
