namespace C971;
using C971.Models;
using C971.DB;
using Microsoft.AspNetCore.Components.Forms;

public partial class TermDetail : ContentPage
{
    int term;
    Term viewTerm;
    public TermDetail( int termID)
	{
		InitializeComponent();
        term = termID;

        var termsList = App.TermData.GetAllTerms();

        foreach (var term in termsList)
        {
            if (term.Id == termID)
            {

                viewTerm = term;
            }
        }

        this.BindingContext = viewTerm;
    }
    private void viewCourses(object sender, EventArgs e)
    {
        Button button = (Button)sender;



        Navigation.PushAsync(new ViewCourses((int)button.BindingContext));
    }

}