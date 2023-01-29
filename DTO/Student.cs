using System;
namespace DatabaseProject.DTO;

using SQLite;
using SQLiteNetExtensions.Attributes;

[Table("Student")]
public class Student
{

	[PrimaryKey, AutoIncrement, Column("ID")]
	public int ID { get; set; }

	[Column("FirstName")]
	public string FirstName { get; set; }

	[Column("LastName")]
	public string LastName { get; set; }

    [ForeignKey(typeof(Address))]
    public int AddressID { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
	public Address Address { get; set; }


    //one to many relationship with Class
    [OneToMany(CascadeOperations = CascadeOperation.All)]
	public List<Class> Classes { get; set; }

}

