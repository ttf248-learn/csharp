using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp05UIThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 假设这是一个耗时操作
            Task.Run(() =>
            {
                var result = LongRunningOperation(); // 这里是模拟一个耗时计算的方法

                // 当耗时操作完成后，在UI线程上更新UI
                Application.Current.Dispatcher.Invoke(() =>
                {
                    lable.Content = $"计算结果: {result}";
                });
            });
        }

        private string LongRunningOperation()
        {
            // 模拟耗时操作
            Thread.Sleep(5000);
            return "已完成";
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false; // 防止用户重复点击

            try
            {
                // 开启后台任务
                var result = await Task.Run(() => LongRunningOperation());

                // 在后台任务完成后，自动切换回UI线程更新UI
                lable.Content = $"计算结果: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
            finally
            {
                button.IsEnabled = true; // 重新启用按钮
            }
        }
    }
}