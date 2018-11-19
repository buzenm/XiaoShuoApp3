using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XiaoShuoApp3.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace XiaoShuoApp3.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShujiaPage : Page
    {
        public ShujiaPage()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<Book> books = new ObservableCollection<Book>();
        private void SearchAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            string bookName = PinYinHelper.ToPinYin(BookNameTextBox.Text);

        }


    }
}
