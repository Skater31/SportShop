using SportShop.Models;
using SportShop.Services;
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

namespace SportShop
{
    /// <summary>
    /// Interaction logic for CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        private Shop _shop;

        private SportItemsService _sportItemsService;

        public CatalogWindow(Shop shop)
        {
            _shop = shop;

            _sportItemsService = new SportItemsService();

            InitializeComponent();

            datagridCatalog.ItemsSource = _sportItemsService.GetCatalog(_shop.Id);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow(_shop.Id).ShowDialog();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (datagridCatalog.SelectedItem != null)
            {
                new EditWindow((SportItem)datagridCatalog.SelectedItem).ShowDialog();
            }
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            datagridCatalog.ItemsSource = _sportItemsService.Find(textboxFind.Text);
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            datagridCatalog.ItemsSource = _sportItemsService.GetCatalog(_shop.Id);
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
