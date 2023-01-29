using System;
using DatabaseProject.DTO;
namespace DatabaseProject.Database
{
	public interface IClassDataAccess 
	{

        public Class GetClass(int id);
        public void InsertClass(Class newClass);
    }
}

