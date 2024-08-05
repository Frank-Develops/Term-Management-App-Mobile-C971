using C971.DB;
using C971.Models;
using System.Diagnostics.Metrics;

namespace C971;

public partial class ViewAssessments : ContentPage
{
    int courseID;
    public ViewAssessments(int course)
    {
        InitializeComponent();
        courseID = course;
        int counter = 0;

        var assessmentList = App.AssessmentData.GetAllAssessments();

        List<Assessment> assessmentL = new List<Assessment>();

        foreach (var assessment in assessmentList)
        {
            if (assessment.courseId == courseID)
            {

                assessmentL.Add(assessment);
                counter++;
                if (counter == 2)
                {
                    break;
                }
            }
        }

        assessmentsList.ItemsSource = assessmentL;
    }

    private void addAssessment(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddAssessment(courseID));
    }

    private void viewAssessment(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Navigation.PushAsync(new EditAssessment((int)button.BindingContext));
    }
}