using System;
using DatabaseProject.DTO;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;

namespace DatabaseProject.Database
{
    public class StudentDataAccess : IStudentDataAccess
    {
        SQLiteConnection Database;

        void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags, false);
            Database.CreateTable<Student>();
            Database.CreateTable<Address>();
            Database.CreateTable<Class>();


        }
        public List<Student> GetStudentsWithChildren()
        {
            Init();
            return Database.GetAllWithChildren<Student>();
        }
        public Student GetStudent(int id)
        {
            Init();
            return Database.Get<Student>(id);

        }
        public void InsertStudentWithChildren(Student student)
        {
            Init();
            Database.InsertWithChildren(student);
        }

        public Student GetStudentWithChildren(int id)
        {
            Init();
            return Database.GetWithChildren<Student>(id);
        }

        public void UpdateStudentWithChildren(Student ourChemistryStudent)
        {
            Init();
            Database.UpdateWithChildren(ourChemistryStudent);
        }
    }
}