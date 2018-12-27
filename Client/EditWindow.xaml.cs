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

        public EditWindow()
        {
            InitializeComponent();
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(PriceTextBox.Text, out var price))
            {
                MessageBox.Show("Incorrect price");
            }

            var entity = new Equipment
            {
                Price = price,
                Info = InfoTextBox.Text
            };
            await _equipmentService.CreateAsync(entity);
        }
    }
}
