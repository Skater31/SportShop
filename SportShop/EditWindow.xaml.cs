using SportShop.Enums;
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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly SportItemService _sportItemsService;
        private readonly SportItem _sportItem;

        public EditWindow(SportItem sportItem)
        {
            _sportItemsService = new SportItemService();

            _sportItem = sportItem;

            InitializeComponent();

            textboxName.Text = sportItem.Name;
            textboxCount.Text = sportItem.Count.ToString();
            textboxPrice.Text = sportItem.Price.ToString();
            comboboxCategory.ItemsSource = Enum.GetValues(typeof(Category));
            comboboxCategory.SelectedItem = _sportItem.Category;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textboxCount.Text, out _) &&
                decimal.TryParse(textboxPrice.Text, out _) &&
                comboboxCategory.SelectedItem != null)
            {
                var editedSportItem = new SportItem
                {
                    Id = _sportItem.Id,
                    ShopId = _sportItem.ShopId,
                    Name = textboxName.Text,
                    Count = int.Parse(textboxCount.Text),
                    Price = decimal.Parse(textboxPrice.Text),
                    Category = (Category)comboboxCategory.SelectedItem,
                };

                if (editedSportItem.Name == _sportItem.Name &&
                    editedSportItem.Count == _sportItem.Count &&
                    editedSportItem.Price == _sportItem.Price &&
                    editedSportItem.Category == _sportItem.Category)
                {
                    labelEdit.Content = "Item is not edited!";
                }
                else
                {
                    _sportItemsService.Edit(editedSportItem);

                    Close();
                }
            }
        }
    }
}
