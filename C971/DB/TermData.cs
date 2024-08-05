using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971.Models;

namespace C971.DB
{
    public class TermData
    {
        string _dbPath;
        SQLiteConnection conn;

        public TermData(string dbPath)
        {
            _dbPath = dbPath;

        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Term>();
        }

        public List<Term> GetAllTerms()
        {
            Init();
            return conn.Table<Term>().ToList();
        }

        public void AddTerm(Term term)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(term);
        }

        public void DeleteTerm(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Term { Id = id });
        }

        public void updateTerm(Term term)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Update(term);
        }

     
    }
}
