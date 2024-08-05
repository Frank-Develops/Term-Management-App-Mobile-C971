using C971.Models;
using C971.DB;
using Microsoft.AspNetCore.Components.Forms;


namespace C971;
public partial class ViewCourses : ContentPage
{
    int term;
    public ViewCourses(int termID)
    {
        InitializeComponent();
        term = termID;
        int counter = 0;

        var classList = App.CourseData.GetAllCourses();
        List<Course> courseL = new List<Course>();

        foreach (var course in classList)
        {
            if (course.termId == term)
            {

                courseL.Add(course);
                counter++;
                if (counter == 6)
                {
                    break;
                }
            }
        }

        courseList.ItemsSource = courseL;

    }

    private void addCourseForm(object sender, EventArgs e)
    {
        Button button = (Button)sender;



        Navigation.PushAsync(new AddCourse(term));
    }
    private void editCourse(object sender, EventArgs e)
    {

        Button button = (Button)sender;

        Navigation.PushAsync(new EditCourse((int)button.BindingContext));
    }
}