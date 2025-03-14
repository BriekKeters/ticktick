﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick.Models
{
    public class Person : BaseAuditableEntity, IEquatable<Person>
    {
        public Guid PublicId { get; private set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; private set; }

        public Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public void Delete() {
            this.IsDeleted = true;
        }

        public void update(string firstName,string lastName,string middleName,DateTime? dob, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBirth = dob;
            this.MiddleName = middleName;

        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public bool Equals(Person? other)
        {
            if (!string.IsNullOrEmpty(this.SocialSecurityNumber) && !string.IsNullOrEmpty(other?.SocialSecurityNumber))
            {
                return this.SocialSecurityNumber == other.SocialSecurityNumber;
            }
            else {
                return this.PublicId == other?.PublicId;
            }
        }

        public void CreatePublicId()
        {
            this.PublicId = Guid.NewGuid();
        }
    }
}
