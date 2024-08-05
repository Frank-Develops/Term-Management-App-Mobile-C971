using C971.Models;
using C971.DB;
using CommunityToolkit.Maui.Behaviors;
using static System.Net.Mime.MediaTypeNames;
using Plugin.LocalNotification;
namespace C971;

public partial class EditCourse : ContentPage
{
    int course;
    Course editCourse;
    int termID;
    public EditCourse(int courseToEdit)
    {
        InitializeComponent();
        course = courseToEdit;


        var courseList = App.CourseData.GetAllCourses();

        foreach (var course in courseList)
        {
            if (course.Id == courseToEdit)
            {

                editCourse = course;
                termID = course.termId;
            }
        }

        this.BindingContext = editCourse;

    }

    private void deleteCourse(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        App.CourseData.DeleteCourse(course);
        Navigation.PushAsync(new ViewCourses(termID));
    }

    private void editCourseClick(object sender, EventArgs e)
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

        App.CourseData.updateCourse(new Course
        {
            Id = course,
            termId = termID,
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


        Navigation.PushAsync(new ViewCourses(termID));
    }

    private void addAssessment(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        Navigation.PushAsync(new ViewAssessments((int)button.BindingContext));
    }

    private async void shareNotes(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (NotesF.Text != null)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {


                Text = NotesF.Text,
                Title = "Share Notes"
            });

        }
        else {
            await Share.Default.RequestAsync(new ShareTextRequest
            {


                Text = editCourse.notes,
                Title = "Share Notes"
            });
        }
    }

    private async void setStartNotification(object sender, EventArgs e)
    {

        if (!(await LocalNotificationCenter.Current.AreNotificationsEnabled()))
        {
            await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        var request = new NotificationRequest
        {
            NotificationId = editCourse.Id,
            Title = "Start Course",
            Description = "Course " + editCourse.courseName + " starts " + editCourse.startDate.ToShortDateString() + ".",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = editCourse.startDate
            }
        };

        await LocalNotificationCenter.Current.Show(request);


    }

    private async void setEndNotification(object sender, EventArgs e)
    {
        if (!(await LocalNotificationCenter.Current.AreNotificationsEnabled()))
        {
            await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        var request = new NotificationRequest
        {
            NotificationId = editCourse.Id + 1,
            Title = "End Course",
            Description = "Course " + editCourse.courseName + " ends " + editCourse.endDate.ToShortDateString() + ".",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = editCourse.endDate
            }
        };

        await LocalNotificationCenter.Current.Show(request);
    }


}
