using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #nullable enable
        public Address? Address { get; set; }
        #nullable enable
        public string? PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        #nullable enable
        public List<Semester> Semesters { get; set; } = new();
        [NotMapped]
        public SemesterEnum CurrentSemester { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not User) return false;
            User user = (User) obj;
            return (user.Email == Email && user.Id == Id && user.FirstName == FirstName && user.LastName == LastName);
        }

    }
}