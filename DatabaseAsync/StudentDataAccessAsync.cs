using System;
using SQLite;
using DatabaseProject.DTO;
using SQLiteNetExtensions;
using SQLiteNetExtensionsAsync.Extensions;


namespace DatabaseProject.DatabaseAsync;

public class StudentDataAccessAsync
{

    SQLiteAsyncConnection Database;

    public StudentDataAccessAsync()
	{
	}
    void Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags, false);
        Database.CreateTableAsync<Student>();
        Database.CreateTableAsync<Address>();


    }

    public async Task<List<Student>> GetStudentsWithChildren()
    {
        Init();
        return await Database.GetAllWithChildrenAsync<Student>();


    }
}

