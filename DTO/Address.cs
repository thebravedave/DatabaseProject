using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DatabaseProject.DTO;

[Table("Address")]
public class Address
{

    [PrimaryKey, AutoIncrement, Column("ID")]
    public int ID { get; set; }

	[Column("Street")]
	public string Street { get; set; }

	[Column("City")]
	public string City { get; set; }

	[Column("ZipCode")]
	public string ZipCode { get; set; }

    [ForeignKey(typeof(Student))]
    public int StudentId { get; set; }

    [OneToOne]
    public Student Student { get; set; }

}

