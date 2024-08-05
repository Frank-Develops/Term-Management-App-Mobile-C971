using C971.Models;
using C971.DB;
using System;

namespace C971
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
            termsList.ItemsSource = App.TermData.GetAllTerms();
            
        }

        private void addTerm(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AddTerm());

           
        }

        private void editTerm(object sender, EventArgs e)
        {
            Button button = (Button)sender;



            Navigation.PushAsync(new EditTerm((int)button.BindingContext));
        }

        private void viewTerm(object sender, EventArgs e)
        {
            Button button = (Button)sender;



            Navigation.PushAsync(new TermDetail((int)button.BindingContext));
        }

       

    }
}