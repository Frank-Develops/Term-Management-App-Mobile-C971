using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971.Models;
using SQLite;

namespace C971.DB
{
    public class AssessmentData
    {
        string _dbPath;
        SQLiteConnection conn;


        public AssessmentData(string dbPath)
        {
            _dbPath = dbPath;

        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Assessment>();
        }

        public List<Assessment> GetAllAssessments()
        {
            Init();
            return conn.Table<Assessment>().ToList();
        }

        public void AddAssessment(Assessment assessment)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(assessment);
        }

        public void DeleteAssessment(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Assessment { Id = id });
        }
        public void updateAssessment(Assessment assessment)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Update(assessment);
        }
    }
}
