using C971.DB;
using C971.Models;
using CommunityToolkit.Maui.Behaviors;


namespace C971;

public partial class AddCourse : ContentPage
{
    int term;
    public AddCourse(int termID)
    {
        InitializeComponent();
        term = termID;
    }

    private void addCourse(object sender, EventArgs e)
    {
        if (CourseNameF.Text == null)
        {
            DisplayAlert("Error", "Please Enter Course Name", "OK");
            return;
        }
        if (!emailValidation.IsValid)
        {
            DisplayAlert("Error", "Please Enter Email", "OK");
            return;
        }
        if (!phoneValidation.IsValid)
        {
            DisplayAlert("Error", "Please Enter Phone Number", "OK");
            return;
        }
        if (!instructorNameValidation.IsValid)
        {
            DisplayAlert("Error", "Please Enter Instructor Name", "OK");
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

        if (CourseStatusF.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Please Select A Course Status", "OK");
            return;
        }

        App.CourseData.AddCourse(new Course
        {
            termId = term,
            courseName = CourseNameF.Text,
            startDate = startDatePicker.Date,
            endDate = endDatePicker.Date,
            courseStatus = CourseStatusF.SelectedIndex,
            courseInstructorName = CourseInstructorNameF.Text,
            courseInstructorPhone = CourseInstructorPhoneF.Text,
            courseInstructorEmail = CourseInstructorEmailF.Text,
            notes = NotesF.Text,
            dueDate = DueDatePicker.Date,

        });
        Navigation.PushAsync(new ViewCourses(term));
    }
}