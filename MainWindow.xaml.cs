using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Xceed.Words.NET;

namespace ExamModule4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiService apiService;
        private int testCount;
        private readonly string DOC_PATH = "C:\\Users\\darina.o\\Desktop\\Exam\\TestCase.docx";
        public MainWindow()
        {
            InitializeComponent();
            apiService = new ApiService();
            testCount = 0;

        }

        private async void GetDataFromApiClick(object sender, RoutedEventArgs e)
        {
            string fullname = await apiService.GetDataAsync();
            GetDataBox.Text = fullname;
        }

        private void PostDataToWordClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GetDataBox.Text))
            {
                MessageBox.Show("Сначала получите данные");
                return;
            }

            try
            {
                string action = $"Тест №{testCount++}";
                string waitingTest = FullNameHelper.Convert(GetDataBox.Text);
                string testResult = FullNameHelper.IsCorrect(GetDataBox.Text) ? "Успешно" : "Не успешно";
                
                using (var doc = DocX.Load(DOC_PATH))
                {
                    var table = doc.Tables[0]; 
                    var row = table.InsertRow();

                    row.Cells[0].Paragraphs[0].Append(action);
                    row.Cells[1].Paragraphs[0].Append(waitingTest);
                    row.Cells[2].Paragraphs[0].Append(testResult);

                    doc.Save();
                    ResultDataBox.Text = testResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в Word: {ex.Message}");
            }
        }

    }
}
