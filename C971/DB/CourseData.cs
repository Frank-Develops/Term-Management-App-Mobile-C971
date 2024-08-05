using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971.Models;
using Plugin.LocalNotification;

namespace C971.DB
{
    public class CourseData
    {
        string _dbPath;
        SQLiteConnection conn;


        public CourseData(string dbPath)
        {
            _dbPath = dbPath;

        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Course>();
        }

        public List<Course> GetAllCourses()
        {
            Init();
            return conn.Table<Course>().ToList();
        }

        public void AddCourse(Course course)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(course);
        }

        public void DeleteCourse(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Course { Id = id });
        }

        public void updateCourse(Course course)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Update(course);
        }

    }
}
