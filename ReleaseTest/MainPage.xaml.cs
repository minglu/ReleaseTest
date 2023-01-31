using Newtonsoft.Json;

namespace ReleaseTest;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
        try
        {
            string sample = "{\"Name\":\"ThisIsName\"," + "\"Districts\":[{\"Abbrev\":\"FL1Abbrev\",\"Name\":\"FL1Name\"},{\"Abbrev\":\"FL1Abbrev\",\"Name\":\"FL1Name\"}]}";

            var dto = JsonConvert.DeserializeObject<Account.JsonDto>(sample);
            var account = new Account(dto);

            await DisplayAlert("info", account.Username, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}


