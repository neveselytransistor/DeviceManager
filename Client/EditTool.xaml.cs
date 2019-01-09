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
    /// Interaction logic for EditTool.xaml
    /// </summary>
    public partial class EditTool : Window
    {
        private readonly ToolService _toolService = new ToolService();
        private readonly int _id;

        public EditTool(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var entity = _id == 0 ? new Tool() : await _toolService.GetAsync(_id);

            entity.Name = NameTextBox.Text;
            entity.Application = ApplicationTextBox.Text;

            try
            {
                if (_id == 0)
                {
                    await _toolService.CreateAsync(entity);
                }
                else
                {
                    await _toolService.UpdateAsync(entity);
                }

                MainWindow.PublicToolDataGrid.ItemsSource = await _toolService.GetAllAsync();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Server error");
            }
        }
    }
}
