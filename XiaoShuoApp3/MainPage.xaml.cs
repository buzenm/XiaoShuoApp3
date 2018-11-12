using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace XiaoShuoApp3
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://www.cangqionglongqi.com/fanrenxiuxianzhuan/");

            //string MuluHtml = await client.GetStringAsync();
            var MuluByte = await client.GetBufferAsync(uri);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string MuluHtml = Encoding.GetEncoding("GBK").GetString(MuluByte.ToArray());
            //string MuluHtml = System.Text.Encoding.UTF8.GetString(MuluByte.ToArray());
            
            
        }
    }
}
