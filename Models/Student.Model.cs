using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestSPA;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? NIC { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? ProfileImage { get; set; }

    public static implicit operator DbSet<object>(Student v)
    {
        throw new NotImplementedException();
    }
}
