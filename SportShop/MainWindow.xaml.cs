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
using SportShop.Services;
using SportShop.Models;

namespace SportShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ShopService _shopService;

        public MainWindow()
        {
            _shopService = new ShopService();

            InitializeComponent();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            var shop = _shopService.GetShop(textboxLogin.Text, textboxPassword.Text);

            new CatalogWindow(shop).Show();

            Close();
        }
    }
}
