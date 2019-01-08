using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Client.Services;
using Microsoft.Win32;

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
            IsEnabled = false;

            var attempts = 0;
            var total = 5;

            while (attempts < total)
            {
                try
                {
                    var equipments = await _equipmentService.GetAllAsync();
                    EquipmentDataGrid.ItemsSource = equipments;
                    PublicEquipDataGrid = EquipmentDataGrid;

                    var brands = await _brandService.GetAllAsync();
                    BrandDataGrid.ItemsSource = brands;
                    PublicBrandDataGrid = BrandDataGrid;

                    IsEnabled = true;

                    break;
                }
                catch (Exception)
                {
                    attempts++;
                    Thread.Sleep(1000);
                }
            }

            if (attempts == total)
            {
                MessageBox.Show(
                    "Сервер недоступен",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                Environment.Exit(1);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new EditWindow(0);
            createWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment eq)
            {
                var id = eq.Id;
                var createWindow = new EditWindow(id);
                createWindow.ShowDialog();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment eq)
            {
                var id = eq.Id;
                await _equipmentService.DeleteAsync(id);
                EquipmentDataGrid.ItemsSource = await _equipmentService.GetAllAsync();
            }
        }

        private void EditBrandButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrandDataGrid.SelectedItem is Brand br)
            {
                var id = br.Id;
                var createWindow = new EditBrand(id);
                createWindow.ShowDialog();
            }
        }

        private async void DeleteBrandButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrandDataGrid.SelectedItem is Brand br)
            {
                var id = br.Id;
                await _brandService.DeleteAsync(id);
                BrandDataGrid.ItemsSource = await _brandService.GetAllAsync();
            }
        }

        private void CreateBrandButton_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new EditBrand(0);
            createWindow.ShowDialog();
        }

        private async void ExportBrandButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await _brandService.Export();

            var dialog = new SaveFileDialog
            {
                FileName = "BrandExport.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, result, Encoding.UTF8);
                Process.Start(dialog.FileName);
            }
        }

        private async void ExportEquipButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await _equipmentService.Export();

            var dialog = new SaveFileDialog
            {
                FileName = "EquipmentExport.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, result, Encoding.UTF8);
                Process.Start(dialog.FileName);
            }
        }
    }
}