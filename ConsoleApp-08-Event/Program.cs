using System;

namespace ConsoleApp_08_Event
{
    public class Button
    {
        // 定义事件
        public event EventHandler Clicked;

        public void OnClick()
        {
            // 触发事件
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button();

            // 订阅事件
            button.Clicked += (sender, e) =>
            {
                Console.WriteLine("Button Clicked: {0}", sender);
            };

            button.Clicked += (sender, e) =>
            {
                Console.WriteLine("Button 2 Clicked: {0}", sender);
            };

            // 模拟按钮点击
            button.OnClick();
        }
    }
}