using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };
        //--------------------------------------------------------
        private readonly IEnumerable<string> UrlList = new string[]
        {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/windows"
        };
        //--------------------------------------------------------
        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            btnStartButton.IsEnabled = false;
            txtResults.Clear();
            await SumPageSizesAsync();
            txtResults.Text += $"\nControl return to {nameof(OnStartButtonClick)}";
            btnStartButton.IsEnabled = true;
        }
        //--------------------------------------------------------
        private void DisplayResult(string url, byte[] content) =>
            txtResults.Text += $"{url,-60}{content.Length,10:#,#}\n";
        //--------------------------------------------------------
        protected override void OnClosed(EventArgs e) => client.Dispose();
        //--------------------------------------------------------
        private async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            int total = 0;
            foreach (string url in UrlList)
            {
                int contemtLength = await ProccessUrlAsync(url, client);
            }
            stopwatch.Stop();
            txtResults.Text += $"\nTotal bytes returned:    {total:#,#}";
            txtResults.Text += $"\nElasped time:            {stopwatch.Elapsed}";
        }
        //--------------------------------------------------------
        private async Task<int> ProccessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            DisplayResult(url, content);
            return content.Length;
        }
    }
}