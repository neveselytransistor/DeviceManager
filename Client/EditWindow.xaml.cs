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
using Client.Models;
using Client.Services;

namespace Client
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly EquipmentService _equipmentService = new EquipmentService();
        private readonly BrandService _brandService = new BrandService();
        private readonly int _id;

        public EditWindow(int selectedId)
        {
            InitializeComponent();
            _id = selectedId;
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(PriceTextBox.Text, out var price))
            {
                MessageBox.Show("Incorrect price");

                return;
            }

            var entity = _id == 0 ? new Equipment() : await _equipmentService.GetAsync(_id);

            entity.Price = price;
            entity.Info = InfoTextBox.Text;
            entity.BrandId = (BrandComboBox.SelectedItem as Brand)?.Id ?? 0;

            try
            {
                if (_id == 0)
                {
                    await _equipmentService.CreateAsync(entity);
                }
                else
                {
                    await _equipmentService.UpdateAsync(entity);
                }
                
                MainWindow.PublicEquipDataGrid.ItemsSource = await _equipmentService.GetAllAsync();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Server error");
            }
            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var brands = await _brandService.GetAllAsync();
            BrandComboBox.ItemsSource = brands;
        }
    }
}
