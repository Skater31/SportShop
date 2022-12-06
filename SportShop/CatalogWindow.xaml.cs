using SportShop.Models;
using SportShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportShop
{
    /// <summary>
    /// Interaction logic for CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        private Shop _shop;

        private SportItemService _sportItemService;

        public CatalogWindow(Shop shop)
        {
            _shop = shop;

            _sportItemService = new SportItemService();

            InitializeComponent();
            
            LoadDatagrid();
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

        private async void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            datagridCatalog.ItemsSource = await _sportItemService.Find(textboxFind.Text);
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            datagridCatalog.ItemsSource = await _sportItemService.GetCatalog(_shop.Id);

            new CatalogWindow(_shop).Show();

            Close();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().ShowDialog();
        }

        private async Task LoadDatagrid()
        {
            datagridCatalog.ItemsSource = await _sportItemService.GetCatalog(_shop.Id);
        }
    }
}
