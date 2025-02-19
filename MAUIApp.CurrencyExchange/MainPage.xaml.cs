using Microsoft.Extensions.Configuration;

namespace MAUIApp.CurrencyExchange
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        IConfiguration _config;

        public MainPage(IConfiguration config)
        {
            InitializeComponent();
            _config = config;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var apiSettings = _config.GetSection(nameof(ApiSettings)).Get<ApiSettings>();
            Console.WriteLine(apiSettings?.ApiKey);

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
