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

        public MainWindow()
        {
            InitializeComponent();
            _equipmentService = new EquipmentService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var equipments = new List<Equipment>(); //await _equipmentService.GetAllAsync();
            EquipmentDataGrid.ItemsSource = equipments;

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
            var createWindow = new EditWindow();
            createWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}