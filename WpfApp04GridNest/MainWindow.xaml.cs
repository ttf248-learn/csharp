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

namespace WpfApp04GridNest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 获取 ComboBox 的编辑框 TextBox 控件
            TextBox? editableTextBox = nameCombobox.Template.FindName("PART_EditableTextBox", nameCombobox) as TextBox;

            // 检查是否找到了 TextBox
            if (editableTextBox != null)
            {
                // 修改 TextBox 的背景颜色
                editableTextBox.Background = new SolidColorBrush(Colors.LightBlue);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}