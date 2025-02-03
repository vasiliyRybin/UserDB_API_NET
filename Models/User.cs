using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserDB_API_NET.Models;

public partial class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }    
    [Key]
    public long? TaxId { get; set; }
    public string? PassNumber { get; set; }
    public string? Comment { get; set; }
}
