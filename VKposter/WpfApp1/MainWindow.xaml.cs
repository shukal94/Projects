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
using System.IO;
using System.Windows.Forms;
using mshtml;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        public void Click(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text != "" || SearchTextBox.Text != " ")
            {
                GoogleWeb.LoadPage(SearchTextBox.Text, ref webBrowser);//загрузка страницы
                Button1.Content = "Открытие браузера...";
                SearchTooltipError.Visibility = Visibility.Hidden;
            }
            else
            {
                SearchTooltipError.Visibility = Visibility.Visible;
            }
        }
        public void ClickClearSearch(object sender, RoutedEventArgs e)
        {
            Button1.Content = "Поиск";
            SearchTextBox.Text = "";
            ImagePanel1.Children.Clear();
            ImagePanel2.Children.Clear();
            GoogleWeb.arrayUrlPictures.Clear();
        }
        private void Navi(object sender, WebBrowserNavigatedEventArgs e)
        {
            Button1.Content = "Загрузка...";
        }
        private void Compl(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //получаем исходный текст страницы
                GoogleWeb.GetSourcePage(ref webBrowser);
                //получаем картинку по найденому url в коде страницы
                GoogleWeb.GetAllUrl();
                int indexImagePanel = 0;
                int countToFirstStack = 0;
                for (int i = 0; i < GoogleWeb.arrayUrlPictures.Count; i++)
                {
                    if (indexImagePanel == GoogleWeb.arrayUrlPictures.Count)
                        break;
                    //проверка на формат ссылки
                    if (GoogleWeb.IsTrueFormat(GoogleWeb.arrayUrlPictures[i].ToString()))
                    {
                        //создание объекта изображения и добавление к нему url
                        BitmapImage imageSource = new BitmapImage();
                        string url = GoogleWeb.arrayUrlPictures[i].ToString();
                        imageSource.BeginInit();
                        imageSource.UriSource = new Uri(url);
                        imageSource.EndInit();
                        if (countToFirstStack < GoogleWeb.arrayUrlPictures.Count/2)
                        {
                            Image newImage = new Image
                            {
                                Margin = new Thickness(8, 8, 8, 8)
                            };
                            ImagePanel2.Children.Add(newImage);
                            ((Image)ImagePanel2.Children[ImagePanel2.Children.Count - 1]).Source = imageSource;
                        }
                        else if (countToFirstStack >= GoogleWeb.arrayUrlPictures.Count/2)
                        {
                            Image newImage = new Image
                            {
                                Margin = new Thickness(8, 8, 8, 8)
                            };
                            ImagePanel1.Children.Add(newImage);
                            ((Image)ImagePanel1.Children[ImagePanel1.Children.Count - 1]).Source = imageSource;
                        }
                        else
                            throw new Exception("Ошибка в загрузке изображений.");
                        indexImagePanel++; countToFirstStack++;
                    }
                }
                Button1.Content = "Загружено.";
            }
            catch(Exception ex)
            {
                Button1.Content = ex.Message;
            }
        }
        //menu
        private void Click_LeaveVK(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("YES");
        }
    }
}
