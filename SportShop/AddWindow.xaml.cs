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
using SportShop.Enums;
using SportShop.Models;
using SportShop.Services;

namespace SportShop
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private readonly SportItemService _sportItemsService;

        private readonly int _shopId;

        public AddWindow(int shopId)
        {
            _sportItemsService = new SportItemService();

            _shopId = shopId;

            InitializeComponent();

            comboboxCategory.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textboxCount.Text, out _) &&
                decimal.TryParse(textboxPrice.Text, out _) &&
                comboboxCategory.SelectedItem != null)
            {
                _sportItemsService.Add(new SportItem
                {
                    ShopId = _shopId,
                    Name = textboxName.Text,
                    Count = int.Parse(textboxCount.Text),
                    Price = decimal.Parse(textboxPrice.Text),
                    Category = (Category)comboboxCategory.SelectedItem,
                });

                textboxName.Text = String.Empty;
                textboxCount.Text = String.Empty;
                textboxPrice.Text = String.Empty;
                comboboxCategory.SelectedItem = default;

                labelAdded.Content = "Successfully adeed!";
            }
        }
    }
}
