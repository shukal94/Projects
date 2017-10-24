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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AutorithWindow.xaml
    /// </summary>
    public partial class AutorithWindow : Window
    {
        public AutorithWindow()
        {
            InitializeComponent();
        }

        private void AutorithVkClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VK.Autorith(Password.Password, Login.Text);
                if (VK.vk.IsAuthorized)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch(VkNet.Exception.VkApiAuthorizationException ex)
            {
                MessageBox.Show("Не верный логин или пароль.");
            }
        }
    }
}
