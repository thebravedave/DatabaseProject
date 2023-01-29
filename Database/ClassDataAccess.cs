using System;
using SQLite;
using DatabaseProject.DTO;
using SQLiteNetExtensions.Extensions;

namespace DatabaseProject.Database;

	public class ClassDataAccess : IClassDataAccess
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

        public Class GetClass(int id)
        {
            Init();
            return Database.Get<Class>(id);
        }

        public void InsertClass(Class newClass)
        {
            Init();
            Database.Insert(newClass);
        }


}

