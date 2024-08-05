using C971.DB;
using C971.Models;

namespace C971
{
    public partial class App : Application
    {
        public static TermData TermData { get; private set; }
        public static CourseData CourseData { get; private set; }

        public static AssessmentData AssessmentData { get; private set; }
        public App(TermData termData, CourseData courseData, AssessmentData assessmentData)
        {
            InitializeComponent();

            MainPage = new AppShell();

            TermData = termData;

            CourseData = courseData;

            AssessmentData = assessmentData;

            App.TermData.GetAllTerms();
            App.CourseData.GetAllCourses();
            App.AssessmentData.GetAllAssessments();
            App.TermData.AddTerm(new Term
            {
                Id = 1,
                termName = "Test Term",
                startDate = DateTime.Parse("08-01-2024 00:00:00"),
                endDate = DateTime.Parse("09-01-2024 00:00:00")

            });

            App.CourseData.AddCourse(new Course
            {
                Id = 1,
                termId = 1,
                courseName = "Test Course",
                startDate = DateTime.Parse("08-01-2024 00:00:00"),
                endDate = DateTime.Parse("09-01-2024 00:00:00"),
                courseStatus = 1,
                courseInstructorName = "Anika Patel",
                courseInstructorPhone = "555-123-4567",
                courseInstructorEmail = "anika.patel@strimeuniversity.edu",
                notes = "Some sample notes",
                dueDate = DateTime.Parse("09-01-2024 00:00:00")

            });

            App.AssessmentData.AddAssessment(new Assessment
            {
                Id = 1,
                courseId = 1,
                assessmentType = 0,
                assessmentName = "First Assessment",
                startDate = DateTime.Parse("08-01-2024 00:00:00"),
                endDate = DateTime.Parse("09-01-2024 00:00:00"),
                dueDate = DateTime.Parse("09-01-2024 00:00:00")

            });

            App.AssessmentData.AddAssessment(new Assessment
            {
                Id = 2,
                courseId = 1,
                assessmentType = 1,
                assessmentName = "Second Assessment",
                startDate = DateTime.Parse("08-01-2024 00:00:00"),
                endDate = DateTime.Parse("09-01-2024 00:00:00"),
                dueDate = DateTime.Parse("09-01-2024 00:00:00")

            });
        }


    }
}
