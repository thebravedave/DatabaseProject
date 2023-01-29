using System;
using DatabaseProject.Database;
using DatabaseProject.DTO;

namespace DatabaseProject.ViewModels;

public class HomeViewModel
{
    IStudentDataAccess _studentDataAccess;
    IClassDataAccess _classDataAccess;

    public HomeViewModel(IStudentDataAccess studentDataAccess, IClassDataAccess classDataAccess)
    {
        try
        {
            _studentDataAccess = studentDataAccess;
            _classDataAccess = classDataAccess;
            AddStudentAndStudentDetails();
            AddNewClassToExistingStudent();

            List<Student> students = GetStudents();

            foreach (Student student in students)
            {
                Console.WriteLine("**Student Name**");
                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                Console.WriteLine("**Address**");
                Console.WriteLine(student.Address.Street);
                Console.WriteLine(student.Address.City);
                Console.WriteLine(student.Address.ZipCode);
                Console.WriteLine("**Classes**");
                foreach (Class currentClass in student.Classes)
                {
                    Console.WriteLine(currentClass.ClassName);
                }
            }
            string test = "We did it!";

        }
        catch(Exception e)
        {
            string message = e.Message;
            string test = "ouch!";
        }
    }
    private List<Student> GetStudents()
    {
        return _studentDataAccess.GetStudentsWithChildren();
    }
    private void AddNewClassToExistingStudent()
    {
        try
        {


            Student ourChemistryStudent = _studentDataAccess.GetStudentWithChildren(1);

            Class physicalChemistry = new Class();
            physicalChemistry.ClassName = "Chemistry 442";

            _classDataAccess.InsertClass(physicalChemistry);

            ourChemistryStudent.Classes.Add(physicalChemistry);

            _studentDataAccess.UpdateStudentWithChildren(ourChemistryStudent);
        }
        catch(Exception e)
        {

            string message = e.Message;
            string test = "ouch!";
        }
    }

    private void AddStudentAndStudentDetails()
    {
        try
        {
            Student student = new Student();
            student.FirstName = "Jim";
            student.LastName = "Jowl";

            Address address = new Address();
            address.Street = "123 Fake Street";
            address.City = "Springfield";
            address.ZipCode = "97409";

            Class chemistry = new Class();
            chemistry.ClassName = "Chemistry 421";

            student.Address = address;

            student.Classes = new List<Class> { chemistry };

            _studentDataAccess.InsertStudentWithChildren(student);

            Student ourChemistryStudent = _studentDataAccess.GetStudentWithChildren(student.ID);



        }
        catch(Exception e)
        {
            string message = e.Message;
            string test = "ouch!";

        }

    }
}

