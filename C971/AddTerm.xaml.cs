namespace C971;
using C971.Models;
using C971.DB;

public partial class AddTerm : ContentPage
{
	public AddTerm()
	{
		InitializeComponent();
	}

	private void addTerm(object sender, EventArgs e)
	{
        if (startDatePicker.Date > endDatePicker.Date)
        {
            DisplayAlert("Error", "Please Make Sure that Start Date is Before End Date", "OK");
            return;
        }

        App.TermData.AddTerm(new Term
        {

            termName = termNameF.Text,
            startDate = startDatePicker.Date,
            endDate = endDatePicker.Date
            
        });
        Navigation.PushAsync(new MainPage());
    }
}