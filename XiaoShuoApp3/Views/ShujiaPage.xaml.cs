using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        private async void SearchAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            string bookName = PinYinHelper.ToPinYin(BookNameTextBox.Text);
            if (await IsExitedBookAsync(bookName))
            {
                Book book = new Book();
                book.Name = BookNameTextBox.Text;
                book.Link= "https://www.cangqionglongqi.com/"+bookName+"/";
                if (!books.Contains(book))
                {
                    books.Add(book);
                }
                
            }
        }

        /// <summary>
        /// 判断时候存在这本书
        /// </summary>
        /// <param name="bookName">书名</param>
        /// <returns></returns>
        public async Task<bool> IsExitedBookAsync(string bookName)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://www.cangqionglongqi.com/"+bookName+"/");


            //string MuluHtml = await client.GetStringAsync();
            try
            {
                var MuluByte = await client.GetBufferAsync(uri);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                string MuluHtml = Encoding.GetEncoding("GBK").GetString(MuluByte.ToArray());

                //string MuluHtml = System.Text.Encoding.UTF8.GetString(MuluByte.ToArray());
                using (StringReader sr = new StringReader(MuluHtml))
                {
                    Regex muluRegex = new Regex(@"<dd><a href");

                    string contentLine = "";

                    while ((contentLine = sr.ReadLine()) != null)
                    {
                        if (muluRegex.IsMatch(contentLine))
                        {
                            Mulu mulu = new Mulu();
                            string[] strs = contentLine.Split("\"");
                            mulu.Link = uri.ToString() + strs[1];
                            //muluRegex = new Regex(@"<|>");
                            strs = Regex.Split(strs[2], @"<|>");
                            mulu.ChapterName = strs[1];
                            //Mulus.Add(mulu);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
            
            return true;

        }
    }
}
