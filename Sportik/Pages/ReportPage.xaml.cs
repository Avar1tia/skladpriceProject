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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using SkladPrice.Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using ClosedXML.Excel;
using System.Reflection;


namespace skladprice.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private ObservableCollection<merch> reportCollection;
        public ReportPage()
        {
            InitializeComponent();
            LoadReportData();
        }
        private void LoadReportData()
        {
            reportCollection = new ObservableCollection<merch>(SkladPrice.Models.skladprice.GetContext().merch.ToList());
            ReportDataGrid.ItemsSource = reportCollection;
        }
        private void ExportToCsv_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Report");

            // Заголовки столбцов
            PropertyInfo[] properties = typeof(merch).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
            }

            // Данные
            for (int i = 0; i < reportCollection.Count; i++)
            {
                var item = reportCollection[i];
                for (int j = 0; j < properties.Length; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = properties[j].GetValue(item)?.ToString() ?? string.Empty;

                }
            }
            // Использование SaveFileDialog для выбора места сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить отчет как";
            saveFileDialog.FileName = "report.xlsx"; // Предложенное имя файла

            if (saveFileDialog.ShowDialog() == true)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data exported to " + saveFileDialog.FileName);
            }
        }
    }
}

