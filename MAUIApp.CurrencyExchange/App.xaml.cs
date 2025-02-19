namespace MAUIApp.CurrencyExchange
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetRequiredService<CurrencyConverterPage>();
        }
    }
}
