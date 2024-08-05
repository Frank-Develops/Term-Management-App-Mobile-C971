namespace C971;
using C971.Models;
using C971.DB;
using System.Security.Cryptography.X509Certificates;
using SQLite;
using System.Xml.Linq;

public partial class EditTerm : ContentPage
{
    int term;
    Term editTerm;
    public EditTerm(int termToEdit)
    {
        InitializeComponent();

        term = termToEdit;

        var termsList = App.TermData.GetAllTerms();

        foreach (var term in termsList)
        {
            if (term.Id == termToEdit)
            {

                editTerm = term;
            }
        }

        this.BindingContext = editTerm;
    }

    private void editTermClick(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        if (startDatePicker.Date > endDatePicker.Date)
        {
            DisplayAlert("Error", "Please Make Sure that Start Date is Before End Date", "OK");
            return;

        }

        App.TermData.updateTerm(new Term
        {
            Id = editTerm.Id,
            termName = termNameF.Text,
            startDate = startDatePicker.Date,
            endDate = endDatePicker.Date

        }); ;

        Navigation.PushAsync(new MainPage());
    }

    private void deleteTerm(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        App.TermData.DeleteTerm(term);
        Navigation.PushAsync(new MainPage());
    }
}