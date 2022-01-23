using Microsoft.Extensions.Logging;
using SmokeBall.SEO.Business;
using SmokeBall.SEO.Business.Model;
using System.Windows;

namespace Smokeball.SEO.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISEResult _iSEResult;
        private readonly ILogger _logger;

        /// <summary>
        /// On load of Main window
        /// </summary>
        /// <param name="iSEResult"></param>
        /// <param name="logger"></param>
        public MainWindow(ISEResult iSEResult, ILogger<MainWindow> logger)
        {
            InitializeComponent();
            _iSEResult = iSEResult;
            _logger = logger;
        }
        /// <summary>
        /// Search button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeacrh_Click(object sender, RoutedEventArgs e)
        {
            _logger.LogInformation("Search Operation started with the search parameters: ", new SearchRequest() { Keywords = txtKeywords.Text, Url = txtUrl.Text });
            var request = new SearchRequest() { Keywords = txtKeywords.Text, Url = txtUrl.Text };
            var response = _iSEResult.Search(request);
            lstResults.Text = response;
            _logger.LogInformation("Search Operation completed.");
        }
    }
}
