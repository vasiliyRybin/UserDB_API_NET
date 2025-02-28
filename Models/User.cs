﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserDB_API_NET.Models;

public partial class User
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }    
    [Key]
    public long? TaxId { get; set; }
    [Required]
    public string? PassNumber { get; set; }
    public string? Comment { get; set; }
}
