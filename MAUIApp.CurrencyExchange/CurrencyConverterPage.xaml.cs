using MAUIApp.CurrencyExchange.Models;
using MAUIApp.CurrencyExchange.Services;

namespace MAUIApp.CurrencyExchange;

public partial class CurrencyConverterPage : ContentPage
{
	List<Currency> _currencies = 
	[
        new Currency { Name = "US Dollar", Code = "USD" },
        new Currency { Name = "Euro", Code = "EUR" },
        new Currency { Name = "Japanese Yen", Code = "JPY" },
        new Currency { Name = "British Pound", Code = "GBP" },
        new Currency { Name = "Australian Dollar", Code = "AUD" },
        new Currency { Name = "Canadian Dollar", Code = "CAD" },
        new Currency { Name = "Swiss Franc", Code = "CHF" },
        new Currency { Name = "Chinese Yuan", Code = "CNY" },
        new Currency { Name = "Swedish Krona", Code = "SEK" },
        new Currency { Name = "New Zealand Dollar", Code = "NZD" }
    ];
    private readonly IApiService _apiService;
    private string? currencyFrom;
    private string? currencyTo;

    public CurrencyConverterPage(IApiService apiService)
	{
		InitializeComponent();
        PickerFrom.ItemsSource = _currencies;
        PickerTo.ItemsSource = _currencies;
        _apiService = apiService;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var amount = EntAmount.Text;
        if (string.IsNullOrEmpty(currencyFrom) || string.IsNullOrEmpty(currencyTo) || string.IsNullOrEmpty(amount))
        {
            await DisplayAlert("Error", "Invalid input", "Ok");
            return;
        }

        var root = await _apiService.ConvertCurrency(currencyFrom, currencyTo, int.Parse(amount));

        LblResult.Text = $"{amount} {currencyFrom} = {root.Result} {currencyTo}";
    }

    private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = PickerFrom.SelectedItem as Currency;
        if (selected == null)
            return;

        currencyFrom = selected.Code;
    }

    private void PickerTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = PickerTo.SelectedItem as Currency;
        if (selected == null)
            return;
        currencyTo = selected.Code;
    }
}