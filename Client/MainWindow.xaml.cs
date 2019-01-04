using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Client.Models;
using Client.Services;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EquipmentService _equipmentService;
        private readonly BrandService _brandService;
        public static DataGrid PublicEquipDataGrid;
        public static DataGrid PublicBrandDataGrid;

        public MainWindow()
        {
            InitializeComponent();
            _equipmentService = new EquipmentService();
            _brandService = new BrandService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var equipments = await _equipmentService.GetAllAsync();
            EquipmentDataGrid.ItemsSource = equipments;
            PublicEquipDataGrid = EquipmentDataGrid;

            var brands = await _brandService.GetAllAsync();
            BrandDataGrid.ItemsSource = brands;
            PublicBrandDataGrid = BrandDataGrid;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow();
        }

        private void ShowEditWindow()
        {
            var id = ((Equipment) EquipmentDataGrid.SelectedItem ?? new Equipment()).Id;
            var createWindow = new EditWindow(id);
            createWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBrandButton_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Brand)BrandDataGrid.SelectedItem ?? new Brand()).Id;
            var createWindow = new EditBrand(id);
            createWindow.ShowDialog();
        }

        private void DeleteBrandButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateBrandButton_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Brand)BrandDataGrid.SelectedItem ?? new Brand()).Id;
            var createWindow = new EditBrand(id);
            createWindow.ShowDialog();
        }
    }
}