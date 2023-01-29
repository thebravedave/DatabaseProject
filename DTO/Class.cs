using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DatabaseProject.DTO;

[Table("Class")]
public class Class
{

	[PrimaryKey, AutoIncrement, Column("ID")]
	public int ID { get; set; }

	[Column("ClassName")]
	public string ClassName { get; set; }

	[ForeignKey(typeof(Student))]
	public int StudentId { get; set; }

	[ManyToOne]
	public Student Student { get; set; }
}

