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
    /// Interaction logic for EditBrand.xaml
    /// </summary>
    public partial class EditBrand : Window
    {
        private readonly BrandService _brandService = new BrandService();
        private readonly int _id;

        public EditBrand(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {

            var entity = _id == 0 ? new Brand() : await _brandService.GetAsync(_id);

            entity.Name = BrandNameTextBox.Text;
            entity.Info = BrandInfoTextBox.Text;

            try
            {
                if (_id == 0)
                {
                    await _brandService.CreateAsync(entity);
                }
                else
                {
                    await _brandService.UpdateAsync(entity);
                }

                MainWindow.PublicBrandDataGrid.ItemsSource = await _brandService.GetAllAsync();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Server error");
            }
        }
    }
}
