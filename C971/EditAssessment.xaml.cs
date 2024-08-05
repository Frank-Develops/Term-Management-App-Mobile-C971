using C971.Models;
using C971.DB;
using Plugin.LocalNotification;


namespace C971;

public partial class EditAssessment : ContentPage
{
    int assessmentID;
    int courseID;

    int count;
    int performance = 0;
    int objective = 0;
    string setAssess;
    Assessment editAssessment;
    public EditAssessment(int ID)
    {
        InitializeComponent();
        assessmentID = ID;
        var assessmentList = App.AssessmentData.GetAllAssessments();

        foreach (var assessment in assessmentList)
        {
            if (assessment.Id == assessmentID)
            {

                editAssessment = assessment;

                if (editAssessment.assessmentType == 0)
                {
                    setAssess = "Objective";
                } else
                {
                    setAssess = "Performance";
                }
            }
        }


        this.BindingContext = editAssessment;

        courseID = editAssessment.courseId;

        foreach (var assessment in assessmentList)
        {
            if (assessment.courseId == courseID)
            {
                if (assessment.assessmentType == 0)
                {

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

    private void deleteAssessmentClick(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        App.AssessmentData.DeleteAssessment(assessmentID);
        Navigation.PushAsync(new ViewAssessments(courseID));
    }

    private void editAssessmentClick(object sender, EventArgs e)
    {

        Button button = (Button)sender;

        if (performance > 0 && assessmentTypeF.SelectedIndex == 1 && setAssess == "Objective")
        {
            DisplayAlert("Error", "Only one Objective Assessment and one Performance Asssessment can be entered for each course", "OK");
            return;
        }

        if (objective > 0 && assessmentTypeF.SelectedIndex == 0 && setAssess == "Performance")
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

        App.AssessmentData.updateAssessment(new Assessment
        {
            Id = assessmentID,
            courseId = courseID,
            assessmentType = assessmentTypeF.SelectedIndex,
            assessmentName = assessmentNameF.Text,
            startDate = startDatePicker.Date,
            endDate = endDatePicker.Date,
            dueDate = DueDatePicker.Date

        });



        Navigation.PushAsync(new ViewAssessments(courseID));
    }

    private async void setStartNotification(object sender, EventArgs e)
    {

        if (!(await LocalNotificationCenter.Current.AreNotificationsEnabled()))
        {
            await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        var request = new NotificationRequest
        {
            NotificationId = editAssessment.Id,
            Title = "Start Assessment",
            Description = "Assessment " + editAssessment.assessmentName + " starts " + editAssessment.startDate.ToShortDateString() + ".",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = editAssessment.startDate
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
            NotificationId = editAssessment.Id + 1,
            Title = "End Assessment",
            Description = "Assessment " + editAssessment.assessmentName + " ends " + editAssessment.endDate.ToShortDateString() + ".",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = editAssessment.endDate
            }
        };

        await LocalNotificationCenter.Current.Show(request);
    }
}