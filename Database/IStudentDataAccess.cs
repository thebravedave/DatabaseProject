using System;
using DatabaseProject.DTO;


namespace DatabaseProject.Database;

public interface IStudentDataAccess
{

    public List<Student> GetStudentsWithChildren();
    public Student GetStudent(int id);
    public void InsertStudentWithChildren(Student student);
    public Student GetStudentWithChildren(int id);
    public void UpdateStudentWithChildren(Student ourChemistryStudent);


}

