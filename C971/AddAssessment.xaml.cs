using C971.DB;
using C971.Models;

namespace C971;

public partial class AddAssessment : ContentPage
{
    int course;
    int count;
    int performance = 0;
    int objective = 0;
    public AddAssessment(int courseID)
    {
        InitializeComponent();
        course = courseID;
        var assessmentList = App.AssessmentData.GetAllAssessments();
        foreach (var assessment in assessmentList)
        {
            if (assessment.courseId == course)
            {
                if (assessment.assessmentType == 0) {
                    
                    objective++;
                    count++;
                }
                if (assessment.assessmentType == 1)
                {

                    performance++;
                    count++;
                }
                
            }
        }

    }

    private void addAssessment(object sender, EventArgs e)
    {
        if (count >=2)
        {
            DisplayAlert("Error", "Only Two Assessments can be entered per course", "OK");
            return;
        }

        if (performance >= 1 && assessmentTypeF.SelectedIndex == 1)
        {
            DisplayAlert("Error", "Only one Objective Assessment and one Performance Asssessment can be entered for each course", "OK");
            return;
        }

        if (objective >= 1 && assessmentTypeF.SelectedIndex == 0)
        {
            DisplayAlert("Error", "Only one Objective Assessment and one Performance Asssessment can be entered for each course", "OK");
            return;
        }
        if (assessmentNameF.Text == null)
        {
            DisplayAlert("Error", "Please Enter Assessment Name", "OK");
            return;
        }
        if (startDatePicker.Date > endDatePicker.Date)
        {
            DisplayAlert("Error", "Please Make Sure that Start Date is Before End Date", "OK");
            return;
        }

        if (DueDatePicker.Date < startDatePicker.Date)
        {
            DisplayAlert("Error", "Please Make Sure that Due Date is After the Start Date", "OK");
            return;
        }

        if (assessmentTypeF.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Please Select An Assessment Type", "OK");
            return;
        }
        App.AssessmentData.AddAssessment(new Assessment
        {
            courseId = course,
            assessmentType = assessmentTypeF.SelectedIndex,
            assessmentName = assessmentNameF.Text,
            startDate = startDatePicker.Date,
            endDate = endDatePicker.Date,
            dueDate = DueDatePicker.Date

        });


        Navigation.PushAsync(new ViewAssessments(course));

    }
}